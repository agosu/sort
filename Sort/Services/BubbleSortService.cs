using System.Collections;
using SortAPI.Helpers;

namespace SortAPI.Services
{
    public class BubbleSortService : ISortService
    {
        public ArrayList Sort(ArrayList numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int j = 0; j < numbers.Count - 1; j++)
                {
                    if ((long) numbers[j] > (long) numbers[j + 1])
                    {
                        numbers.Swap(j, j + 1);
                    }
                }
            }
            return numbers;
        }

        public string GetName()
        {
            return "Bubble Sort";
        }
    }
}
