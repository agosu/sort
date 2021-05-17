using SortAPI.Services;
using System.Collections;
using Xunit;

namespace SortTest
{
    public class SortTests
    {
        private readonly ISortService _bubbleSortService = new BubbleSortService();
        private readonly ISortService _selectionSortService = new SelectionSortService();

        //TODO: looks like there should be a better way to test multiple implementations

        [Theory]
        [InlineData(new long[] { 1, 3, 4, 2, 17, 9 }, new long[] { 1, 2, 3, 4, 9, 17})]
        [InlineData(new long[] { 1, 3, -11, 2, 0, 9 }, new long[] { -11, 0, 1, 2, 3, 9 })]
        [InlineData(new long[] { 1, 3, long.MaxValue, 0, long.MinValue }, new long[] { long.MinValue, 0, 1, 3, long.MaxValue })]
        [InlineData(new long[] { }, new long[] { })]
        [InlineData(new long[] { 0 }, new long[] { 0 })]
        public void TestBubbleSort(long[] input, long[] ordered)
        {
            ArrayList expected = new ArrayList(ordered);

            ArrayList result = _bubbleSortService.Sort(new ArrayList(input));

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new long[] { 1, 3, 4, 2, 17, 9 }, new long[] { 1, 2, 3, 4, 9, 17 })]
        [InlineData(new long[] { 1, 3, -11, 2, 0, 9 }, new long[] { -11, 0, 1, 2, 3, 9 })]
        [InlineData(new long[] { 1, 3, long.MaxValue, 0, long.MinValue }, new long[] { long.MinValue, 0, 1, 3, long.MaxValue })]
        [InlineData(new long[] { }, new long[] { })]
        [InlineData(new long[] { 0 }, new long[] { 0 })]
        public void TestSelectionSort(long[] input, long[] ordered)
        {
            ArrayList expected = new ArrayList(ordered);

            ArrayList result = _selectionSortService.Sort(new ArrayList(input));

            Assert.Equal(expected, result);
        }
    }
}
