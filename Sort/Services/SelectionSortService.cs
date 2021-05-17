using System.Collections;
using SortAPI.Helpers;

namespace SortAPI.Services
{
    public class SelectionSortService : ISortService
    {
        public ArrayList Sort(ArrayList numbers)
        {
            for (var i = 0; i < numbers.Count - 1; i++)
            {
                var minimum = i;
                for (var j = i + 1; j < numbers.Count; j++)
                {
                    if ((long) numbers[j] < (long) numbers[minimum])
                    {
                        minimum = j;
                    }
                }
                numbers.Swap(minimum, i);
            }

            return numbers;
        }

        public string GetName()
        {
            return "Selection Sort";
        }
    }
}
