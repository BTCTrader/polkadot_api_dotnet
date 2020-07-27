namespace PolkaTest
{
    using Polkadot.Api;
    using Xunit;
    using Xunit.Abstractions;

    [Collection("Sequential")]
    public class GetSystemInfo
    {
        private readonly ITestOutputHelper output;

        public GetSystemInfo(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Ok()
        {
            using (IApplication app = PolkaApi.GetApplication())
            {
                app.Connect();
                var result = app.GetSystemInfo();

                Assert.True(result.ChainId.Length > 0);

                // Check chainName
                Assert.Equal("Parity Polkadot", result.ChainName);

                // Check version
                Assert.NotEqual(string.Empty, result.Version);

                // Check tokenSymbol
                Assert.Equal("KSM", result.TokenSymbol);

                // Check tokenDecimals
                Assert.Equal(12, result.TokenDecimals);

                output.WriteLine($"Chain id        : {result.ChainId}");
                output.WriteLine($"Chain name      : {result.ChainName}");
                output.WriteLine($"Version         : {result.Version}");
                output.WriteLine($"Token symbol    : {result.TokenSymbol}");
                output.WriteLine($"Token decimals  : {result.TokenDecimals}");

                app.Disconnect();
            }
        }
    }
}
