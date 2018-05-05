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

        public static void RefreshVersionList() {
            _versions = null;
        }

        /// <summary>
        /// Get the url where to download the .net installer
        /// </summary>
        /// <param name="version"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetVersionUrl(string version, InstallerType type) {
            if (type == InstallerType.Full) {
                switch (version) {
                    case "4.7.2":
                        return "http://go.microsoft.com/fwlink/?LinkId=863265";
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
                    case "4.7.2":
                        return "http://go.microsoft.com/fwlink/?LinkId=863262";
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
                return GetVersionFromRegistry().Exists(s => IsHigherOrEqualVersionThan(s, version));
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

                    _versions.Sort((s, s1) => IsHigherVersionThan(s, s1) ? -1 : 1);
                } catch (Exception) {
                    //ignored
                }
            }

            return _versions;
        }
        
        private static string CheckFor45PlusVersion(int releaseKey) {
            if (releaseKey >= 461808)
                return "4.7.2"; // or superior...
            if (releaseKey >= 461308)
                return "4.7.1";
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

        /// <summary>
        /// Compares two version string "1.0.0.0".IsHigherVersionThan("0.9") returns true
        /// Must be STRICTLY superior
        /// </summary>
        public static bool IsHigherVersionThan(string localVersion, string requiredVersion) {
            return CompareVersions(localVersion, requiredVersion, false);
        }

        /// <summary>
        /// Compares two version string "1.0.0.0".IsHigherVersionThan("0.9") returns true
        /// </summary>
        public static bool IsHigherOrEqualVersionThan(string localVersion, string requiredVersion) {
            return CompareVersions(localVersion, requiredVersion, true);
        }

        /// <summary>
        /// Returns true if local >(=) distant
        /// </summary>
        /// <returns></returns>
        private static bool CompareVersions(string localVersion, string requiredVersion, bool trueIfEqual) {
            try {
                var splitLocal = new List<int>();
                foreach (var split in localVersion.TrimStart('v').Split('.')) {
                    splitLocal.Add(int.Parse(split.Trim()));
                }
                var splitDistant = new List<int>();
                foreach (var split in requiredVersion.TrimStart('v').Split('.')) {
                    splitDistant.Add(int.Parse(split.Trim()));
                }

                for (int j = splitLocal.Count - 1; j >= 0; j--) {
                    if (splitLocal[j] == 0) {
                        splitLocal.RemoveAt(j);
                    } else {
                        break;
                    }
                }

                for (int j = splitDistant.Count - 1; j >= 0; j--) {
                    if (splitDistant[j] == 0) {
                        splitDistant.RemoveAt(j);
                    } else {
                        break;
                    }
                }
                var i = 0;
                while (i <= (splitLocal.Count - 1) && i <= (splitDistant.Count - 1)) {
                    if (splitLocal[i] > splitDistant[i])
                        return true;
                    if (splitLocal[i] < splitDistant[i])
                        return false;
                    i++;
                }
                if (splitLocal.Count == splitDistant.Count && trueIfEqual)
                    return true;
                if (splitLocal.Count > splitDistant.Count)
                    return true;
            } catch (Exception) {
                // would happen if the input strings are incorrect
            }
            return false;
        }
    }

}