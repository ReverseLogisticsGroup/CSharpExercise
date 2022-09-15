using Xunit;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CSharpExercise.Tests
{
    public class RLGExtensions_Tests
    {

        bool positive(int x, int y)
        {
            return x > 0;
        }


        IEnumerable<int> FillEnumerable(int x)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < x; i++)
            {
                result.Add(i);
            }

            return result;
        }

        [Fact]
        public void RLGSelectUsingSelectMany()
        {
            var source = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var rlgResult = source.RLGSelect(x => x);
            var linqResult = source.SelectMany(x => FillEnumerable(10)).Select(x => x);

            Assert.Equal(linqResult, rlgResult);
        }

        [Fact]
        public void RLGWhereUsingSelectMany()
        {
            var source = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 ,9 ,10 };


            var rlgResult = source.RLGWhere(positive);
            var linqResult = source.SelectMany(x => FillEnumerable(10)).Where(positive);

            Assert.Equal(linqResult, rlgResult);
        }

    }
}
