﻿using System.ServiceProcess;

namespace HL7ListenerWinService
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new HL7Listener()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
