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
            Player player = new Player();

            Add(player.playlist,
                new Song("Song1"),
                new Song("Song2"),
                new Song("Song3"),
                new Song("Song4"),
                new Song("Song5"),
                new Song("Song6"),
                new Song("Song7"),
                new Song("Song8"),
                new Song("Song999999999999999999999999999"));


            player.Play(genre.Pop);

            Console.WriteLine();

            player.playlist.Songs = player.playlist.Songs.ShuffleExtension();

            player.Play(genre.Pop);

            Console.WriteLine();

            player.playlist.Songs = player.playlist.Songs.SortExtension();

            player.Play(genre.Pop);

            //L9-HW-Player-3/3. Song Deconstruction
            var song = new Song("SongWithDeconstruct");
            var (newDuration,_, newPath, newLyrics,_) = song;
            newDuration = 400;
            newPath = "highway to hell";
            newLyrics = "tears, crying";
            Console.WriteLine(newLyrics);
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
