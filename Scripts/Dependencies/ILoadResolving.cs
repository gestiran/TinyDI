using TinyDI.Dependencies.Models;
using TinyDI.Dependencies.Parameters;

namespace TinyDI.Dependencies {
    public interface ILoadResolving : IModelsResolving, IParametersResolving {
        public void Load();
    }
}