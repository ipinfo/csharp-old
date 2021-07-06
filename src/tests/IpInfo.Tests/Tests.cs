using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpInfo.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public async Task Test()
        {
            using var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await Task.Delay(TimeSpan.Zero, source.Token).ConfigureAwait(false);
        }
    }
}
