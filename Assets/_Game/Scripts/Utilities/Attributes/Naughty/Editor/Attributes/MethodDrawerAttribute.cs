using System;

namespace Attributes.Editor
{
    public class MethodDrawerAttribute : BaseAttribute
    {
        public MethodDrawerAttribute(Type targetAttributeType) : base(targetAttributeType)
        {
        }
    }
}
