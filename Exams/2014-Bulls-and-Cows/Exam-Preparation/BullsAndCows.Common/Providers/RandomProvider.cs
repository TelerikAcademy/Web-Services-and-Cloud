namespace BullsAndCows.Common.Providers
{
    using System;

    public class RandomProvider : IRandomProvider
    {
        private readonly static Random random = new Random();

        public int GetRandomNumber(int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }
}
