using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CA.Modes;
using System.IO;
using System.Reflection;

namespace CA.UI.Infrastructure
{
    public class ModelPluginLoader
    {
        private static List<ITestableModel> _CAModelPlugins;

        private static string GetDefaultModulesDirectory()
        {
            string binariesFolder = Path.GetDirectoryName(Application.ExecutablePath);
            return Path.Combine(binariesFolder, "Modules");
        }

        public static ITestableModel[] GetCAModelPluginsFromLibraries(string directory = null)
        {
            if (string.IsNullOrEmpty(directory))
            {
                directory = GetDefaultModulesDirectory();
            }

            if (_CAModelPlugins == null || _CAModelPlugins.Count == 0)
            {
                DirectoryInfo modulesDirectory = new DirectoryInfo(directory);
                _CAModelPlugins = new List<ITestableModel>();
                var modelType = typeof (ITestableModel);

                if (!modulesDirectory.Exists)
                {
                    modulesDirectory.Create();
                }
                else
                {
                    foreach (FileInfo file in modulesDirectory.GetFiles("*.dll"))
                        //loop through all dll files in directory
                    {
                        try
                        {
                            //using Reflection, load Assembly into memory from disk
                            Assembly currentAssembly = Assembly.LoadFile(file.FullName);

                            //Type discovery to find the type we're looking for which is IPluginInterface
                            foreach (Type type in currentAssembly.GetTypes())
                            {
                                if (!modelType.IsAssignableFrom(type) || !type.IsClass)
                                {
                                    continue;
                                }

                                //Create instance of class that implements IPluginInterface and cast it to type
                                //IPluginInterface and add it to our list
                                ITestableModel plugin = (ITestableModel) Activator.CreateInstance(type);
                                if (!_CAModelPlugins.Any(pl => pl.GetType() == plugin.GetType()))
                                {
                                    _CAModelPlugins.Add(plugin);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }

                IEnumerable<Type> domainPlugins = (AppDomain.CurrentDomain.GetAssemblies().ToList()
                                                            .SelectMany(a => a.GetTypes())
                                                            .Where(t => modelType.IsAssignableFrom(t)));

                foreach (var plugin in domainPlugins)
                {
                    if (!modelType.IsAssignableFrom(plugin) || !plugin.IsClass)
                    {
                        continue;
                    }

                    ITestableModel pluginObject = (ITestableModel) Activator.CreateInstance(plugin);
                    if (!_CAModelPlugins.Any(pl => pl.GetType() == pluginObject.GetType()))
                    {
                        _CAModelPlugins.Add(pluginObject);
                    }
                }
            }
            return _CAModelPlugins.ToArray();
        }

        public static ITestableModel FindPlaginByTypeName(string typeNameWithNamespace)
        {
            var allModules = GetCAModelPluginsFromLibraries();

            return allModules.FirstOrDefault(md => md.GetType().FullName == typeNameWithNamespace);
        }
    }
}
