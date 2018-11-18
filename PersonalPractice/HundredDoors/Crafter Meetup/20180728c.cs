using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonalPractice.HundredDoors.Crafter_Meetup
{
    [TestClass]
    public class CrafterMeetupTrialTestsC
    {
        //100 doors in a row are all initially closed.You make
        //100 passes by the doors. The first time through, you
        //visit every door and toggle the door (if the door is
        //closed, you open it; if it is open, you close it).
        //The second time you only visit every 2nd door(door#2, 
        //#4, #6, ...). The third time, every 3rd door
        //(door #3, #6, #9, ...), etc, until you only visit
        //the 100th door.

        //Question: What state are the doors in after the last pass? Which are open, which are closed?

        [TestMethod]
        public void ShouldChangeClosedDoorToOpen()
        {
            // arrange
            Door door = new Door(false);

            // act
            door.ChangeState();
            
            // assert
            door.IsOpen().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldChangeOpenDoorToClosed()
        {
            // arrange
            Door door = new Door(true);

            // act
            door.ChangeState();

            // assert
            door.IsOpen().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldOpenAllDoors()
        {
            // arrange
            DoorMan doorMan = new DoorMan();

            // act// assert
            doorMan.CountOpenDoors(1).Should().Be(100);
        }

        [TestMethod]
        public void ShouldResultIn50OpenDoorsWithTwoPasses()
        {
            // arrange
            DoorMan doorMan = new DoorMan();

            // act// assert
            doorMan.CountOpenDoors(2).Should().Be(50);
        }

        private class DoorMan
        {
            private readonly List<Door> _doors;

            public DoorMan()
            {
                _doors = new List<Door>();
                for (int i = 0; i < 100; i++)
                {
                    _doors.Add(new Door(false));
                }
            }
            public int CountOpenDoors(int walks)
            {
                for (int walk = 0; walk < walks; walk++)
                {
                    for (int i = 0; i < _doors.Count; i += walk + 1)
                    {
                        _doors[i].ChangeState();
                    }
                }

                int openDoorCount = 0;
                foreach (Door door in _doors)
                {
                    if (door.IsOpen())
                    {
                        ++openDoorCount;
                    }
                }

                return openDoorCount;
            }
        }

        private class Door
        {
            private bool _isOpen;

            public Door(bool isOpen)
            {
                _isOpen = isOpen;
            }

            public void ChangeState()
            {
                _isOpen = !_isOpen;
            }

            public bool IsOpen()
            {
                return _isOpen;
            }
        }
    }
}
