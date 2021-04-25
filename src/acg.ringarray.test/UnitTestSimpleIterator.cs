using acg.ringarray.svc;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace acg.ringarray.test
{
    [ExcludeFromCodeCoverage]
    public class UnitTestSimpleIterator
    {
        [Fact]
        public void Iterator_Seed_150_Reset_GetCurrent_Exception() { 
            var array1 = SeedIntArray.Seed(10, 1, 10, 770);
            var enum1 = new SimpleIterator<int>(array1);

            if (!enum1.HasNext()) return;

            enum1.Next();
            // reset to throw an error
            enum1.Reset();
            Assert.Throws<InvalidOperationException>(() => enum1.Next());
           
            // <?> what should I do here ? Assert.True(false, "Enumerator not traversed.");
        }
        
        [Fact]
        public void Iterator_Seed_150_33_Equals() 
        {
            var value1 = -5; 
            var value2 = -55;
            var index = 0;
            
            var array1 = SeedIntArray.Seed(150, 1, 10, 55);
            var enum1 = new SimpleIterator<int>(array1);
            // get the 33rd item from iterable numbers
            while (enum1.HasNext()) {
                index++;
                if (index != 33) continue;
                value1 = Convert.ToInt32(enum1.Next());
                break;
            }

            index = 0;
            var array2 = SeedIntArray.Seed(150, 1, 10, 55);
            var enum2 = new SimpleIterator<int>(array2);
            while (enum2.HasNext()) {
                index++;
                if (index != 33) continue;
                value2 = Convert.ToInt32(enum2.Next());
                break;
            }
           
            Assert.Equal(value1, value2);
        }

                [Fact]
        public void Iterator_Seed_15000_3300_Equals() 
        {
            int value1 = -5; 
            int value2 = -55;
            var index = 0;
            
            var array1 = SeedIntArray.Seed(15000, 1, 1000, 55);
            var enum1 = new SimpleIterator<int>(array1);
            // get the 3300rd item from iterable numbers
            while (enum1.HasNext()) {
                index++;
                if (index != 3300) continue;
                value1 = Convert.ToInt32(enum1.Next());
                break;
            }

            index = 0;
            var array2 = SeedIntArray.Seed(15000, 1, 1000, 55);
            var enum2 = new SimpleIterator<int>(array2);
            while (enum2.HasNext()) {
                index++;
                if (index != 3300) continue;
                value2 = Convert.ToInt32(enum2.Next());
                break;
            }
            
            Assert.Equal(value1, value2);
        }

    }
}
