using System.Collections;

namespace SortAPI.Services
{
    public interface IStorageService
    {
        public void StoreNewResult(ArrayList result);
        public ArrayList GetLatestResult();
    }
}
