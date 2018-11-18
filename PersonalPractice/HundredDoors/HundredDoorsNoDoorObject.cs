using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PersonalPractice.HundredDoors
{
    [TestClass]
    public class HundredDoorsNoDoorObject
    {
        [TestMethod]
        public void ShouldToggleSetOneDoor()
        {
            List<bool> doors = new List<bool> {false, false, false, false, false};

            ActionDoors(doors);

            doors[0].Should().BeTrue();
            doors[0].Should().BeTrue();
            doors[0].Should().BeTrue();
            doors[0].Should().BeTrue();
            doors[0].Should().BeTrue();
        }

        [TestMethod]
        public void ShouldToggleDoor()
        {
            List<bool> doors = new List<bool> { false, false, false, false, false };

            ActionDoors(doors);

            doors[0].Should().BeTrue();
            doors[1].Should().BeFalse();
            doors[2].Should().BeFalse();
            doors[3].Should().BeTrue();
            doors[4].Should().BeFalse();
        }

        private void ActionDoors(List<bool> doors)
        {
            for (int i = 0; i < doors.Count; i++)
            {
                OpenCloseDoors(doors, i);
            }
        }

        private static void OpenCloseDoors(List<bool> doors, int i)
        {
            for (int index = i; index < doors.Count; index += i + 1)
            {
                doors[index] = !doors[index];
            }
        }
    }

}
