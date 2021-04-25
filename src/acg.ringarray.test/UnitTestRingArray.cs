using acg.ringarray.svc;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace acg.ringarray.test
{
    [ExcludeFromCodeCoverage]
    public class UnitTestRingArray
    {
        private readonly int[] _intValues = {5, 7, 11, 13, 15, 19, 5, 7, 32, 85, 46, 9, 64, 4, 95, 458 };
        private readonly long[] _longValues = {646436516876354, 78965413568574415, 9873254354163, 65435135468974684, 321359875, 46789123};
        private readonly string[] _stringValues = {"a1b2c3", "kkjjhh", "efg", "rmn", "foo", "bar", "world", "ghi",  "abc", "zzyyxx"};
        
        [Fact]
        public void IntRingArray_Equals_Fixed_16_7_3()
        {
            const int ringSize = 7;

            var ringArray = new IntRingArray(_intValues, ringSize);
	        var ringValues = ringArray.FillRingArray();

            Assert.Equal(64, ringValues[3]);
        }

        [Fact]
        public void IntRingArray_Equals_Fixed_16_12_7()
        {
            const int ringSize = 12;

            var ringArray = new IntRingArray(_intValues, ringSize);
	        var ringValues = ringArray.FillRingArray();

            Assert.Equal(9, ringValues[7]);
        }

        [Fact]
        public void LongRingArray_Equals_Fixed_6_4_2()
        {
            const int ringSize = 4;

            var ringArray = new LongRingArray(_longValues, ringSize);
            var ringValues = ringArray.FillRingArray();

            Assert.Equal(321359875, ringValues[2]);
        }

        [Fact]
        public void StringRingArray_Equals_Fixed_10_7_1()
        {
            const int ringSize = 7;

            var ringArray = new StringRingArray(_stringValues, ringSize);
            var ringValues = ringArray.FillRingArray();

            Assert.Equal("foo", ringValues[1]);
        }

        [Fact]
        public void StringRingArray_Equals_Fixed_10_10_5()
        {
            const int ringSize = 10;

            var ringArray = new StringRingArray(_stringValues, ringSize);
            var ringValues = ringArray.FillRingArray();

            Assert.Equal("bar", ringValues[5]);
        }
    }
}
