using System;

namespace Attributes.Editor
{
    public class NativePropertyDrawerAttribute : BaseAttribute
    {
        public NativePropertyDrawerAttribute(Type targetAttributeType) : base(targetAttributeType)
        {
        }
    }
}
