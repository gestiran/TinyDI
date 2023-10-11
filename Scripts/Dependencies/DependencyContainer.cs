using System;
using System.Collections.Generic;
using TinyDI.Resolving;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace TinyDI.Dependencies {
    public abstract class DependencyContainer<Dependency> : IDependencyContainer where Dependency : IDependency {
    #if ODIN_INSPECTOR
        [ListDrawerSettings(ListElementLabelName = "@GetType().Name", HideAddButton = true, HideRemoveButton = true, IsReadOnly = true)]
        [ShowInInspector, HideInEditorMode, HideReferenceObjectPicker, Searchable]
    #endif
        private readonly List<object> _dependencies = new List<object>();

        public void Add<T>(T dependency) where T : Dependency => _dependencies.Add(dependency);

        public Dictionary<Type, object> GetDependencies() {
            Dictionary<Type, object> dependencies = new Dictionary<Type, object>(_dependencies.Count);

            for (int dependencyId = 0; dependencyId < _dependencies.Count; dependencyId++) {
                dependencies.Add(_dependencies[dependencyId].GetType(), _dependencies[dependencyId]);
            }

            return dependencies;
        }
    }
}