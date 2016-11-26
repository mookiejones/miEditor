using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace miRobotEditor.Plugins
{
    public static class PluginLoader<T>
    {
        public static ICollection<T> LoadPlugins(string path){
            string[] files = null;

            if (Directory.Exists(path)){
                files = Directory.GetFiles(path,"*.dll");

                var linkAssemblies = 
                    from file in files
                    let name = AssemblyName.GetAssemblyName(file)
                    select Assembly.Load(name);

                foreach(var a in linkAssemblies)
                {

                }

                ICollection<Assembly> assemblies = new List<Assembly>(files.Length);

                foreach(var file in files){
                    var an = AssemblyName.GetAssemblyName(file);
                    var assembly = Assembly.Load(an);
                    assemblies.Add(assembly);
                }

                var pluginType = typeof(T);
                var pluginTypes = new List<Type>();

                foreach(var assembly in assemblies)
                {
                    if(assembly !=null){
                        var types = assembly.GetTypes();
                        foreach(var ttype in types){

                            if (ttype.IsInterface||ttype.IsAbstract){
                                continue;
                            }else{
                                if (ttype.GetInterface(pluginType.FullName) != null)
                                    pluginTypes.Add(ttype);
                            }
                        }
                    }
                }

                var plugins = new List<T>(pluginTypes.Count);
                foreach(var type in pluginTypes){
                    T plugin = (T)Activator.CreateInstance(type);
                    plugins.Add(plugin);
                }
                return plugins;
            }
            return null;
        }
    }
}
