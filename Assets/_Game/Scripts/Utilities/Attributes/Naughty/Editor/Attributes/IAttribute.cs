using System;

namespace Attributes.Editor
{
    public interface IAttribute
    {
        Type TargetAttributeType { get; }
    }
}
