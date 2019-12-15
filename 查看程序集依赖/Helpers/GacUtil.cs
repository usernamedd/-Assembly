using System.Reflection;

namespace 查看程序集依赖.Helpers
{
    public class GacUtil
    {
        public static bool IsAssemblyInGac(string assemblyFullName)
        {
            try
            {
                return Assembly.ReflectionOnlyLoad(assemblyFullName)
                    .GlobalAssemblyCache;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsAssemblyInGac(Assembly assembly)
        {
            return assembly.GlobalAssemblyCache;
        }
    }
}