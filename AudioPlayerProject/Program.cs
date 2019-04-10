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
            Artist Artist = new Artist();
            Artist.Name = "crazy fish";
            Artist.NickName = "Phantomas";
            Artist.Country = "London is the capital of Great Britain";
            Artist.Songs = new Song[5];

            Console.WriteLine($"the name of the Artist is '{Artist.Name}'");
            Console.WriteLine($"the NickName of the Artist is '{Artist.NickName}'");
            Console.WriteLine($"the country of the Artist is '{Artist.Country}'");
            Console.WriteLine($"the song's count is {Artist.Songs.Length}");

            Album Album = new Album();
            Album.Name = "burn the sea";
            Album.Path = "E:\\МУЗЛО";
            Album.Year = 0;
            Album.Songs = Artist.Songs;

            Console.WriteLine($"the album title is '{Album.Name}'");
            Console.WriteLine($"the path of the Album is '{Album.Path}'");
            Console.WriteLine($"the year of the Album is '{Album.Year}'");
            Console.WriteLine($"the songs count at the Album is {Album.Songs.Length}");

            Band Band = new Band();
            Band.Title = "Crasy fish's band";
            Band.Genre = "GrindCore";
            Band.Year = 0;
            Band.IsExist = true;
            Band.Artists = new[] { Artist };

            Console.WriteLine($"the title of the Band is '{Band.Title}'");
            Console.WriteLine($"the genre of the Band's songs is '{Band.Genre}'");
            Console.WriteLine($"the year of foundation of the Band is {Band.Year}");
            Console.WriteLine(Band.IsExist == true ? "it is still singing" : "it is dead");
            foreach (var ArtistName in Band.Artists)
            {
                Console.WriteLine("all artists name: " + ArtistName.Name + " ");
            }

            Player Player = new Player();
            Player.Volume = 50;
            Player.IsLock = false;
            Player.Songs = Album.Songs;

            Console.WriteLine($"the start volume is {Player.Volume}");
            Console.WriteLine(Player.IsLock == true ? "it is Locked" : "it is unLocked");
            Console.WriteLine($"the song's count in Player is {Player.Songs.Length}");

            Playlist Playlist = new Playlist();
            Playlist.Title = "DefaultPlaylist";
            Playlist.Path = "E:\\МУЗЛО";
            Playlist.Songs = new Song[5];

            Console.WriteLine($"the playlist's title is '{Playlist.Title}'");
            Console.WriteLine($"the path of this playlist is '{Playlist.Path}'");
            Console.WriteLine($"the song's count in Playlist is {Playlist.Songs.Length}");

            Song Song1 = new Song();
            Song1.Title = "murder";
            Song1.Path = "E:\\МУЗЛО\\burn the sea\\";
            Song1.Lyrics = "baby shark tu tu du dututu";
            Song1.Genre = "Psychedelic";
            Song1.Artist = Artist;
            Song1.Album = Album;

            Console.WriteLine($"the title of the Song1 is '{Song1.Title}'");
            Console.WriteLine($"the path of the Song1 is '{Song1.Path}'");
            Console.WriteLine($"the lyrics of the Song1 is '{Song1.Lyrics}'");
            Console.WriteLine($"the genre of the Song1 is '{Song1.Genre}'");
            Console.WriteLine($"the name of the Artist of this song is {Song1.Artist.Name}");
            Console.WriteLine($"the name of the album with this song is '{Song1.Album.Name}'");

            Player.VolumeUp();
            Player.VolumeDown();
            Console.Write("set the volume: ");
            Player.VolumeChanged(int.Parse(Console.ReadLine()));
            Player.Lock();
            Player.UnLock();
            Player.Start();
            Player.Stop();
        }
    }
}
