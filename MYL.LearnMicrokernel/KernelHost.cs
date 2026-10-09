using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MYL.LearnContract;

namespace MYL.LearnMicrokernel
{
    // LEKTION 2: Der Modulhost ist das Herz unseres Lern-Microkernels.
    // Er sucht lokale DLLs, startet/stoppt Module und gibt Nachrichten weiter.
    // Alles laeuft im selben Prozess: keine echte IPC und keine Isolation.
    internal sealed class KernelHost : IKernelContext
    {
        private sealed class ModuleEntry
        {
            public IModule Instance;
            public bool Running;
        }

        private readonly List<ModuleEntry> _modules = new List<ModuleEntry>();

        public int ModuleCount { get { return _modules.Count; } }

        public int RunningCount
        {
            get
            {
                int count = 0;
                foreach (ModuleEntry module in _modules)
                    if (module.Running)
                        count++;
                return count;
            }
        }

        // 1) Im Modulordner DLLs suchen, die das IModule-Interface implementieren.
        // WICHTIG: Nur DLLs verwenden, denen man vertraut!
        public int LoadModules(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                Console.WriteLine("[KERNEL] Modulordner angelegt: " + folder);
            }

            foreach (string path in Directory.GetFiles(folder, "*.dll"))
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(path);
                    foreach (Type type in assembly.GetExportedTypes())
                    {
                        if (!typeof(IModule).IsAssignableFrom(type) || type.IsAbstract || !type.IsClass)
                            continue;

                        IModule instance = (IModule)Activator.CreateInstance(type);
                        if (string.IsNullOrWhiteSpace(instance.Id) || FindModule(instance.Id) != null)
                        {
                            Console.WriteLine("[KERNEL] Ungueltige/doppelte Modul-ID in " + path);
                            continue;
                        }

                        _modules.Add(new ModuleEntry { Instance = instance });
                        Console.WriteLine("[KERNEL] Erkannt: " + instance.Id + " v" + instance.Version);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[KERNEL] DLL uebersprungen: " + Path.GetFileName(path));
                    Console.WriteLine("         " + ex.GetType().Name + ": " + ex.Message);
                }
            }

            return _modules.Count;
        }

        // 2) Alle gefundenen Module starten.
        public void StartAll()
        {
            foreach (ModuleEntry module in _modules)
            {
                if (module.Running)
                    continue;

                try
                {
                    module.Instance.Start(this);
                    module.Running = true;
                    Console.WriteLine("[KERNEL] Gestartet: " + module.Instance.Id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[KERNEL] Startfehler " + module.Instance.Id + ": " + ex.Message);
                }
            }
        }

        public void StopAll()
        {
            // Rueckwaerts beenden, wie beim Herunterfahren vieler Hosts.
            for (int i = _modules.Count - 1; i >= 0; i--)
            {
                ModuleEntry module = _modules[i];
                if (!module.Running)
                    continue;

                try
                {
                    module.Instance.Stop();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[KERNEL] Stoppfehler " + module.Instance.Id + ": " + ex.Message);
                }
                finally
                {
                    module.Running = false;
                    Console.WriteLine("[KERNEL] Beendet: " + module.Instance.Id);
                }
            }
        }

        public void PrintStatus()
        {
            Console.WriteLine("[STATUS] Module: " + _modules.Count);
            foreach (ModuleEntry module in _modules)
            {
                Console.WriteLine("  " + module.Instance.Id + " (" + module.Instance.DisplayName + ", "
                    + module.Instance.Version + ") -> " + (module.Running ? "RUNNING" : "STOPPED"));
            }
        }

        // 3) Eine Nachricht an ein Modul senden.
        // In Version 0.1.0 ist das ein direkter Methodenaufruf, keine echte IPC.
        public string Send(string senderId, string targetId, string message)
        {
            ModuleEntry target = FindModule(targetId);
            if (target == null)
                return "ERROR: TARGET_NOT_FOUND";
            if (!target.Running)
                return "ERROR: TARGET_OFFLINE";
            if (string.IsNullOrEmpty(message))
                return "ERROR: INVALID_MESSAGE";

            try
            {
                return target.Instance.Receive(senderId, message) ?? "";
            }
            catch (Exception ex)
            {
                Log(targetId, "Fehler bei der Nachricht: " + ex.Message);
                return "ERROR: TARGET_ERROR";
            }
        }

        public void Log(string moduleId, string message)
        {
            Console.WriteLine("[" + moduleId + "] " + message);
        }

        private ModuleEntry FindModule(string id)
        {
            foreach (ModuleEntry module in _modules)
            {
                if (string.Equals(module.Instance.Id, id, StringComparison.OrdinalIgnoreCase))
                    return module;
            }
            return null;
        }
    }
}
