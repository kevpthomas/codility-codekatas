using Ardalis.GuardClauses;

namespace CodeKata.FrogJmp
{
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