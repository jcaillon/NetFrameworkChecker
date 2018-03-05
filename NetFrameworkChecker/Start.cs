using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NetFrameworkChecker {

    static class Start {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            var args = Environment.GetCommandLineArgs();

            List<string> arguments = new List<string>(args);
            if (arguments.Count > 0)
                arguments.RemoveAt(0);

            // option -ShowOnlyIfNotInstalled : if present, do not show the window if version is installed
            if (args.Length >= 1) {
                for (int i = 0; i < arguments.Count; i++) {
                    if (arguments[i].Equals("-ShowOnlyIfNotInstalled", StringComparison.CurrentCultureIgnoreCase)) {
                        ShowOnlyIfNotInstalled = true;
                        arguments.RemoveAt(i);
                    }
                }
            }

            // 1st param : .net version needed
            if (arguments.Count >= 1) {
                VersionNeeded = arguments[0];
                if (!NetFrameworkVersion.IsHigherOrEqualVersionThan(VersionNeeded, "0"))
                    VersionNeeded = null;
            } 
            
            if (string.IsNullOrEmpty(VersionNeeded)) {
                VersionNeeded = "4.6.2";
            }
            
            // 2nd param : if present, do not show the window if version is installed
            if (arguments.Count >= 2) {
                InitialApplicationName = arguments[1];
            } else {
                InitialApplicationName = "3P";
            }
            
            if (ShowOnlyIfNotInstalled && NetFrameworkVersion.IsVersionAvailable(VersionNeeded)) {
                System.Windows.Forms.Application.Exit();
                return;
            }

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Application());
        }

        public static string InitialApplicationName { get; set; }

        public static bool ShowOnlyIfNotInstalled { get; set; }

        public static string VersionNeeded { get; set; }
    }
}
