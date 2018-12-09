using System;

namespace Attributes
{
    public abstract class GroupAttribute : NaughtyAttribute
    {
        public string Name { get; private set; }

        public GroupAttribute(string name)
        {
            this.Name = name;
        }
    }
}
