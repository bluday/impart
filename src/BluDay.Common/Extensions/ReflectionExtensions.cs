using System;
using System.Reflection;

namespace BluDay.Common.Extensions
{
    public static class ReflectionExtensions
    {
        public static Type GetEventParameterType(this MethodInfo source)
        {
            return source?.GetParameters()[1].ParameterType;
        }

        public static Type[] GetParameterTypes(this ConstructorInfo source)
        {
            if (source is null) return null;

            ParameterInfo[] parameters = source.GetParameters();

            var types = new Type[parameters.Length];

            for (int i = 0; i < types.Length; i++)
            {
                types[i] = parameters[i].ParameterType;
            }

            return types;
        }
    }
}