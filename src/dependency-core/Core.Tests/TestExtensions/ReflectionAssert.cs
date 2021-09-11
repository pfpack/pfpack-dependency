using System.Reflection;
using static System.FormattableString;

namespace PrimeFuncPack.Tests
{
    internal static class ReflectionAssert
    {
        internal static ObsoleteAttribute IsStaticMethodObsolete(Type type, string methodName)
        {
            var methodInfo = type.GetMethod(methodName, BindingFlags.Static | BindingFlags.Public)
                ?? throw CreatePublicStaticMethodNotFoundException(type, methodName);

            var obsoleteAttribute = methodInfo.GetCustomAttribute<ObsoleteAttribute>()
                ?? throw CreateMethodNotObsoleteException(type, methodName);
            
            return obsoleteAttribute;
        }

        private static InvalidOperationException CreatePublicStaticMethodNotFoundException(Type type, string methodName)
            =>
            new(Invariant($"A public static method {methodName} was not found in the type {type}."));

        private static InvalidOperationException CreateMethodNotObsoleteException(Type type, string methodName)
            =>
            new(Invariant($"Method {methodName} of the type {type} is not obsolete."));
    }
}