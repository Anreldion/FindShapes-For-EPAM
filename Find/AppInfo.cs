using System.Reflection;

namespace Find
{
    public class AppInfo
    {
        private static readonly Assembly _assembly = Assembly.GetEntryAssembly()!;

        public static string Version => _assembly.GetName().Version?.ToString() ?? "?.?.?";
        public static string Product => _assembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product ?? "";
        public static string Description => _assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description ?? "";
        public static string Company => _assembly.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company ?? "";
        public static string Copyright => _assembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright ?? "";

    }
}
