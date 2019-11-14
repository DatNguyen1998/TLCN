using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GICBC.Common.Utilities
{
    public static class ReflectionHelper
    {
        public static IEnumerable<Type> GetTypesWithAttribute(Assembly assembly, Type attributeType)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(attributeType, true).Length > 0)
                {
                    yield return type;
                }
            }
        }
    }
}
