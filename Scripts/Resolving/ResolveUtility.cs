using System;
using System.Collections.Generic;
using System.Reflection;
using TinyDI.Dependencies;

namespace TinyDI.Resolving {
    public static class ResolveUtility {
        public static void Resolve<T1,T2>(this List<T1> resolving, Dictionary<Type, object> dependencies) where T1 : IResolving where T2 : Inject {
            for (int resolvingId = 0; resolvingId < resolving.Count; resolvingId++) {
                Resolve<T1,T2>(resolving[resolvingId], dependencies);
            }
        }

        public static void Resolve<T1, T2>(this T1 resolving, Dictionary<Type, object> dependencies) where T1 : IResolving where T2 : Inject {
            FieldInfo[] fields = resolving.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            for (int fieldId = 0; fieldId < fields.Length; fieldId++) {
                T2 attribute = (T2)Attribute.GetCustomAttribute(fields[fieldId], typeof(T2));
                
                if (attribute == null) {
                    continue;
                }

                Type fieldType = fields[fieldId].FieldType;

                if (!dependencies.ContainsKey(fieldType)) {
                    continue;
                }

                fields[fieldId].SetValue(resolving, dependencies[fieldType]);
            }
        }
    }
}