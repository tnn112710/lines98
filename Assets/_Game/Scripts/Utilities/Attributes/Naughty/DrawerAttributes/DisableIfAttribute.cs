using System;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class DisableIfAttribute : DrawerAttribute
    {
        public string ConditionName { get; private set; }

        public DisableIfAttribute(string conditionName)
        {
            this.ConditionName = conditionName;
        }
    }
}
