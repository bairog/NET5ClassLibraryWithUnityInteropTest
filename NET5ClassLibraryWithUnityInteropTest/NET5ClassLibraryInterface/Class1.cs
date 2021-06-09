using System;
using Unity;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace NET5ClassLibraryInterface
{
    public interface IDataCreate
    {
        Int32 GetInt();
        Double GetDouble();
    }

    public static class Class1
    {

        static IDataCreate dataCreate;
        static String executionFolder;
        static Class1()
        {
            executionFolder = Path.GetDirectoryName(typeof(Class1).Assembly.Location);
            AssemblyLoadContext.Default.Resolving += Default_Resolving;


            using (var container = new UnityContainer())
            {
                var configFilePath = Path.Combine(executionFolder, "NET5ClassLibraryInterface.dll.config");
                var c = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap { ExeConfigFilename = configFilePath }, ConfigurationUserLevel.None);
                var section = c.GetSection("unity") as UnityConfigurationSection;
                container.LoadConfiguration(section);

                dataCreate = container.Resolve<IDataCreate>();
            }
        }

        private static Assembly Default_Resolving(AssemblyLoadContext context, AssemblyName assembly)
        {
            // DISCLAIMER: NO PROMISES THIS IS SECURE. You may or may not want this strategy. It's up to
            // you to determine if allowing any assembly in the directory to be loaded is acceptable. This
            // is for demo purposes only.
            var assemblyPath = Path.Combine(executionFolder, $"{assembly.Name}.dll");
            return context.LoadFromAssemblyPath(assemblyPath);
        }

        public static Int32 GetInt()
        {
            return dataCreate.GetInt();
        }

        public static Double GetDouble()
        {
            return dataCreate.GetDouble();
        }
    }
}
