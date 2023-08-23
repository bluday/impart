using BluDay.Common.Domain.ViewModels;
using System;
using System.Collections.Generic;

namespace BluDay.Common.Extensions
{
    public static class TypeExtensions
    {
        public static IReadOnlyDictionary<Type, object> BluBulkInvokeGenericMethod(
            this   Type               source,
                   string             methodName,
                   object             instance,
                   Type[]             targetTypes,
                   Func<Type, Type[]> argumentTypesSelector = null,
            params object[]           parameters)
        {
            if (source is null) return null;

            argumentTypesSelector = argumentTypesSelector ?? (type => new[] { type });

            var results = new Dictionary<Type, object>();

            System.Reflection.MethodInfo info = source.GetMethod(methodName);

            foreach (var type in targetTypes)
            {
                object result;

                try
                {
                    result = info
                        .MakeGenericMethod(argumentTypesSelector(type))
                        .Invoke(instance, parameters);
                }
                catch (Exception ex)
                {
                    result = ex;
                }

                results.Add(type, result);
            }

            return results;
        }

        public static TResult BluInstantiate<TResult>(
            this Type     source,
                 object[] parameters       = null,
                 int      constructorIndex = 0
        )
            where TResult : class
        {
            if (source is null) return null;

            return source
                .GetConstructors()
                .BluAtIndex(constructorIndex)?
                .Invoke(parameters) as TResult;
        }

        public static bool Inherits(this Type source, Type baseType)
        {
            return baseType.IsAssignableFrom(source);
        }

        public static bool Inherits(this Type source, Type[] baseTypes)
        {
            return baseTypes.BluAll(baseType => source.Inherits(baseType));
        }

        public static bool Inherits<T>(this Type source)
        {
            return source.Inherits(typeof(T));
        }

        public static bool IsEnumerable(this Type source)
        {
            return source.Inherits<System.Collections.IEnumerable>();
        }

        public static bool IsInstantiatable(this Type source)
        {
            return source.IsClass && !source.IsAbstract;
        }

        public static bool IsStatic(this Type source)
        {
            return source.IsAbstract && source.IsClass && source.IsSealed;
        }

        public static bool IsView(this Type source)
        {
            return source.Inherits<UI.IBluView>();
        }

        public static bool IsViewModel(this Type source)
        {
            return source.Inherits<IBluViewModel>();
        }
    }
}