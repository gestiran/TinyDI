using Sirenix.OdinInspector;

namespace TinyDI.Dependencies.Models {
    [HideLabel, HideReferenceObjectPicker]
    public sealed class ModelsPool<T> : DependencyPool<T>, IModel where T : IModel {
        public ModelsPool(int count) : base(count) { }
    }
}