using System;
using System.IO;

namespace MYL.LearnMicrokernel
{
    // LEKTION 1: Hier beginnt unser Lern-Microkernel.
    // Das Programm zeigt die Konsole, startet den Modulhost und nimmt Befehle an.
    internal static class Program
    {
        private const string TargetModule = "myl.testmodule";

        private static void Main()
        {
            StartupScreen.ShowWelcome();

            // Der KernelHost verwaltet unsere Module.
            var kernel = new KernelHost();
            // DLLs werden ausschliesslich im Ordner "Modules" gesucht.
            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules");
            int count = kernel.LoadModules(folder);
            if (count == 0)
                Console.WriteLine("[HINWEIS] Kein Modul gefunden. Bitte komplette Solution erstellen.");

            kernel.StartAll();
            StartupScreen.ShowBootResult(count, kernel.RunningCount);
            StartupScreen.PrintHelp();

            try
            {
                while (true)
                {
                    StartupScreen.PrintPrompt();
                    string input = Console.ReadLine();
                    if (input == null)
                        break;

                    input = input.Trim();
                    if (input.Length == 0)
                        continue;

                    // Konsolenbefehle: spaeter kann man eigene Befehle hinzufuegen.
                    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                        break;
                    if (input.Equals("help", StringComparison.OrdinalIgnoreCase))
                        StartupScreen.PrintHelp();
                    else if (input.Equals("splash", StringComparison.OrdinalIgnoreCase))
                    {
                        StartupScreen.ShowWelcome();
                        StartupScreen.ShowBootResult(kernel.ModuleCount, kernel.RunningCount);
                    }
                    else if (input.Equals("status", StringComparison.OrdinalIgnoreCase))
                        kernel.PrintStatus();
                    else if (input.Equals("ping", StringComparison.OrdinalIgnoreCase))
                        Console.WriteLine("[ANTWORT] " + kernel.Send("kernel.console", TargetModule, "PING"));
                    else if (input.StartsWith("echo ", StringComparison.OrdinalIgnoreCase))
                        Console.WriteLine("[ANTWORT] " + kernel.Send("kernel.console", TargetModule, "ECHO " + input.Substring(5)));
                    else if (input.Equals("stop", StringComparison.OrdinalIgnoreCase))
                        kernel.StopAll();
                    else if (input.Equals("start", StringComparison.OrdinalIgnoreCase))
                        kernel.StartAll();
                    else
                        Console.WriteLine("Unbekannter Befehl. 'help' zeigt die Befehle.");
                }
            }
            finally
            {
                kernel.StopAll();
                Console.WriteLine("[KERNEL] Sauber heruntergefahren.");
            }
        }
    }
}
