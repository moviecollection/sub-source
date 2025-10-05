using System.Threading.Tasks;
using PublicApiGenerator;
using VerifyXunit;
using Xunit;

namespace MovieCollection.SubSource.Tests;

public class PublicApiTests
{
    [Fact]
    public Task PublicApiShouldNotChange()
    {
        var publicApi = typeof(SubSourceService).Assembly
            .GeneratePublicApi();

        return Verifier.Verify(publicApi);
    }
}
