using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayerProject
{
    class Playlist
    {
        public string Path;
        public string Title;
        public List<Song> Songs = new List<Song>();

        Random random = new Random();
        public void Shuffle()                                     //B7-Player1/2. SongsListShuffle
        {
            for (int i = 0; i < Songs.Count; i++)
            {
                Songs.Insert(random.Next(1,Songs.Count + 1), Songs[0]);
                Songs.RemoveAt(0);
            }
        }

        public void SortByTitle()                                //B7-Player2/2. SongListSort
        {
            Songs = Songs.OrderBy(si => si.Title).ToList();
        }
    }
}
