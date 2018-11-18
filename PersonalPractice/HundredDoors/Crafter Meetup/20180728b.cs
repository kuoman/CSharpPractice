using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonalPractice.HundredDoors.Crafter_Meetup
{
    [TestClass]
    public class CrafterMeetupTrialTestsB
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
        public void ShouldOpenDoor()
        {
            // arrange
            Door door = new Door(false);

            // act
            door.ChangeState();

            // assert
            door.IsOpen().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldCloseDoor()
        {
            // arrange
            Door door = new Door(true);

            // act
            door.ChangeState();

            // assert
            door.IsOpen().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldWalkListOnceAndOpenAllDoors()
        {
            // arrange
            DoorMan doorMan = new DoorMan();

            // act

            // assert
            doorMan.OpenDoorCount(1).Should().Be(100);
        }

        [TestMethod]
        public void ShouldWalkListTwiceAndCloseHalfTheDoors()
        {
            // arrange
            DoorMan doorMan = new DoorMan();

            // act

            // assert
            doorMan.OpenDoorCount(2).Should().Be(50);
        }

        [TestMethod]
        public void ShouldWalkList100Times()
        {
            // arrange
            DoorMan doorMan = new DoorMan();

            // act

            // assert
            doorMan.OpenDoorCount(100).Should().Be(9);
        }

        private class DoorMan
        {
            private readonly List<Door> _doorList;

            public DoorMan()
            {
                _doorList = new List<Door>();
                for (int i = 0; i < 100; i++)
                {
                    _doorList.Add(new Door(false));
                }
            }

            public int OpenDoorCount(int numberOfWalks)
            {
                for (int walkCount = 0; walkCount < numberOfWalks; walkCount++)
                {
                    for (int i = 0; i < _doorList.Count; i += walkCount + 1)
                    {
                        _doorList[i].ChangeState();
                    }
                }

                int openDoorCount = 0;
                foreach (Door door in _doorList)
                {
                    if (door.IsOpen())
                        ++ openDoorCount;
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
