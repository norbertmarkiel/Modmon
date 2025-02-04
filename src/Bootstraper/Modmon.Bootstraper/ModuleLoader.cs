using Modmon.Shared.Abstractions.Modules;
using System.Reflection;

namespace Modmon.Bootstraper
{
    internal static class ModuleLoader
    {
        public static IList<Assembly> LoadAssemblies()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var locations = assemblies.Where(x => !x.IsDynamic)
                                .Select(x => x.Location)
                                .ToArray();

            var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                    .Where(x => !locations.Contains(x, StringComparer.InvariantCultureIgnoreCase))
                    .ToList();

            files.ForEach(x => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(x))));

            return assemblies;
        }

        public static IList<IModule> LoadModules(IEnumerable<Assembly> assemblies)
            =>
                 assemblies.SelectMany(x =>
                {
                    try //Important workaround -> I get error : Could not load file or assembly 'Microsoft.Build.Framework, Version=15.1.0.0
                    {
                        return x.GetTypes();
                    }
                    catch (ReflectionTypeLoadException ex)
                    {
                        // Return only the successfully loaded types
                        return ex.Types.Where(t => t != null);
                    }
                    catch
                    {
                        return Array.Empty<Type>(); // Skip entire assembly if it fails
                    }
                })
               .Where(x => typeof(IModule).IsAssignableFrom(x) && !x.IsInterface)
               .OrderBy(x => x.Name)
               .Select(Activator.CreateInstance)
               .Cast<IModule>()
               .ToList();
    }
}
