using System.Collections.Generic;
using TinyDI.Dependencies;
using TinyDI.Dependencies.Models;

namespace TinyDI.Resolving {
    public static class ResolveModelsUtility {
        public static void Resolve(this IModelsResolving resolving, ModelsContainer[] containers) {
            for (int containerId = 0; containerId < containers.Length; containerId++) {
                resolving.Resolve<IModelsResolving, InjectModel>(containers[containerId].GetDependencies());
            }

            resolving.TryLoad();
            resolving.TryApply();
        }
        
        public static void Resolve(this List<IModelsResolving> resolving, ModelsContainer[] containers) {
            for (int containerId = 0; containerId < containers.Length; containerId++) {
                resolving.Resolve<IModelsResolving, InjectModel>(containers[containerId].GetDependencies());
            }

            resolving.TryLoad();
            resolving.TryApply();
        }
        
        private static void TryLoad(this List<IModelsResolving> resolving) {
            for (int resolvingId = 0; resolvingId < resolving.Count; resolvingId++) {
                TryLoad(resolving[resolvingId]);
            }
        }
        
        private static void TryLoad(this IModelsResolving resolving) {
            if (resolving is ILoadResolving loadResolving) {
                loadResolving.Load();
            }
        }
        
        private static void TryApply(this List<IModelsResolving> resolving) {
            for (int resolvingId = 0; resolvingId < resolving.Count; resolvingId++) {
                TryApply(resolving[resolvingId]);
            }
        }
        
        private static void TryApply(this IModelsResolving resolving) {
            if (resolving is IModelsApplyResolving applyResolving) {
                applyResolving.ApplyModels();
            }
        }
    }
}