using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace uFormEditor
{
    public static class Extensions
    {
        
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }

        public static  IEnumerable<Type> GetTypesWithInterface<T>(this Assembly asm)
        {
            var it = typeof(T);
            return asm.GetLoadableTypes().Where(x => it.IsAssignableFrom(x) && x.IsClass);
        }


    }
}