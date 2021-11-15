using System;
using Xunit;
using ZooApps;
using ZooApps.Zoos;

namespace ZooAppTests
{
    public class ZooAppTest
    {
        [Fact]
        public void ShouldBeCreateZooApp()
        {
            var zooApp = new ZooApp();
            Assert.NotNull(zooApp);
        }
        [Fact]
        public void ShouldBeAddZoo()
        {
            var zooApp = new ZooApp();
            var zoo = new Zoo("Toronto");
            zooApp.AddZoo(zoo);
            Assert.Equal(zoo, zooApp.ZooList[0]);
        }
    }
}
