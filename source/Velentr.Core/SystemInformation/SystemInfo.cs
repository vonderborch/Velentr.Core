using System.Runtime.InteropServices;
using Velentr.Core.UnitConversion;
using Velentr.Core.UnitConversion.Byte;

namespace Velentr.Core;

/// <summary>
/// Provides system information such as processor count, total memory, operating system, and more.
/// </summary>
public sealed class SystemInfo
{
    // ReSharper disable once InconsistentNaming
    private static readonly SystemInfo instance = new();

    /// <summary>
    /// Gets the number of processors on the current machine.
    /// </summary>
    public int ProcessorCount => Environment.ProcessorCount;

    /// <summary>
    /// Gets the total memory available on the current machine.
    /// </summary>
    public Bytes TotalMemory;

    /// <summary>
    /// Gets the estimated number of GPUs on the current machine.
    /// </summary>
    public int TotalGpus;

    /// <summary>
    /// Gets the operating system of the current machine.
    /// </summary>
    public OS OperatingSystem;
    
    /// <summary>
    /// Gets the processor architecture of the current machine.
    /// </summary>
    public Architecture ProcessorArchitecture
    {
        get
        {
            return RuntimeInformation.ProcessArchitecture switch
            {
                Architecture.X86 => Architecture.X86,
                Architecture.X64 => Architecture.X64,
                Architecture.Arm => Architecture.Arm,
                Architecture.Arm64 => Architecture.Arm64,
                _ => throw new NotSupportedException(
                    $"Unsupported architecture: {RuntimeInformation.ProcessArchitecture}")
            };
        }
    }
    
    /// <summary>
    /// Gets the operating system version of the current machine.
    /// </summary>
    public string OperatingSystemVersion => Environment.OSVersion.ToString();
    
    /// <summary>
    /// Gets the machine name of the current machine.
    /// </summary>
    public string MachineName => Environment.MachineName;
    
    /// <summary>
    /// Gets the user name of the current user.
    /// </summary>
    public string UserName => Environment.UserName;
    
    /// <summary>
    /// Gets the user domain name of the current user.
    /// </summary>
    public string UserDomainName => Environment.UserDomainName;
    
    /// <summary>
    /// Gets the current directory of the current process.
    /// </summary>
    public string CurrentDirectory => Environment.CurrentDirectory;
    
    /// <summary>
    /// Gets the system directory of the current machine.
    /// </summary>
    public string SystemDirectory => Environment.SystemDirectory;

    /// <summary>
    /// Gets a value indicating whether the current process is running in user-interactive mode.
    /// </summary>
    public bool UserInteractive => Environment.UserInteractive;
    
    /// <summary>
    /// Gets the command line for the current process.
    /// </summary>
    public string CommandLine => Environment.CommandLine;
    
    /// <summary>
    /// Gets the path to the user's documents directory.
    /// </summary>
    public string UserDocumentsDirectory => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    
    /// <summary>
    /// Gets the path to the user's local application data directory.
    /// </summary>
    public string UserLocalApplicationDataDirectory => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    
    static SystemInfo()
    {
    }

    private SystemInfo()
    {
        Refresh();
    }

    /// <summary>
    /// Gets the singleton instance of the SystemInfo class.
    /// </summary>
    public static SystemInfo Instance
    {
        get
        {
            return instance;
        }
    }

    /// <summary>
    /// Refreshes the system information.
    /// </summary>
    public void Refresh()
    {
        // Determine operating system
        if (IsAndroid())
        {
            OperatingSystem = OS.Android;
        }
        else if (IsIOS())
        {
            OperatingSystem = OS.iOS;
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            OperatingSystem = OS.Windows;
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            OperatingSystem = OS.MacOS;
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            OperatingSystem = OS.Linux;
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
        {
            OperatingSystem = OS.FreeBSD;
        }
        else
        {
            OperatingSystem = OS.Unknown;
        }

        // Get total memory
        TotalMemory = GetTotalSystemMemory();

        // Estimate number of GPUs
        // This is a simplified detection and would need to be improved
        // for accurate GPU detection
        TotalGpus = EstimateNumberOfGpus();
    }

    /// <summary>
    /// Gets the total system memory.
    /// </summary>
    /// <returns>The total system memory in bytes.</returns>
    private Bytes GetTotalSystemMemory()
    {
        try
        {
            // Cross-platform way to get physical memory
            ulong totalMemoryBytes;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // On Windows
                var memoryStatus = new MEMORYSTATUSEX();
                if (GlobalMemoryStatusEx(memoryStatus))
                {
                    totalMemoryBytes = memoryStatus.ullTotalPhys;
                }
                else
                {
                    // Fallback
                    totalMemoryBytes = (ulong)GC.GetGCMemoryInfo().TotalAvailableMemoryBytes;
                }
            }
            else
            {
                // On Linux, macOS, etc.
                totalMemoryBytes = (ulong)GC.GetGCMemoryInfo().TotalAvailableMemoryBytes;
            }

            return new Bytes(totalMemoryBytes, unit: ByteUnits.Byte);
        }
        catch
        {
            // Fallback to a reasonable default if memory detection fails
            return new Bytes(4L * 1024 * 1024 * 1024, unit: ByteUnits.Byte); // Default to 4 GB
        }
    }

    /// <summary>
    /// Estimates the number of GPUs on the current machine.
    /// </summary>
    /// <returns>The estimated number of GPUs.</returns>
    private int EstimateNumberOfGpus()
    {
        try
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Basic check for Windows - this is just an approximation
                // Would need DirectX or other API for accurate detection
                return Environment.GetEnvironmentVariable("CUDA_VISIBLE_DEVICES")?.Split(',').Length 
                    ?? (Environment.ProcessorCount > 2 ? 1 : 0);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // Basic check for macOS - this is just an approximation  
                return 1; // Most Macs have at least integrated graphics
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // For Linux, check for common GPU device files
                // This is a simplified approach
                string[] possibleGpuPaths = 
                {
                    "/dev/dri/card0",
                    "/dev/dri/card1", 
                    "/dev/nvidia0",
                    "/dev/nvidia1"
                };
                
                return possibleGpuPaths.Count(path => File.Exists(path));
            }
            
            // Default assumption
            return 1;
        }
        catch
        {
            // Default to 1 if detection fails
            return 1;
        }
    }

    /// <summary>
    /// Determines if the current operating system is Android.
    /// </summary>
    /// <returns>True if the operating system is Android, otherwise false.</returns>
    private bool IsAndroid()
    {
        try
        {
            // Check for Android-specific directories
            if (Directory.Exists("/system/app") && Directory.Exists("/system/priv-app"))
            {
                return true;
            }

            // Check for Android environment variable
            string androidBootLogo = Environment.GetEnvironmentVariable("ANDROID_BOOTLOGO");
            if (!string.IsNullOrEmpty(androidBootLogo))
            {
                return true;
            }

            // Alternative check - Android reports as Linux with specific properties
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && File.Exists("/system/build.prop"))
            {
                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Determines if the current operating system is iOS.
    /// </summary>
    /// <returns>True if the operating system is iOS, otherwise false.</returns>
    private bool IsIOS()
    {
        try
        {
            // Check for iOS-specific directories
            if (Directory.Exists("/Applications") && Directory.Exists("/var/mobile"))
            {
                return true;
            }

            // iOS and macOS are both Darwin-based, check for iOS specifics
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                string deviceName = Environment.MachineName ?? string.Empty;
                if (deviceName.StartsWith("iPhone", StringComparison.OrdinalIgnoreCase) || 
                    deviceName.StartsWith("iPad", StringComparison.OrdinalIgnoreCase) || 
                    deviceName.StartsWith("iPod", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                // Additional iOS-specific path
                if (Directory.Exists("/var/mobile/Library"))
                {
                    return true;
                }
            }

            return false;
        }
        catch
        {
            return false;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    private class MEMORYSTATUSEX
    {
        public uint dwLength;
        public uint dwMemoryLoad;
        public ulong ullTotalPhys;
        public ulong ullAvailPhys;
        public ulong ullTotalPageFile;
        public ulong ullAvailPageFile;
        public ulong ullTotalVirtual;
        public ulong ullAvailVirtual;
        public ulong ullAvailExtendedVirtual;
        
        public MEMORYSTATUSEX()
        {
            dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
        }
    }

    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GlobalMemoryStatusEx(MEMORYSTATUSEX lpBuffer);

}
