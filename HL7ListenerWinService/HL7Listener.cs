using HL7ListenerApplication;
using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceProcess;
using System.Text;

namespace HL7ListenerWinService
{
    public partial class HL7Listener : ServiceBase
    {
        private static int port = 5000;
        private static string filePath = "Your file path";
        private static bool sendACK = true;
        //private static string passthruHost;
        //private static int passthruPort;
        private static Encoding encoding = Encoding.Default;
        private static bool useTLS = false;
        private static X509Certificate2 certificate = null;

        public HL7Listener()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            System.Diagnostics.Debugger.Launch();

            HL7TCPListener listener;
            if (useTLS)
            {
                listener = new HL7TCPListener(port, encoding, certificate);
            }
            else
            {
                listener = new HL7TCPListener(port, encoding);
            }
            listener.ArchivePath = filePath;
            listener.SendACK = sendACK;
            //if (passthruHost != null)
            //{
            //    listener.PassthruHost = passthruHost;
            //    listener.PassthruPort = passthruPort;
            //}
            if (!listener.Start())
            {
                LogWarning("Exiting - failed to start socket listener.");
            }
        }

        protected override void OnStop()
        {
        }

        /// <summary>
        /// Write a warning message to the console
        /// </summary>
        /// <param name="message"></param>
        private static void LogWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("WARNING: " + message);
            Console.ResetColor();
        }
    }
}
