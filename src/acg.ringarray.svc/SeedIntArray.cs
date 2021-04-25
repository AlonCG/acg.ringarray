using System;

namespace acg.ringarray.svc
{
    public static class SeedIntArray
    {
        public static int[] Seed() => Seed(100, 1, 10000, 0);
        public static int[] Seed(int arraySize, int randomSeed) => Seed(arraySize, 1, 10000, randomSeed);
        public static int[] Seed(int arraySize, int lowerBound, int upperBound, int randomSeed)
         {
            var rng = (randomSeed > 0)
                ? new Random(randomSeed)
                : new Random();

            int[] values = new int[arraySize];
            for (var index = 0; index < arraySize; index++) {
                values[index] = rng.Next(lowerBound, upperBound);
            }

            return values;
        }
    }
}
