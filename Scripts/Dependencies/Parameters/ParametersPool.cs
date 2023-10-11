#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace TinyDI.Dependencies.Parameters {
#if ODIN_INSPECTOR
    [HideLabel, HideReferenceObjectPicker]
#endif
    public sealed class ParametersPool<T> : DependencyPool<T>, IParameters where T : IParameters {
        public ParametersPool(int count) : base(count) { }
    }
}