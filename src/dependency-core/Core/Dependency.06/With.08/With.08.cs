namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5, T6>
{
    public Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> With<T7, TRest>(
        T7 seventh,
        TRest rest)
        =>
        new(
            firstResolver,
            secondResolver,
            thirdResolver,
            fourthResolver,
            fifthResolver,
            sixthResolver,
            seventh,
            rest);
}