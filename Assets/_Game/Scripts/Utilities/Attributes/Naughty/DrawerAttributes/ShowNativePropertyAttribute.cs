using System;
using UnityEngine;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ShowNativePropertyAttribute : DrawerAttribute
    {

    }
}
