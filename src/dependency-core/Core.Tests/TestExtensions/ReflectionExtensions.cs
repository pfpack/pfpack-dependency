using System;
using System.Linq;
using System.Reflection;
using static System.FormattableString;

namespace PrimeFuncPack.Tests;

internal static class ReflectionExtensions
{
    internal static MethodInfo GetPublicStaticMethodOrThrow(this Type type, string name, int genericParameterCount, Type[] types)
        =>
        type.GetMethod(
            name: name,
            genericParameterCount: genericParameterCount,
            bindingAttr: BindingFlags.Static | BindingFlags.Public,
            binder: default,
            types: types,
            modifiers: default)
        ?? throw CreatePublicStaticMethodNotFoundException(type, name);

    internal static MethodInfo GetPublicStaticMethodOrThrow(this Type type, string name, int genericParameterCount)
        =>
        type.GetMethods(
            BindingFlags.Static | BindingFlags.Public)
        .Where(
            m => string.Equals(m.Name, name, StringComparison.InvariantCulture))
        .FirstOrDefault(
            m => m.GetGenericArguments()?.Length == genericParameterCount)
        ?? throw CreatePublicStaticMethodNotFoundException(type, name);

    internal static ObsoleteAttribute GetObsoleteAttributeOrThrow(this MethodInfo methodInfo)
        =>
        methodInfo.GetCustomAttribute<ObsoleteAttribute>() ?? throw CreateMethodNotObsoleteException(methodInfo);

    private static InvalidOperationException CreatePublicStaticMethodNotFoundException(Type type, string methodName)
        =>
        new(Invariant($"A public static method \"{methodName}\" was not found in the type \"{type}\"."));

    private static InvalidOperationException CreateMethodNotObsoleteException(MethodInfo methodInfo)
        =>
        new(Invariant($"Method \"{methodInfo}\" is not obsolete."));
}
