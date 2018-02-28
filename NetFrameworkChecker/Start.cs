using System;

namespace NetFrameworkChecker {

    static class Start {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            // 1st param : .net version needed
            var args = Environment.GetCommandLineArgs();
            if (args.Length >= 2) {
                VersionNeeded = args[1];
            } else {
                VersionNeeded = "4.6";
            }

            // 2nd param : if present, do not show the window if version is installed
            if (args.Length >= 3) {
                InitialApplicationName = args[2];
            } else {
                InitialApplicationName = "3P";
            }

            // option -ShowOnlyIfNotInstalled : if present, do not show the window if version is installed
            if (args.Length >= 2) {
                foreach (var arg in args) {
                    if (arg.Equals("-ShowOnlyIfNotInstalled", StringComparison.CurrentCultureIgnoreCase))
                        ShowOnlyIfNotInstalled = true;
                }
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
