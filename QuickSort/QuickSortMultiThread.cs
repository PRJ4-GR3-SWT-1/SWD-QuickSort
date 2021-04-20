using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace QuickSort
{
    public class QuickSortMultiThread
    {
        public static void SerialQuicksort(long[] elements, long left, long right)
        {
            long i = left, j = right;
            var pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0) i++;
                while (elements[j].CompareTo(pivot) > 0) j--;

                if (i <= j)
                {
                    // Swap
                    var tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            Task kurt=null, ib=null;
            // Recursive calls
            if (left < j)
            {
                if (Math.Abs(j - left) > 10000) { 
                 kurt=Task.Run(() => SerialQuicksort(elements, left, j));
                }
                else
                {
                    SerialQuicksort(elements, left, j);
                }
            }

            if (i < right)
            {
                if (Math.Abs(right - i) > 10000)
                {
                    ib = Task.Run(() => SerialQuicksort(elements, i, right));
                }
                else
                {
                    SerialQuicksort(elements, i, right);
                }
            }

            if(kurt!=null&&ib!=null) Task.WaitAll(kurt, ib);
            else if (kurt != null) Task.WaitAll(kurt);
            else if (ib != null) Task.WaitAll(ib);



        }
    }
}
