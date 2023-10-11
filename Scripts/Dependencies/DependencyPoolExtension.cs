using System.Collections.Generic;
using TinyDI.Dependencies.Models;
using TinyDI.Dependencies.Parameters;

namespace TinyDI.Dependencies {
    public static class DependencyPoolExtension {
        public static void Add<T>(this List<T> list, DependencyPool<T> pool) where T : IDependency {
            for (int i = 0; i < pool.length; i++) {
                list.Add(pool[i]);
            }
        }

        public static ParametersPool<T> ToParametersPool<T>(this List<T> list) where T : IParameters {
            ParametersPool<T> pool = new ParametersPool<T>(list.Count);
            
            for (int i = 0; i < list.Count; i++) {
                pool[i] = list[i];
            }

            return pool;
        }

        public static ParametersPool<T> ToParametersPool<T>(this T[] arr) where T : IParameters {
            ParametersPool<T> pool = new ParametersPool<T>(arr.Length);
            
            for (int i = 0; i < arr.Length; i++) {
                pool[i] = arr[i];
            }

            return pool;
        }
        
        public static ModelsPool<T> ToModelsPool<T>(this List<T> list) where T : IModel {
            ModelsPool<T> pool = new ModelsPool<T>(list.Count);
            
            for (int i = 0; i < list.Count; i++) {
                pool[i] = list[i];
            }

            return pool;
        }

        public static ModelsPool<T> ToModelsPool<T>(this T[] arr) where T : IModel {
            ModelsPool<T> pool = new ModelsPool<T>(arr.Length);
            
            for (int i = 0; i < arr.Length; i++) {
                pool[i] = arr[i];
            }

            return pool;
        }
    }
}