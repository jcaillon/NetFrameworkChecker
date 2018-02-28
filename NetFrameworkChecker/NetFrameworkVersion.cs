using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace NetFrameworkChecker {

    /// <summary>
    /// Return the list of installed versions
    /// Reference :
    /// https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed#net_c
    /// </summary>
    internal static class NetFrameworkVersion {

        internal enum InstallerType{
            Webclient,
            Full
        }

        private static List<string> _versions;

        /// <summary>
        /// Get the url where to download the .net installer
        /// </summary>
        /// <param name="version"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetVersionUrl(string version, InstallerType type) {
            if (type == InstallerType.Full) {
                switch (version) {
                    case "4.7.1":
                        return "http://go.microsoft.com/fwlink/?LinkId=852104";
                    case "4.7":
                        return "http://go.microsoft.com/fwlink/?LinkId=825302";
                    case "4.6.2":
                        return "http://go.microsoft.com/fwlink/?LinkId=780600";
                    case "4.6.1":
                        return "http://go.microsoft.com/fwlink/?LinkId=671743";
                    case "4.6":
                        return "http://go.microsoft.com/fwlink/?LinkId=528232";
                    case "4.5.2":
                        return "http://go.microsoft.com/fwlink/?LinkId=397708";
                    case "4.5.1":
                        return "http://go.microsoft.com/fwlink/?LinkId=322116";
                    case "4.5":
                        return "http://go.microsoft.com/fwlink/?LinkId=225702";
                }
            } else {
                switch (version) {
                    case "4.7.1":
                        return "http://go.microsoft.com/fwlink/?LinkId=852092";
                    case "4.7":
                        return "http://go.microsoft.com/fwlink/?LinkId=825298";
                    case "4.6.2":
                        return "http://go.microsoft.com/fwlink/?LinkId=780596";
                    case "4.6.1":
                        return "http://go.microsoft.com/fwlink/?LinkId=671728";
                    case "4.6":
                        return "http://go.microsoft.com/fwlink/?LinkId=528222";
                    case "4.5.2":
                        return "http://go.microsoft.com/fwlink/?LinkId=397707";
                    case "4.5.1":
                        return "http://go.microsoft.com/fwlink/?LinkId=322115";
                    case "4.5":
                        return "http://go.microsoft.com/fwlink/?LinkId=225704";
                }
            }

            return null;
        }

        /// <summary>
        /// Is the input version available on this computer?
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static bool IsVersionAvailable(string version) {
            try {
                return GetVersionFromRegistry().Exists(s => s.StartsWith(version, true, CultureInfo.CurrentCulture));
            } catch (Exception) {
                return false;
            }
        }

        /// <summary>
        /// Get all versions of the .net framework installed on the computer
        /// </summary>
        /// <returns></returns>
        public static List<string> GetVersionFromRegistry() {
            if (_versions == null) {
                _versions = new List<string>();

                try {
                    // Opens the registry key for the .NET Framework entry.
                    using (RegistryKey ndpKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "").OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\")) {
                        foreach (string versionKeyName in ndpKey.GetSubKeyNames()) {
                            if (versionKeyName.StartsWith("v")) {
                                RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                                string exactVersion = (string) versionKey.GetValue("Version", "");
                                if (versionKeyName.StartsWith("v4")) {
                                    foreach (string clientFullKeyName in versionKey.GetSubKeyNames()) {
                                        RegistryKey clientFullKey = versionKey.OpenSubKey(clientFullKeyName);

                                        var v4Release = CheckFor45PlusVersion((int) clientFullKey.GetValue("Release", 0));
                                        if (!string.IsNullOrEmpty(v4Release)) {
                                            _versions.Add(v4Release);
                                        } else {
                                            exactVersion = (string) clientFullKey.GetValue("Version", "");
                                            if (!string.IsNullOrEmpty(exactVersion)) {
                                                _versions.Add(exactVersion);
                                            }
                                        }
                                    }
                                } else {
                                    _versions.Add(string.IsNullOrEmpty(exactVersion) ? versionKeyName : exactVersion);
                                }
                            }
                        }
                    }

                    _versions.Sort((s, s1) => string.Compare(s, s1, StringComparison.CurrentCultureIgnoreCase));
                } catch (Exception) {
                    //ignored
                }
            }

            return _versions;
        }
        
        private static string CheckFor45PlusVersion(int releaseKey) {
            if (releaseKey >= 461308)
                return "4.7.1"; // or superior...
            if (releaseKey >= 460798)
                return "4.7";
            if (releaseKey >= 394802)
                return "4.6.2";
            if (releaseKey >= 394254)
                return "4.6.1";
            if (releaseKey >= 393295)
                return "4.6";
            if (releaseKey >= 379893)
                return "4.5.2";
            if (releaseKey >= 378675)
                return "4.5.1";
            if (releaseKey >= 378389)
                return "4.5";
            return null;
        }
    }

}