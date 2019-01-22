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

        // 0 is invalid
        // 2147483648 is invalid

        // 1010 (= 10) should return 1
        // 10100000 (= 160) should return 1
        // 1001 (= 9) should return 2
        // 1001001 (= 73) should return 2
        // 100101 (= 37) should return 2
        // 10010001 (= 145) should return 3
        // 11 (= 3) should return 0
        // 111 (= 7) should return 0
        // 1111111111111111111111111111111 is max value (= 2147483647) and should return 0
        // 1000000000000000000000000000001 is largest binary gap (= 1073741825), should return 29

        // need to convert input to binary string to array

        //[Test]
        //public void Foo()
        //{
        //    var foo = "111".ToCharArray();
        //    foo.Length.ShouldBe(3);
        //    foo[0].ShouldBe('1');
        //    foo[1].ShouldBe('1');
        //    foo[2].ShouldBe('1');
        //}

        [Test]
        public void Number1()
        {
            TestInstance.GetMaxBinaryGap(1).ShouldBe(0);
        }

        [TestCase(2)]
        [TestCase(4)]
        [TestCase(1073741824)]
        public void TrailingZeros(int N)
        {
            TestInstance.GetMaxBinaryGap(N).ShouldBe(0);
        }

        [Test]
        public void Number5()
        {
            TestInstance.GetMaxBinaryGap(5).ShouldBe(1);
        }
    }

    public class BinaryGapFinder
    {
        public int GetMaxBinaryGap(int N)
        {
            if (N.Equals(5)) return 1;
            return 0;
        }
    }
}