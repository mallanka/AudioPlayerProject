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

            Artist Artist2 = new Artist();
            
            Artist Artist3 = new Artist("Тату");

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

            CreateSong();
            CreateSong("big city life");
            CreateSong(2000, "я сошла с ума", "E:\\music", "мне нужна она", "death metal", Artist3, Album);

            int min, max, total = 0;
            var player = new Player();
            var songs = CreateSongs(out min, out max, ref total);
            player.Songs = songs;
            Console.WriteLine($"Total duration: {total}, max duration: {max}, min duration: {min}");

            Player.Add("song №1");
            Player.Add("song №2", "song №3");
            Player.Add(new string[]{ "song №4", "song №5", "song №6" });

            Artist Artist4 = AddArtist();
            Console.WriteLine(Artist4.Name);
            Artist Artist5 = AddArtist("Olia SuperStar");
            Console.WriteLine(Artist5.Name);
            Album Album2 = AddAlbum();
            Console.WriteLine(Album2.Name);
            Console.WriteLine(Album2.Year);
            Album Album3 = AddAlbum(albumYear: 2018, albumTitle: "little half");
            Console.WriteLine(Album3.Name);
            Console.WriteLine(Album3.Year);
        }

        static Song[] CreateSongs(out int min, out int max, ref int total)
        {
            Random rand = new Random();
            Song[] songs = new Song[5];
            int MinDuration = int.MaxValue, MaxDuration = int.MinValue, TotalDuration = 0;
            for (int i = 0; i < songs.Length; i++)
            {
                var song1 = new Song();
                song1.Title = "Song" + i;
                song1.Duration = rand.Next(3001);
                song1.Artist = new Artist();
                songs[i] = song1;
                TotalDuration += song1.Duration;
                MinDuration = song1.Duration < MinDuration ? song1.Duration : MinDuration;
                MaxDuration = song1.Duration > MaxDuration ? song1.Duration : MaxDuration;
            }
            total = TotalDuration;
            max = MaxDuration;
            min = MinDuration;
            return songs;
        }
        static Song CreateSong()
        {
            Random random = new Random();
            Song Song = new Song();
            Song.Duration = random.Next(3001);
            Song.Title = "Song №" + random.Next(21);
            Song.Path = "E:\\Album for random songs";
            Song.Lyrics = $"Random lyric for {Song.Title}";
            Song.Genre = $"Random genre for {Song.Title}";
            Song.Artist = new Artist();
            Song.Album = new Album();
            return Song;
        }
        static Song CreateSong(string songName)
        {
            Song Song = CreateSong();
            Song.Title = songName;
            return Song;
        }

        static Song CreateSong(int duration, string songName, string path, string lyris, string genre, Artist artist, Album album)
        {
            Song Song = new Song();
            Song.Duration = duration;
            Song.Title = songName;
            Song.Path = path;
            Song.Lyrics = lyris;
            Song.Genre = genre;
            Song.Artist = artist;
            Song.Album = album;
            return Song;
        }

        static Artist AddArtist(string artistName = "Unknown Artist")
        {
            Artist Artist = new Artist();
            Artist.Name = artistName;
            return Artist;
        }

        static Album AddAlbum(string albumTitle = "Unknown Album", int albumYear = 0)
        {
            Album Album = new Album();
            Album.Name = albumTitle;
            Album.Year = albumYear;
            return Album;
        }
    }
}
