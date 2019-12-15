using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace 查看程序集依赖
{
    public class AssemblyInfoResolver
    {
        private string _directory;
        public AssemblyInfoResolver(string directory)
        {
            _directory = directory;
        }

        public IEnumerable<Link> Resolve()
        {
            var allFiles = Directory.EnumerateFiles(_directory);
            List<Link> tmpLinks = new List<Link>();
            foreach (var file in allFiles)
            {
                try
                {
                    var ass = Assembly.ReflectionOnlyLoadFrom(file);
                    var referencedAss = ass.GetReferencedAssemblies();
                    //判断 是否是GAC程序集  GAC程序集不参与其中
                    //创建Link
                    //查询Link
                
                    foreach (var assemblyName in referencedAss)
                    {
                        if (assemblyName.Name.IndexOf("System.Runtime.CompilerServices.Unsafe")>-1)
                        {
                            Console.WriteLine(ass.GetName().Name);
                        }
                        tmpLinks.Add(new Link() { From = new AssemblyInfo { Name = ass.GetName().Name }, To = new AssemblyInfo() { Name = assemblyName.Name } });
                    }
                    //yield return new Link()
                    //{
                    //    From = new AssemblyInfo {Name = ass.GetName().Name},
                    //    To = new AssemblyInfo() {Name = assemblyName.Name}
                    //};
                
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
               
            }
            return tmpLinks;
        }
    }
}