using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayerProject
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        public static void Add(Playlist playlist, params Song[] songList)
        {
            for (int i = 0; i < songList.Length; i++)
            {
                playlist.Songs.Add(songList[i]);
            }
        }
    }
}
