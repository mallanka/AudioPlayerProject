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
                new Song("Song9"));

            player.Play(false);

            Console.WriteLine();

            player.playlist.Shuffle();

            player.Play(false);

            Console.WriteLine();

            player.playlist.SortByTitle();

            player.Play(false);

            Song song = new Song("Song0");
            song.GetLirycs = "baby shark";
            Console.WriteLine(song.GetLirycs);

            player.playlist.Songs[2].SetLike();
            player.playlist.Songs[6].SetDislike();
            player.SongList();
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
