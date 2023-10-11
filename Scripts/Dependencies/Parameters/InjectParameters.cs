using System;

namespace TinyDI.Dependencies.Parameters {
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class InjectParameters : Inject { }
}