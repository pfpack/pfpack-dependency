#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public Dependency<T1, T2, T3, T4, T5, T6, T7> With<T4, T5, T6, T7>(
            Func<T4> fourth,
            Func<T5> fifth,
            Func<T6> sixth,
            Func<T7> seventh)
            =>
            InnerWith(
                fourth ?? throw new ArgumentNullException(nameof(fourth)),
                fifth ?? throw new ArgumentNullException(nameof(fifth)),
                sixth ?? throw new ArgumentNullException(nameof(sixth)),
                seventh ?? throw new ArgumentNullException(nameof(seventh)));

        private Dependency<T1, T2, T3, T4, T5, T6, T7> InnerWith<T4, T5, T6, T7>(
            Func<T4> fourth,
            Func<T5> fifth,
            Func<T6> sixth,
            Func<T7> seventh)
            =>
            new(
                firstResolver,
                secondResolver,
                thirdResolver,
                _ => fourth.Invoke(),
                _ => fifth.Invoke(),
                _ => sixth.Invoke(),
                _ => seventh.Invoke());
    }
}