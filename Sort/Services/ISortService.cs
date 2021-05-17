using System.Collections;

namespace SortAPI.Services
{
    public interface ISortService
    {
        public ArrayList Sort(ArrayList unsorted);
        public string GetName();
    }
}
