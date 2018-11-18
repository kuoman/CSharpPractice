using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonalPractice.OneThreeFourSixTwentyFour
{
    [TestClass]
    public class OneThreeFourSixTwentyFourTests
    {
        private readonly List<Func<double, double, double>> _typesOfActions = new List<Func<double, double, double>> { AddTwo, SubtractTwo, MultiplyTwo, DivideTwo };
        private readonly List<double> _possibleValues = new List<double> { 1, 3, 4, 6 };

        [TestMethod]
        public void ShouldReturn24()
        {
            // arrange
            List<List<Func<double, double, double>>> actionPermutationList = CreateActionPermutationList();
            List<Func<double, double, double>> actions = actionPermutationList[55];

            List<List<double>> valuePermutationList = CreateValuePermutationList();

            List<double> set = valuePermutationList[8];

            // act
            double returnValue = ProcessSet(set, actions);

            // assert
            returnValue.Should().Be(24);
        }

        [TestMethod]
        public void ShouldPrintAllTriesAndSolution()
        {
            List<List<double>> valuePermutationList = CreateValuePermutationList();
            List<List<Func<double, double, double>>> actionPermutationList = CreateActionPermutationList();

            int valueWinner = -1;
            int actionWinner = -1;

            for (var valueIndex = 0; valueIndex < valuePermutationList.Count; valueIndex++)
            {
                for (var actionIndex = 0; actionIndex < actionPermutationList.Count; actionIndex++)
                {
                    double returnValue = ProcessSet(valuePermutationList[valueIndex], actionPermutationList[actionIndex]);

                    if (returnValue == 24)
                    {
                        valueWinner = valueIndex;
                        actionWinner = actionIndex;
                        Debug.WriteLine($"==>>SUCCESS<<== Numeric values of {valuePermutationList[valueIndex][0]}, {valuePermutationList[valueIndex][1]}, {valuePermutationList[valueIndex][2]}, {valuePermutationList[valueIndex][3]} with operator order of {actionPermutationList[actionIndex][0].Method.Name}, {actionPermutationList[actionIndex][1].Method.Name}, {actionPermutationList[actionIndex][2].Method.Name}");
                    }
                    else
                    {
                        Debug.WriteLine($"fail == Numeric values of {valuePermutationList[valueIndex][0]}, {valuePermutationList[valueIndex][1]}, {valuePermutationList[valueIndex][2]}, {valuePermutationList[valueIndex][3]} with operator order of {actionPermutationList[actionIndex][0].Method.Name}, {actionPermutationList[actionIndex][1].Method.Name}, {actionPermutationList[actionIndex][2].Method.Name}");
                    }
                }
            }

            valueWinner.Should().NotBe(-1);
            actionWinner.Should().NotBe(-1);
        }

        [TestMethod]
        public void ShouldPrintJustSolution()
        {
            List<List<double>> valuePermutationList = CreateValuePermutationList();
            List<List<Func<double, double, double>>> actionPermutationList = CreateActionPermutationList();

            int valueWinner = -1;
            int actionWinner = -1;

            for (var valueIndex = 0; valueIndex < valuePermutationList.Count; valueIndex++)
            {
                for (var actionIndex = 0; actionIndex < actionPermutationList.Count; actionIndex++)
                {
                    double returnValue = ProcessSet(valuePermutationList[valueIndex], actionPermutationList[actionIndex]);

                    if (returnValue == 24)
                    {
                        valueWinner = valueIndex;
                        actionWinner = actionIndex;
                        Debug.WriteLine($"==>>SUCCESS<<== Numeric values of {valuePermutationList[valueIndex][0]}, {valuePermutationList[valueIndex][1]}, {valuePermutationList[valueIndex][2]}, {valuePermutationList[valueIndex][3]} with operator order of {actionPermutationList[actionIndex][0].Method.Name}, {actionPermutationList[actionIndex][1].Method.Name}, {actionPermutationList[actionIndex][2].Method.Name}");
                    }
                }
            }

            valueWinner.Should().NotBe(-1);
            actionWinner.Should().NotBe(-1);
        }

        [TestMethod]
        public void ShouldNotDuplicateValues()
        {
            List<List<double>> valuePermutationList = CreateValuePermutationList();

            foreach (List<double> values in valuePermutationList)
            {
                values.Should().Contain(1d);
                values.Should().Contain(3d);
                values.Should().Contain(4d);
                values.Should().Contain(6d);
                values.Should().HaveCount(4);
            }
        }

        [TestMethod]
        public void ShouldAddThreeActions()
        {
            List<List<Func<double, double, double>>> actionPermutationList = CreateActionPermutationList();

            foreach (List<Func<double, double, double>> actionSet in actionPermutationList)
            {
                actionSet.Should().HaveCount(3);
            }
        }

        [TestMethod]
        public void ShouldCreate64ActionSets()
        {
            List<List<Func<double, double, double>>> actionPermutationList = CreateActionPermutationList();

            actionPermutationList.Should().HaveCount(64);
        }

        [TestMethod]
        public void ShouldAdd24ActionSets()
        {
            List<List<Func<double, double, double>>> actionPermutationList = CreateActionPermutationList();

            foreach (List<Func<double, double, double>> actionSet in actionPermutationList)
            {
                actionSet.Should().HaveCount(3);
            }

        }

        [TestMethod]
        public void ShouldPerformAdditionToFourNumbers()
        {
            // arrange
            List<double> set = new List<double>{1, 3, 4, 6};
            List<Func<double, double, double>> actions = new List<Func<double, double, double>> { AddTwo };

            // act
            double result = actions[0].Invoke(set[0], set[1]);

            // assert
            result.Should().Be(4);
        }

        [TestMethod]
        public void ShouldAddTwoNumbersFromSet()
        {
            // arrange
            List<double> set = new List<double> { 1, 3, 4, 6 };
            List<Func<double, double, double>> actions = new List<Func<double, double, double>> { AddTwo, AddTwo, AddTwo };

            // act
            double result = ProcessSet(set[0], set[1], actions);

            // assert
            result.Should().Be(4);
        }

        [TestMethod]
        public void ShouldAddFourNumbersFromSet()
        {
            // arrange
            List<double> set = new List<double> { 1, 3, 4, 6 };
            List<Func<double, double, double>> actions = new List<Func<double, double, double>> { AddTwo, AddTwo, AddTwo };

            // act
            double result = ProcessSet(set, actions);

            // assert
            result.Should().Be(14);
        }

        [TestMethod]
        public void ShouldMuliplyTwoNumbers()
        {
            MultiplyTwo(1, 2).Should().Be(2);
        }

        [TestMethod]
        public void ShouldMuliplyTwoNumbersTriangulate()
        {
            MultiplyTwo(3, 2).Should().Be(6);
        }

        [TestMethod]
        public void ShouldAddTwoNunmbers()
        {
            AddTwo(1, 2).Should().Be(3);
        }

        [TestMethod]
        public void ShouldAddTwoNunmbersTriangulate()
        {
            AddTwo(3, 2).Should().Be(5);
        }

        [TestMethod]
        public void ShouldSubtractTwoNunmbers()
        {
            SubtractTwo(1, 2).Should().Be(-1);
        }

        [TestMethod]
        public void ShouldSubtractTwoNunmbersTriangulate()
        {
            SubtractTwo(3, 2).Should().Be(1);
        }

        [TestMethod]
        public void ShouldDividewoNunmbers()
        {
            DivideTwo(1, 2).Should().Be(.5d);
        }

        [TestMethod]
        public void ShouldDivideTwoNunmbersTriangulate()
        {
            DivideTwo(4, 2).Should().Be(2);
        }

        private List<List<Func<double, double, double>>> CreateActionPermutationList()
        {
            List<List<Func<double, double, double>>> permutationList = new List<List<Func<double, double, double>>>();

            foreach (Func<double, double, double> operation1 in _typesOfActions)
            {
                foreach (Func<double, double, double> operation2 in _typesOfActions)
                {
                    foreach (Func<double, double, double> operation3 in _typesOfActions)
                    {
                        permutationList.Add(new List<Func<double, double, double>> { operation1, operation2, operation3 });
                    }
                }
            }
            return permutationList;
        }

        private List<List<double>> CreateValuePermutationList()
        {
            List<List<double>> valueList = new List<List<double>>();

            foreach (double position1 in _possibleValues)
            {
                foreach (double position2 in _possibleValues)
                {
                    foreach (double position3 in _possibleValues)
                    {
                        foreach (double position4 in _possibleValues)
                        {
                            if (position1 != position2 && position1 != position3 && position1 != position4
                                && position2 != position3 && position2 != position4 && position3 != position4)
                            {
                                valueList.Add(new List<double> { position1, position2, position3, position4 });
                            }

                        }
                    }
                }
            }

            return valueList;
        }

        private double ProcessSet(List<double> set, List<Func<double, double, double>> actions)
        {
            double returnValue = actions[0].Invoke(set[0], set[1]);
            returnValue = actions[1].Invoke(set[2], returnValue);
            return actions[2].Invoke(set[3], returnValue);
        }

        private double ProcessSet(double value1, double value2, List<Func<double, double, double>> actions) => actions[0].Invoke(value1, value2);

        private static double DivideTwo(double value1, double value2) => value1 / value2;

        private static double SubtractTwo(double value1, double value2) => value1 - value2;

        private static double AddTwo(double value1, double value2) => value1 + value2;

        private static double MultiplyTwo(double value1, double value2) => value1 * value2;
    }
}
