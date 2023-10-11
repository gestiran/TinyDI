using System;
using System.Collections.Generic;

namespace TinyDI.Resolving {
    public interface IDependencyContainer {
        public Dictionary<Type, object> GetDependencies();
    }
}