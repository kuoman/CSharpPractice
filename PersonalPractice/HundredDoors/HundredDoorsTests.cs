using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace PersonalPractice.HundredDoors
{
    [TestClass]
    public class HundredDoorsTests
    {
        [TestMethod]
        public void ShouldReturnProperDoorOpenStatus()
        {
            // arrange
            Door door = new Door(1);
            door.ActionMe();

            // act
            door.IsOpen().Should().Be(true);
        }

        [TestMethod]
        public void ShouldReturnProperDoorClosedStatus()
        {
            // arrange
            Door door = new Door(1);
            door.ActionMe();
            door.ActionMe();

            // act
            door.IsOpen().Should().Be(false);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldActionDoorOpen()
        {
            // arrange
            Door door = new Door(1);

            // act
            door.ActionMe();

            // assert
            door.IsOpen().Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldActionDoorClosed()
        {
            // arrange
            Door door = new Door(1);
            door.ActionMe();

            // act
            door.ActionMe();

            // assert
            door.IsOpen().Should().BeFalse();
        }


        [TestMethod, TestCategory("Unit")]
        public void ShouldActionDoors()
        {
            // arrange
            DoorManager doorManager = new DoorManager(5);

            // act
            doorManager.ActionAllDoors();

            // assert
            doorManager.OpenDoorCount().Should().Be(2);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnOpenDoors()
        {
            // arrange
            DoorManager doorManager = new DoorManager(5);
            doorManager.ActionAllDoors();

            // act
            List<int> openDoorPositions = doorManager.OpenDoorPositions();

            // assert
            openDoorPositions.Should().Contain(1);
            openDoorPositions.Should().Contain(4);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnOpenDoorsz()
        {
            // arrange
            DoorManager doorManager = new DoorManager(100);
            doorManager.ActionAllDoors();

            // act
     //       List<int> openDoorPositions = doorManager.OpenDoorPositions();

            // assert
    //        bool blah = true;
        }

        private class DoorManager
        {
            private readonly List<Door> _doors;

            public DoorManager(int numberOfDoors)
            {
                _doors = new List<Door>();

                for (int i = 0; i < numberOfDoors; i++)
                {
                    _doors.Add(new Door(i + 1));
                }
            }


            public void ActionAllDoors()
            {
                for (int i = 0; i < _doors.Count; i += 1)
                {
                    ActionDoors(i);
                }
            }

            private void ActionDoors(int offset)
            {
                for (int i = offset; i < _doors.Count; i += 1 + offset)
                {
                    _doors[i].ActionMe();
                }
            }

            public int OpenDoorCount() => _doors.Count(x => x.IsOpen());

            public List<int> OpenDoorPositions() => _doors.Where(x => x.IsOpen()).Select(x => x.DoorPosition).ToList();
        }

        private class Door
        {
            private bool _isOpen;

            public int DoorPosition { get; }

            public Door(int doorPosition)
            {
                DoorPosition = doorPosition;
            }

            public bool IsOpen()
            {
                return _isOpen;
            }

            public void ActionMe()
            {
                _isOpen = !_isOpen;
            }
        }
    }

    
}
