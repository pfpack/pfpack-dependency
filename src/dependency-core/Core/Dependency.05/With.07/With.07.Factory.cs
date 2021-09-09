#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5>
    {
        public Dependency<T1, T2, T3, T4, T5, T6, T7> With<T6, T7>(
            Func<T6> sixth,
            Func<T7> seventh)
            =>
            InnerWith(
                sixth ?? throw new ArgumentNullException(nameof(sixth)),
                seventh ?? throw new ArgumentNullException(nameof(seventh)));

        private Dependency<T1, T2, T3, T4, T5, T6, T7> InnerWith<T6, T7>(
            Func<T6> sixth,
            Func<T7> seventh)
            =>
            new(
                firstResolver,
                secondResolver,
                thirdResolver,
                fourthResolver,
                fifthResolver,
                _ => sixth.Invoke(),
                _ => seventh.Invoke());
    }
}