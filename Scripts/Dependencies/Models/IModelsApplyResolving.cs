namespace TinyDI.Dependencies.Models {
    public interface IModelsApplyResolving : IModelsResolving {
        public void ApplyModels();
    }
}