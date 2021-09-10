using Moq;

namespace PrimeFuncPack.Tests
{
    public sealed partial class ServiceProviderExtensionsTest
    {        
        private static readonly IServiceProvider? NullServiceProvider = null;

        private static Mock<IServiceProvider> CreateMockServiceProvider(
            object? resultService)
        {
            var mock = new Mock<IServiceProvider>();

            _ = mock
                .Setup(sp => sp.GetService(It.IsAny<Type>()))
                .Returns(resultService);

            return mock;
        }
    }
}
