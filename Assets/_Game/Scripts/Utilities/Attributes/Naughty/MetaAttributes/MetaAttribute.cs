using System;

namespace Attributes
{
    public abstract class MetaAttribute : NaughtyAttribute
    {
        public int Order { get; set; }
    }
}
