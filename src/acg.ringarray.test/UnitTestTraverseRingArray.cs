using acg.ringarray.svc;
using Xunit;

namespace acg.ringarray.test
{
    public class UnitTestTraverseRingArray
    {
        private static IntRingArray GetRingArray()
        {
            var values = new[] {5, 7, 11, 13, 15, 19, 5, 7, 32, 85, 46, 9, 64, 4, 95, 458 };
            const int ringSize = 16;
            
            // technically an array with the same size and values, does not have to be "ringed" up
            // this is for testing purposes only and travels through the Enumerator
            var ringArray = new IntRingArray(values, ringSize);

            return ringArray;
        }

        [Fact]
        public void TraverseRingArray_Equals_Fixed_16_5_0()
        {
            var ringArray = GetRingArray();

            var traverseRingArray = new TraverseIntRingArray(ringArray);
            const int steps = 5;
	        var traverseRing = traverseRingArray.Traverse(steps);

            Assert.Equal(19, traverseRing);
        }

        [Fact]
        public void TraverseRingArray_Equals_Fixed_16_405_0()
        {
            var ringArray = GetRingArray();

            var traverseRingArray = new TraverseIntRingArray(ringArray);
            const int steps = 405;
	        var traverseRing = traverseRingArray.Traverse(steps);

            Assert.Equal(19, traverseRing);
        }

        [Fact]
        public void TraverseRingArray_Equals_Fixed_16_405_100()
        {
            var ringArray = GetRingArray();

            var traverseRingArray = new TraverseIntRingArray(ringArray);
            const int steps = 405;
            const int startPosition = 100;
	        var traverseRing = traverseRingArray.Traverse(steps, startPosition);

            Assert.Equal(85, traverseRing);
        }

    }
}
