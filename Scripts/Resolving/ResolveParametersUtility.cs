using System.Collections.Generic;
using TinyDI.Dependencies.Parameters;

namespace TinyDI.Resolving {
    public static class ResolveParametersUtility {
        public static void Resolve(this IParametersResolving resolving, ParametersContainer[] containers) {
            for (int containerId = 0; containerId < containers.Length; containerId++) {
                resolving.Resolve<IParametersResolving, InjectParameters>(containers[containerId].GetDependencies());
            }
            
            resolving.TryApply();
        }
        
        public static void Resolve(this List<IParametersResolving> resolving, ParametersContainer[] containers) {
            for (int containerId = 0; containerId < containers.Length; containerId++) {
                resolving.Resolve<IParametersResolving, InjectParameters>(containers[containerId].GetDependencies());
            }
            
            resolving.TryApply();
        }
        
        private static void TryApply(this List<IParametersResolving> resolving) {
            for (int resolvingId = 0; resolvingId < resolving.Count; resolvingId++) {
                TryApply(resolving[resolvingId]);
            }
        }
        
        private static void TryApply(this IParametersResolving resolving) {
            if (resolving is IParametersApplyResolving applyResolving) {
                applyResolving.ApplyParameters();
            }
        }
    }
}