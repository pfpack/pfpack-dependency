namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5, T6>
{
    public Dependency<T1, T2, T3, T4, T5, T6, T7> With<T7>(
        T7 seventh)
        =>
        new(
            firstResolver,
            secondResolver,
            thirdResolver,
            fourthResolver,
            fifthResolver,
            sixthResolver,
            seventh);
}