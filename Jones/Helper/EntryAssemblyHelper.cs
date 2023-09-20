using System.Reflection;
using Jones.Extensions;

namespace Jones.Helper;

public class EntryAssemblyHelper
{
    public static Version? GetAssemblyVersion() => Assembly.GetEntryAssembly()?.GetAssemblyVersion();
    
    public static string? GetLiteAssemblyVersion() => Assembly.GetEntryAssembly()?.GetAssemblyVersion().GetLiteVersion();

    public static string? GetAssemblyFileVersion() => Assembly.GetEntryAssembly()?.GetAssemblyFileVersion();
    
    public static string? GetAssemblyName() => Assembly.GetEntryAssembly()?.GetAssemblyName();
    
    public static string? GetAssemblyTitle() => Assembly.GetEntryAssembly()?.GetAssemblyTitle();
}