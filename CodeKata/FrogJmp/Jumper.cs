using System;

namespace CodeKata.FrogJmp
{
    /// <summary>
    /// Solves https://app.codility.com/programmers/lessons/3-time_complexity/frog_jmp/
    /// </summary>
    public class Jumper
    {
        public int JumpCount(int x, int y, int d)
        {
            return JumpCount(new JumpInt(x), new JumpInt(y), new JumpInt(d));
        }

        public int JumpCount(JumpInt x, JumpInt y, JumpInt d)
        {
            if (x.Value > y.Value)
                throw new ArgumentException($"Starting point {x.Value} must not be greater than ending point {x.Value}");

            var distanceToJump = y - x;

            return (int)Math.Ceiling((double)distanceToJump / d.Value);
        }
    }
}