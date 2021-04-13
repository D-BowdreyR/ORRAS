using System.Threading.Tasks;
using NUnit.Framework;


namespace ORRA.Application.IntegrationTests
{
    using static TestingUtility;
    public class TestBase
    {
        [SetUp]
        public async Task TestSetup() { await ResetState(); }
    }

}