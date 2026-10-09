using System;
using MYL.LearnContract;

namespace MYL.LearnTestModule
{
    // LEKTION 4: Unser erstes Modul. Es wird als eigene DLL gebaut.
    // Der Modulhost erkennt es ueber das gemeinsame IModule-Interface.
    // Zum Lernen kann man z.B. unten einen HELLO-Befehl einbauen.
    public sealed class TestModule : IModule
    {
        private IKernelContext _context;

        public string Id { get { return "myl.testmodule"; } }
        public string DisplayName { get { return "TestModule"; } }
        public string Version { get { return "0.1.0"; } }

        public void Start(IKernelContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            _context = context;
            _context.Log(Id, "Hello Kernel! Modul ist bereit.");
        }

        public void Stop()
        {
            if (_context != null)
                _context.Log(Id, "Goodbye Kernel!");
            _context = null;
        }

        public string Receive(string senderId, string message)
        {
            if (_context == null)
                return "ERROR: MODULE_NOT_STARTED";

            _context.Log(Id, "Nachricht von " + senderId + ": " + message);
            if (string.Equals(message, "PING", StringComparison.OrdinalIgnoreCase))
                return "PONG";
            if (message.StartsWith("ECHO ", StringComparison.OrdinalIgnoreCase))
                return message.Substring(5);
            return "UNBEKANNTE_NACHRICHT";
        }
    }
}
