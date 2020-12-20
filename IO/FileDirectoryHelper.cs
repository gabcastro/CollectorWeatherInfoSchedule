using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace WeatherCollector.IO
{
    public class FileDirectoryHelper
    {
        enum OsType { Windows, Linux, macOS };
        private readonly IConfiguration _configuration;
        
        public FileDirectoryHelper(IConfiguration configuration)
        {
            _configuration = configuration;   
            CreateDirectoryIfNotExists();   
            CreateFileIfNotExists();      
        }

        private OsType CheckOS()
        {
            string windir = Environment.GetEnvironmentVariable("windir");
            if (!string.IsNullOrEmpty(windir) && windir.Contains(@"\") && Directory.Exists(windir))
                return OsType.Windows;
            else if (File.Exists(@"/proc/sys/kernel/ostype"))
            {
                string osType = File.ReadAllText(@"/proc/sys/kernel/ostype");
                if (osType.StartsWith("Linux", StringComparison.OrdinalIgnoreCase))
                    return OsType.Linux;
                else
                    throw new PlatformNotSupportedException(osType);
            }
            else if (File.Exists(@"/System/Library/CoreServices/SystemVersion.plist"))
                return OsType.macOS;
            else
                throw new PlatformNotSupportedException();
        }

        public void CreateDirectoryIfNotExists()
        {
            switch (CheckOS())
            {
                case OsType.Windows:
                    string dir = _configuration.GetValue<string>("WinDirectory");
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    break;
                case OsType.Linux:
                case OsType.macOS:
                default:
                    break;
            }
        }

        public void CreateFileIfNotExists()
        {
            switch (CheckOS())
            {
                case OsType.Windows:
                    string file = _configuration.GetValue<string>("WinFileDir");
                    if (!File.Exists(file))
                        using (FileStream fs = File.Create(file));
                    break;
                case OsType.Linux:
                case OsType.macOS:
                default:
                    break;
            }
        }
    }
}