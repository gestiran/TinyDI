using System;

namespace TinyDI.Dependencies.Models {
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class InjectModel : Inject { }
}