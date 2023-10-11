using Sirenix.OdinInspector;

namespace TinyDI.Dependencies {
    [HideLabel, HideReferenceObjectPicker]
    public abstract class DependencyPool<T> where T : IDependency {
        public int length => _objects.Length;

        [ListDrawerSettings(HideAddButton = true, HideRemoveButton = true, IsReadOnly = true)]
        [ShowInInspector, HideInEditorMode, HideReferenceObjectPicker, LabelText("@ToString()")]
        private readonly T[] _objects;

        public DependencyPool(int count) => _objects = new T[count];

        public T this[int index] {
            get => _objects[index];
            set => _objects[index] = value;
        }

        public override string ToString() => $"{GetType().Name}<{typeof(T).Name}>";
    }
}