#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace TinyDI.Dependencies.Models {
#if ODIN_INSPECTOR
    [HideLabel, HideReferenceObjectPicker]
#endif
    public sealed class ModelsPool<T> : DependencyPool<T>, IModel where T : IModel {
        public ModelsPool(int count) : base(count) { }
    }
}