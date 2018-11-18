using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonalPractice.HundredDoors.Crafter_Meetup
{
        // skuo@8thlight.com

    [TestClass]
    public class CrafterMeetupTrialTests
    {
    //100 doors in a row are all initially closed.You make
    //100 passes by the doors. The first time through, you
    //visit every door and toggle the door (if the door is
    //closed, you open it; if it is open, you close it).
    //The second time you only visit every 2nd door(door#2, 
    //#4, #6, ...). The third time, every 3rd door
    //(door #3, #6, #9, ...), etc, until you only visit
    //the 100th door.

    //Question: What isOpen are the doors in after the last pass? Which are open, which are closed?

        [TestMethod]
        public void ShouldOpenDoor()
        {
            // arrange
            Door door = new Door(false);

            // act
            door.ChangeState();

            // assert
            door.IsDoorOpen().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldCloseDoor()
        {
            // arrange
            Door door = new Door(true);

            // act
            door.ChangeState();

            // assert
            door.IsDoorOpen().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldOpenAllDoorsWalkedOnce()
        {
            // arrange
            DoorManager doorManager = new DoorManager();

            // act
            int actualDoorCount =  doorManager.OpenDoorCount(1);

            // assert
            actualDoorCount.Should().Be(100);
        }

        [TestMethod]
        public void ShouldHave50OpenDoorsWalkedTwice()
        {
            // arrange
            DoorManager doorManager = new DoorManager();

            // act
            int actualDoorCount = doorManager.OpenDoorCount(2);

            // assert
            actualDoorCount.Should().Be(50);
        }

        [TestMethod]
        public void ShouldOpenAllDoorsWalkedThreeTimes()
        {
            // arrange
            DoorManager doorManager = new DoorManager();

            // act
            int actualDoorCount = doorManager.OpenDoorCount(3);

            // assert
            actualDoorCount.Should().Be(50);
        }

        [TestMethod]
        public void ShouldOpenAllDoorsWalked100Times()
        {
            // arrange
            DoorManager doorManager = new DoorManager();

            // act
            int actualDoorCount = doorManager.OpenDoorCount(100);

            // assert
            actualDoorCount.Should().Be(9);
        }

        private class DoorManager
        {
            private readonly List<Door> _doorList;

            public DoorManager()
            {
                _doorList = new List<Door>();
                for (int i = 0; i < 100; i++)
                {
                    _doorList.Add(new Door(false));
                }
            }

            public int OpenDoorCount(int listWalks)
            {
                for (int i = 0; i < listWalks; i++)
                {
                    for (int doorIndex = 0; doorIndex < 100; doorIndex += 1 + i)
                    {
                        _doorList[doorIndex].ChangeState();
                    }
                }


                int openDoorCount = 0;
                foreach (Door door in _doorList)
                {
                    if (door.IsDoorOpen())
                    {
                        openDoorCount++;
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


            public bool IsDoorOpen()
            {
                return _isOpen == true;
            }
        }
    }
}
