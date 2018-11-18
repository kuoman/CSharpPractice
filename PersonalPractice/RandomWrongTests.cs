using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PersonalPractice
{
    [TestClass]
    public class RandomWrongTests
    {
        [TestMethod]
        public void ShouldRollRandomWrong()
        {

            int rand1 = new Random().Next();

           // Thread.Sleep(10);

            int rand2 = new Random().Next();

            rand2.Should().Be(rand1);

        }

        [TestMethod]
        public void ShouldRollRandomSafelyDifferent()
        {
            Random random = new Random();
            int rand1 = random.Next();

            // Thread.Sleep(10);

            int rand2 = random.Next();

            rand2.Should().NotBe(rand1);

        }

        //[TestMethod]
        //public void ShouldRollRandomSafely()
        //{

        //    int rand1 = new Random().Next((int)DateTime.Now.Ticks);

        //   // Thread.Sleep(10);

        //    int rand2 = new Random().Next((int)DateTime.Now.Ticks);

        //    rand2.Should().NotBe(rand1);
        //}
    }
}
