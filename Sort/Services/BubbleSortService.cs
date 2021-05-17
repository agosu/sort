using System.Collections;
using SortAPI.Helpers;

namespace SortAPI.Services
{
    public class BubbleSortService : ISortService
    {
        public ArrayList Sort(ArrayList numbers)
        {
            if (numbers != null)
            {
                for (var i = 0; i < numbers.Count - 1; i++)
                {
                    for (var j = 0; j < numbers.Count - 1; j++)
                    {
                        if ((long)numbers[j] > (long)numbers[j + 1])
                        {
                            numbers.Swap(j, j + 1);
                        }
                    }
                }
                return numbers;
            }

            return null;
        }

        public string GetName()
        {
            return "Bubble Sort";
        }
    }
}
