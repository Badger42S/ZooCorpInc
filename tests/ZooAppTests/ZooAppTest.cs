using System;
using System.IO;
using System.Text.RegularExpressions;
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
        [Fact]
        public void ShouldBePrintAddZooMessage()
        {
            var zooApp = new ZooApp();
            var zoo = new Zoo("Toronto");
            var outputPoint = new StringWriter();
            Console.SetOut(outputPoint);
            string outputMessage = $"{zoo.Location} zoo was added to application";
            zooApp.AddZoo(zoo);
            Assert.Equal(outputMessage, Regex.Replace(outputPoint.ToString(), @"[\r\t\n]+", string.Empty));
        }
    }
}
