using System;

namespace MYL.LearnMicrokernel
{
    /// <summary>
    /// The visible welcome screen is intentionally separate from the module host.
    /// Console-only, ASCII-friendly and usable without additional dependencies.
    /// </summary>
    internal static class StartupScreen
    {
        private const int ContentWidth = 68;
        private const string Version = "0.1.0";
        private const string Build = "0008";
        private static readonly ConsoleColor DefaultColor = Console.ForegroundColor;

        public static void ShowWelcome()
        {
            try
            {
                if (!Console.IsOutputRedirected)
                {
                    Console.Title = "TaktVibes | MYL Community Learn Microkernel " + Version + " | Build " + Build;
                    Console.Clear();
                }
            }
            catch (System.IO.IOException)
            {
                // Small teaching app: continue when the terminal doesn't support this.
            }
            catch (ArgumentException)
            {
                // A very limited console may reject title or clear commands.
            }

            Console.WriteLine();
            WriteBorder();
            WritePanelLine("");
            WritePanelLine(" __  __ __   __ _", ConsoleColor.Cyan, true);
            WritePanelLine(@"|  \/  |\ \ / /| |", ConsoleColor.Cyan, true);
            WritePanelLine(@"| |\/| | \ V / | |__", ConsoleColor.Cyan, true);
            WritePanelLine(@"|_|  |_|  |_|  |____|", ConsoleColor.Cyan, true);
            WritePanelLine("");
            WritePanelLine("M A N A G E   Y O U R   L I F E", ConsoleColor.White, true);
            WritePanelLine("C O M M U N I T Y", ConsoleColor.Yellow, true);
            WritePanelLine("");
            WritePanelLine("L E A R N   M I C R O K E R N E L", ConsoleColor.Green, true);
            WritePanelLine("C# PLUGIN-/MODULHOST - KEIN OS-KERNEL", ConsoleColor.Gray, true);
            WritePanelLine("");
            WritePanelLine("VERSION " + Version + "  |  BUILD " + Build + "  |  COMMUNITY EDITION", ConsoleColor.White, true);
            WriteBorder();
            Console.WriteLine();
            WriteLabel("WELCOME", "Learn. Build. Explore.", ConsoleColor.Cyan);
            WriteLabel("ABOUT", "Ein C#-Pluginhost zum Lernen, kein Betriebssystemkernel.", ConsoleColor.Gray);
            Console.WriteLine();
        }

        public static void ShowBootResult(int modulesFound, int modulesRunning)
        {
            string discovery = modulesFound == 1 ? "1 module found" : modulesFound + " modules found";
            string active = modulesRunning == 1 ? "1 running" : modulesRunning + " running";
            WriteLabel("MODULES", discovery + " / " + active,
                modulesRunning > 0 ? ConsoleColor.Green : ConsoleColor.Yellow);

            if (modulesRunning > 0)
                WriteLabel("SYSTEM", "READY  -  Your learning session can begin!", ConsoleColor.Green);
            else
                WriteLabel("SYSTEM", "LIMITED  -  Check the Modules folder.", ConsoleColor.Yellow);

            Console.WriteLine();
            WriteLabel("TIP", "Type 'help' for commands or 'splash' to see this screen again.", ConsoleColor.Gray);
            Console.WriteLine();
            WriteRule();
            Console.WriteLine();
        }

        public static void PrintPrompt()
        {
            SetColor(ConsoleColor.Cyan);
            Console.Write("MYL");
            ResetColor();
            Console.Write("> ");
        }

        public static void PrintHelp()
        {
            WriteLabel("COMMANDS", "status | ping | echo <Text> | stop | start | splash | help | exit", ConsoleColor.White);
            Console.WriteLine();
        }

        private static void WriteBorder()
        {
            SetColor(ConsoleColor.DarkCyan);
            Console.WriteLine("  +" + new string('-', ContentWidth + 2) + "+");
            ResetColor();
        }

        private static void WritePanelLine(string text, ConsoleColor color = ConsoleColor.Gray, bool center = false)
        {
            if (text.Length > ContentWidth)
                text = text.Substring(0, ContentWidth);

            if (center)
                text = new string(' ', (ContentWidth - text.Length) / 2) + text;

            SetColor(ConsoleColor.DarkCyan);
            Console.Write("  | ");
            SetColor(color);
            Console.Write(text.PadRight(ContentWidth));
            SetColor(ConsoleColor.DarkCyan);
            Console.WriteLine(" |");
            ResetColor();
        }

        private static void WriteLabel(string label, string value, ConsoleColor color)
        {
            SetColor(ConsoleColor.DarkGray);
            Console.Write("  [" + label.PadRight(8) + "] ");
            SetColor(color);
            Console.WriteLine(value);
            ResetColor();
        }

        private static void WriteRule()
        {
            SetColor(ConsoleColor.DarkCyan);
            Console.WriteLine("  " + new string('-', ContentWidth + 6));
            ResetColor();
        }

        private static void SetColor(ConsoleColor color)
        {
            if (!Console.IsOutputRedirected)
            {
                try { Console.ForegroundColor = color; }
                catch (ArgumentException) { }
                catch (System.IO.IOException) { }
            }
        }

        private static void ResetColor()
        {
            SetColor(DefaultColor);
        }
    }
}
