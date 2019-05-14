using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayerProject
{
    public static class ExtentionMethods
    {
        public static List<Song> SortExtension(this List<Song> L)
        {
            return L = L.OrderBy(si => si.Title).ToList();
        }
        static Random random = new Random();

        public static List<Song> ShuffleExtension(this List<Song> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                l.Insert(random.Next(1, l.Count + 1), l[0]);
                l.RemoveAt(0);
            }

            return l;
        }

        public static string CutStringExtension(this string @string)
        {
            if (@string.Length > 10)
            {
                string newShortString = @string.Remove(10).Insert(10, "...");
                return newShortString;
            }

            return @string;
        }
    }
}
