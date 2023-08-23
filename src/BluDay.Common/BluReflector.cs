using BluDay.Common.Extensions;
using System;
using System.Reflection;

namespace BluDay.Common
{
    public static class BluReflector
    {
        public static Assembly CurrentAssembly { get; } = Assembly.GetExecutingAssembly();

        public static Type[] AssemblyTypes => CurrentAssembly.GetTypes();

        public static Type[] AbstractTypes  => AssemblyTypes.BluWhere(type => type.IsAbstract);
        public static Type[] ClassTypes     => AssemblyTypes.BluWhere(type => type.IsClass);
        public static Type[] ConcreteTypes  => AssemblyTypes.BluWhere(type => type.IsInstantiatable());
        public static Type[] EnumTypes      => AssemblyTypes.BluWhere(type => type.IsEnum);
        public static Type[] InterfaceTypes => AssemblyTypes.BluWhere(type => type.IsInterface);
        public static Type[] SealedTypes    => AssemblyTypes.BluWhere(type => type.IsSealed);
        public static Type[] StaticTypes    => AssemblyTypes.BluWhere(type => type.IsStatic());

        public static Type GetTypeByFullName(string name)
        {
            return AssemblyTypes.BluFirst(type => type.FullName == name);
        }

        public static Type[] GetDerivedConcreteClassTypes(Type[] baseTypes)
        {
            return ConcreteTypes.BluWhere(type => type.Inherits(baseTypes));
        }

        public static Type[] GetDerivedConcreteClassTypes<T1>() where T1 : class
        {
            return GetDerivedConcreteClassTypes(new[] { typeof(T1) });
        }

        public static Type[] GetDerivedConcreteClassTypes<T1, T2>()
            where T1 : class
            where T2 : class
        {
            return GetDerivedConcreteClassTypes(new[] { typeof(T1), typeof(T2) });
        }
    }
}