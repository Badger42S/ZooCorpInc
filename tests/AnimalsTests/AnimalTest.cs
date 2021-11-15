using Animals.Bird;
using Animals.Mammal;
using ZooApps.Medicines;
using System.Collections.Generic;
using Xunit;

namespace AnimalsTests
{
    public class AnimalTest
    {
        [Fact]
        public void ShouldBeHasID()
        {
            var lion = new Lion();
            Assert.InRange(lion.ID, 0, int.MaxValue);
        }
        [Fact]
        public void ShouldBeHealed()
        {
            var bison = new Bison();
            Antibiotics antibiotics = new();
            bison.Heal(antibiotics);
            Assert.False(bison.IsSick);
            bison = new Bison();
            AntiDepression antiDepression = new();
            bison.Heal(antiDepression);
            Assert.False(bison.IsSick);
            bison = new Bison();
            AntiInflammatory antiInflammatory = new();
            bison.Heal(antiInflammatory);
            Assert.False(bison.IsSick);
        }
        [Theory]
        [InlineData(0, 23)]
        [InlineData(5, 20)]
        public void ShouldAddSchedule(int value1, int value2)
        {
            Penguin penguin = new Penguin();
            List<int> moreFeedTimes = new() { value1, value2 };
            penguin.AddSchedule(moreFeedTimes);
            Assert.Equal(value1, penguin.FeedSchedule[0]);
            Assert.Equal(value2, penguin.FeedSchedule[penguin.FeedSchedule.Count - 1]);
        }
    }
}
