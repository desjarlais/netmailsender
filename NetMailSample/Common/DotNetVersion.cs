using System;
using System.Text;
using Microsoft.Win32;

namespace NetMailSample.Common
{
    class DotNetVersion
    {
        /// <summary>
        /// Find the installed .NET Framework versions by querying the registry
        /// Release key versions: 
        ///     378389 = 4.5
        ///     378675 = 4.5.1 on Win8.1 or Server 2012 R2
        ///     378758 = 4.5.1 on Win8/Win7SP1/VistaSP2
        ///     379893 = .NET Framework 4.5.2
        ///     393295 = .NET Framework 4.6 on Win10
        ///     393297 = .NET Framework 4.6 on Non-Win10
        /// </summary>
        public static string GetDotNetVerFromRegistry()
        {
            string dotNET45;
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
               RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"))
            {
                try
                {
                    int releaseKey = (int)ndpKey.GetValue("Release");
                    dotNET45 = CheckFor45DotVersion(releaseKey) + ndpKey.GetValue("Version").ToString();
                }
                catch (NullReferenceException)
                {
                    // added this .NET V4 check for Win7
                    // there is no Release key so just pulling the Version key and displaying that number
                    RegistryKey ndpv4Key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                        RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Client\");
                    dotNET45 = "Installed .NET Framework version = " + ndpv4Key.GetValue("Version").ToString();
                }
            }

            return dotNET45;
        }

        // Checking the version using >= to enable forward compatibility
        public static string CheckFor45DotVersion(int releaseKey)
        {
            if (releaseKey >= 393295)
            {
                return "Installed .NET Framework = 4.6 or later - Version = ";
            }
            if (releaseKey >= 379893)
            {
                return "Installed .NET Framework = 4.5.2 - Version = ";
            }
            if (releaseKey >= 378675)
            {
                return "Installed .NET Framework = 4.5.1 - Version = ";
            }
            if (releaseKey >= 378389)
            {
                return "Installed .NET Framework = 4.5 - Version = ";
            }
        
            // This line should never execute. A non-null release key should mean 
            // that 4.5 or later is installed. 
            return "The .NET Framework 4.5 or later NOT detected";
        }

        /// <summary>
        ///  return the current runtime version by querying the Environment class in code
        /// </summary>
        public static string GetRuntimeVersionFromEnvironment()
        {
            return Environment.Version.ToString();
        }

        /// <summary>
        /// find the installed .NET Framework versions by querying the registry (versions 1-4)
        /// Note: currently not being used, more of a stub in case I need to include this later
        /// </summary>
        public static string GetPreV45FromRegistry()
        {
            StringBuilder preV45 = new StringBuilder();

            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                foreach (string versionKeyName in ndpKey.GetSubKeyNames())
                {
                    if (versionKeyName.StartsWith("v"))
                    {
                        RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                        string name = (string)versionKey.GetValue("Version", "");
                        string sp = versionKey.GetValue("SP", "").ToString();
                        string install = versionKey.GetValue("Install", "").ToString();

                        if (install == "") //no install info, must be later
                            preV45.AppendLine((versionKeyName + "  " + name));
                        else
                        {
                            if (sp != "" && install == "1")
                            {
                                preV45.AppendLine(versionKeyName + "  " + name + "  SP" + sp);
                            }

                        }
                        if (name != "")
                        {
                            continue;
                        }
                        foreach (string subKeyName in versionKey.GetSubKeyNames())
                        {
                            RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                            name = (string)subKey.GetValue("Version", "");
                            if (name != "")
                                sp = subKey.GetValue("SP", "").ToString();
                            install = subKey.GetValue("Install", "").ToString();
                            if (install == "") //no install info, must be later
                                preV45.AppendLine(versionKeyName + "  " + name);
                            else
                            {
                                if (sp != "" && install == "1")
                                {
                                    preV45.AppendLine("  " + subKeyName + "  " + name + "  SP" + sp);
                                }
                                else if (install == "1")
                                {
                                    preV45.AppendLine("  " + subKeyName + "  " + name);
                                }
                            }
                        }
                    }
                }
            }

            return preV45.ToString();
        }
    }
}
