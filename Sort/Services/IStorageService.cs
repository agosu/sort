using System.Collections;

namespace SortAPI.Services
{
    public interface IStorageService
    {
        public void StoreNewResult(ArrayList result);
        public void StorePerformance(long performance);
        public ArrayList GetLatestResult();
        public long GetLatestPerformance();
    }
}
