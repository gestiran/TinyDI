using Sirenix.OdinInspector;

namespace TinyDI.Dependencies.Parameters {
    [HideLabel, HideReferenceObjectPicker]
    public sealed class ParametersPool<T> : DependencyPool<T>, IParameters where T : IParameters {
        public ParametersPool(int count) : base(count) { }
    }
}