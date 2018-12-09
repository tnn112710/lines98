using System;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ShowIfAttribute : DrawConditionAttribute
    {
        public string ConditionName { get; private set; }

        public ShowIfAttribute(string conditionName)
        {
            this.ConditionName = conditionName;
        }
    }
}
