using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TCPoints.AllInterfaces
{

    public class LoadInterfacesFromAssebly<T>
    {
        public static List<T> Get(Assembly assembly)
        {
            // Projdi všechny typy v assembly
            Type[] types = assembly.GetTypes();
            Type interfaceType = typeof(T);
            List<T> interFaces = new List<T>();
            IEnumerable<Type> filteredTypes = types.Where(t => interfaceType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

            foreach (Type type in filteredTypes)
            {
                // Vytvoř instanci typu pomocí Activator.CreateInstance
                T instance = (T)Activator.CreateInstance(type);

                interFaces.Add(instance);
            }

            return interFaces;
        }
    }

    public abstract class AllInterfaces<T> : Dictionary<string, T>
    {
        protected List<T> interFaces;
        private List<Assembly> assemblies;

        public AllInterfaces()
        {
            assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            interFaces = new List<T>();
            GetImplementations();
        }

        private void LoadExternalDLL()
        {

        }

        protected abstract void SetNamesToDict();
        public abstract string GetDialogName();

        public void GetImplementations()
        {
            Type interfaceType = typeof(T);

            foreach (Assembly assembly in assemblies)
            {
                List<T> i = LoadInterfacesFromAssebly<T>.Get(assembly);
                interFaces.AddRange(i);
            }

        }

        public List<string> GetNames()
        {
            return new List<string>(this.Keys);
        }



    }
}
