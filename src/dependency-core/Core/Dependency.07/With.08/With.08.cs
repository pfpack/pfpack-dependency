namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5, T6, T7>
{
    public Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> With<TRest>(
        TRest rest)
        =>
        new(
            firstResolver,
            secondResolver,
            thirdResolver,
            fourthResolver,
            fifthResolver,
            sixthResolver,
            seventhResolver,
            _ => rest);
}