using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro_chess
{
    static class ExtentionMethods
    {
        public static List<T> TakeLast<T>(this List<T> ts, int count)
        {
            List<T> returnList = new List<T>();

            for (int i = 1; i <= count; i++)
            {
                returnList.Add(ts[ts.Count - i]);
            }

            returnList.Reverse();

            return returnList;
        }

        public static bool SequenceEqual<T>(this IEnumerable<T> first, IEnumerable<T>[] sequences)
        {
            bool match = false;

            foreach (IEnumerable<T> item in sequences)
            {
                match = first.Count() == item.Count();

                for (int i = 0; i < first.Count(); i++)
                {
                    match = first.ElementAt(i).ToString() == item.ElementAt(i).ToString();

                    if (!match)
                        return match;
                }
            }

            return match;
        }        
    }
}
