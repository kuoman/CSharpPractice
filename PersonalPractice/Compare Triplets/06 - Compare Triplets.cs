using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonalPractice.Compare_Triplets
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldEvaluateWinForA()
        {
            // arrange


            // act
            int result = Evaluate(1, 2);

            // assert
            result.Should().Be(1);
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldEvaluateWinForB()
        {

            // act
            int result = Evaluate(2, 1);

            // assert
            result.Should().Be(0);

        }
        private int Evaluate(int a, int b)
        {
            if (b < a) return 0;


            return 1;
        }
    }
}
