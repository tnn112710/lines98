using System;

namespace Attributes.Editor
{
    public class PropertyMetaAttribute : BaseAttribute
    {
        public PropertyMetaAttribute(Type targetAttributeType) : base(targetAttributeType)
        {
        }
    }
}
