﻿using System;

namespace Attributes.Editor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public abstract class BaseAttribute : Attribute, IAttribute
    {
        private Type targetAttributeType;

        public BaseAttribute(Type targetAttributeType)
        {
            this.targetAttributeType = targetAttributeType;
        }

        public Type TargetAttributeType
        {
            get
            {
                return this.targetAttributeType;
            }
        }
    }
}
