using System;

namespace CodeKata.BinaryGap
{
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