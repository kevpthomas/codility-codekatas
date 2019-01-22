using System;
using NUnit.Framework;
using Shouldly;

namespace CodeKata.BinaryGap
{
    // https://app.codility.com/programmers/lessons/1-iterations/binary_gap/
    public class BinaryGapFinderTests : UnitTestBase<BinaryGapFinder>
    {
        /*
         * A binary gap within a positive integer N is any maximal sequence of consecutive zeros
         * that is surrounded by ones at both ends in the binary representation of N.
         *
         * Need a function that accepts an integer and returns the largest binary gap in that integer,
         * or returns 0 if there is no binary gap.
         * Integer in range 1 to 2147483647
         */

        [Test]
        public void Number0()
        {
            Should.Throw<ArgumentException>(() => TestInstance.GetMaxBinaryGap(0));
        }

        [Test]
        public void Number1()
        {
            TestInstance.GetMaxBinaryGap(1).ShouldBe(0);
        }

        [TestCase(2)]          // 10
        [TestCase(4)]          // 100
        [TestCase(1073741824)] // 1000000000000000000000000000000
        public void Leading1_WithTrailingZeros(int N)
        {
            TestInstance.GetMaxBinaryGap(N).ShouldBe(0);
        }

        [Test]
        public void Number3()
        {
            TestInstance.GetMaxBinaryGap(3).ShouldBe(0);
        }

        [Test]
        public void Number7()
        {
            TestInstance.GetMaxBinaryGap(7).ShouldBe(0);
        }

        [Test]
        public void Number5()
        {
            TestInstance.GetMaxBinaryGap(5).ShouldBe(1);
        }

        [Test]
        public void Number9()
        {
            TestInstance.GetMaxBinaryGap(9).ShouldBe(2);
        }

        [Test]
        public void Number10()
        {
            TestInstance.GetMaxBinaryGap(10).ShouldBe(1);
        }
        
        [Test]
        public void Number37()
        {
            TestInstance.GetMaxBinaryGap(37).ShouldBe(2);
        }

        [Test]
        public void Number73()
        {
            TestInstance.GetMaxBinaryGap(73).ShouldBe(2);
        }

        [Test]
        public void Number145()
        {
            TestInstance.GetMaxBinaryGap(145).ShouldBe(3);
        }

        [Test]
        public void LargestPossibleBinaryGap()
        {
            TestInstance.GetMaxBinaryGap(1073741825).ShouldBe(29);
        }

        [Test]
        public void LargestInput()
        {
            TestInstance.GetMaxBinaryGap(int.MaxValue).ShouldBe(0);
        }

        [Test]
        public void CodilitySample32()
        {
            TestInstance.GetMaxBinaryGap(32).ShouldBe(0);
        }

        [Test]
        public void CodilitySample1041()
        {
            TestInstance.GetMaxBinaryGap(1041).ShouldBe(5);
        }
    }

    public class BinaryGapFinder
    {
        public int GetMaxBinaryGap(int N)
        {
            if (N <= 0) throw new ArgumentException($"The supplied value must be at least 1, but was {N}", nameof(N));

            var binaryCharArray = Convert.ToString(N, 2).ToCharArray();

            var len = binaryCharArray.Length;
            var max = 0;
            var tempMax = 0;
            var hasGap = false;

            for (var i = len - 1; i >= 0; i--)
            {
                if (hasGap)
                {
                    if (binaryCharArray[i] == '1')
                    {
                        tempMax = 0;
                    }
                }
                else
                {
                    if (binaryCharArray[i] == '1') hasGap = true;
                }

                if (hasGap && binaryCharArray[i] == '0')
                    tempMax += 1;

                if (tempMax > max) max = tempMax;
            }

            return max;
        }
    }
}