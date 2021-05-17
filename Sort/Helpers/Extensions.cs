using System.Collections;

namespace SortAPI.Helpers
{
    public static class Extensions
    {
        public static void Swap(this ArrayList arrayList, int i, int j)
        {
            var temp = arrayList[i];
            arrayList[i] = arrayList[j];
            arrayList[j] = temp;
        }
    }
}
