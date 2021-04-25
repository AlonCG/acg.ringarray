using acg.ringarray.svc;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace acg.ringarray.test
{
    [ExcludeFromCodeCoverage]
    public class UnitTestSeedArray
    {
        [Fact]
        public void Random_Seed_5_Equals() {
            var array1 = SeedIntArray.Seed(100, 15);
            var array2 = SeedIntArray.Seed(100, 15);

            Assert.Equal(array1[5], array2[5]);
        }

        [Fact]
        public void Random_Seed_5_NotEquals() {
            var array1 = SeedIntArray.Seed();   // random seeded, size 100 array
            var array2 = SeedIntArray.Seed();

            Assert.NotEqual(array1[5], array2[5]);
        }

        [Fact]
        public void Random_Seed_40_Equals() {
            var array1 = SeedIntArray.Seed(100, 15);
            var array2 = SeedIntArray.Seed(100, 15);

            Assert.Equal(array1[40], array2[40]);
        }

        [Fact]
        public void Random_Seed_6241_Equals() {
            var array1 = SeedIntArray.Seed(10000, 150);
            var array2 = SeedIntArray.Seed(10000, 150);

            Assert.Equal(array1[6241], array2[6241]);
        }
    }
}
