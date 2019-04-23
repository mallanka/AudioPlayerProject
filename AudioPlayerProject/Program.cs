using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayerProject
{
    class Program
    {
        static Random random = new Random();
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

            Shuffle(player.playlist.Songs);

            player.Play(false);

            Console.WriteLine();

            SortByTitle(player.playlist);

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
        public static void Shuffle(List<Song> songs)        //B7-Player1/2. SongsListShuffle
        {
            for (int i = 0; i < songs.Count; i++)
            {
                songs.Insert(random.Next(1, songs.Count + 1), songs[0]);
                songs.RemoveAt(0);
            }
        }

        public static void SortByTitle(Playlist playlist)               //B7-Player2/2. SongListSort
        {
            playlist.Songs = playlist.Songs.OrderBy(si => si.Title).ToList();
        }
    }
}
