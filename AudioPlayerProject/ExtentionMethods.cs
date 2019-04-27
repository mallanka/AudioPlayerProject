using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayerProject
{
    public static class ExtentionMethods
    {
        public static List<Song> SortExtension(this List<Song> Songs)         //B7-Player2/2. SongListSort & L9-HW-Player-1/3. SortExtention
        {
            return Songs = Songs.OrderBy(si => si.Title).ToList();
        }
        static Random random = new Random();

        public static List<Song> ShuffleExtension(this List<Song> Songs)                                     //B7-Player1/2. SongsListShuffle
        {
            for (int i = 0; i < Songs.Count; i++)
            {
                Songs.Insert(random.Next(1, Songs.Count + 1), Songs[0]);
                Songs.RemoveAt(0);
            }

            return Songs;
        }

        public static string CutStringExtension(this string @string)                //L9-HW-Player-2/3. SubstringExtention
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
