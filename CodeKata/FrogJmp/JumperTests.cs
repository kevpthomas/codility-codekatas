using System;
using Ardalis.GuardClauses;
using NUnit.Framework;
using Shouldly;

namespace CodeKata.FrogJmp
{
    public class JumperTests : UnitTestBase<Jumper>
    {
        [TestCase(0)]
        [TestCase(1000000001)]
        public void GivenStartingPointOutOfRange(int x)
        {
            Should.Throw<ArgumentOutOfRangeException>(
                () => TestInstance.JumpCount(x, Faker.Random.Int(1, 1000000000), 1));
        }

        [TestCase(0)]
        [TestCase(1000000001)]
        public void GivenEndingPointOutOfRange(int y)
        {
            Should.Throw<ArgumentOutOfRangeException>(
                () => TestInstance.JumpCount(Faker.Random.Int(1, 1000000000), y, 1));
        }

        [TestCase(0)]
        [TestCase(1000000001)]
        public void GivenJumpDistanceOutOfRange(int d)
        {
            Should.Throw<ArgumentOutOfRangeException>(
                () => TestInstance.JumpCount(Faker.Random.Int(1, 1000000000), Faker.Random.Int(1, 1000000000), d));
        }

        [Test]
        public void GivenNegativeJumpDistance()
        {
            var x = Faker.Random.Int(2, 1000000000);
            var y = x - 1;

            Should.Throw<ArgumentException>(() => TestInstance.JumpCount(x, y, Faker.Random.Int(1, 1000000000)));
        }

        [Test]
        public void GivenJumpDistanceZero()
        {
            var x = Faker.Random.Int(1, 1000000000);

            TestInstance.JumpCount(x, x, Faker.Random.Int(1, 1000000000)).ShouldBe(0);
        }

        [Test]
        public void GivenExampleJumpDistance()
        {
            const int x = 10;
            const int y = 85;
            const int d = 30;

            TestInstance.JumpCount(x, y, d).ShouldBe(3);
        }
    }

    /// <summary>
    /// Data object to represent frog jump numbers
    /// </summary>
    /// <remarks>
    /// Avoids primitive obsession
    /// https://lostechies.com/jimmybogard/2007/12/03/dealing-with-primitive-obsession/
    /// </remarks>
    public class JumpInt
    {
        public JumpInt(int value)
        {
            Guard.Against.OutOfRange(value, nameof(value), 1, 1000000000);

            Value = value;
        }

        public int Value { get; }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator int(JumpInt jumpInt)
        {
            return jumpInt.Value;
        }

        public static explicit operator JumpInt(int value)
        {
            return new JumpInt(value);
        }
    }
}