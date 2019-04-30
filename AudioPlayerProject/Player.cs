using System;
using System.Collections.Generic;

namespace AudioPlayerProject
{
    class Player
    {
        private bool _playing = false;
        private int _volume = 50;
        public const int MaxVolume = 100;
        public bool IsLock = false;
        public Playlist playlist = new Playlist();

        public bool Playing
        {
            get
            {
                return _playing;
            }
        }

        public int Volume
        {
            get { return _volume; }
            set
            {
                if (value > MaxVolume)
                {
                    _volume = MaxVolume;
                }
                else if (value < 0)
                {
                    _volume = 0;
                }
                else
                {
                    _volume = value;
                }
            }
        }

        public void Play(Enum filter)
        {
            foreach (var song in playlist.Songs)
            {
                if (song.Genre.HasFlag(filter))
                {
                    Console.WriteLine(song.Title.CutStringExtension() + " " + song.Duration);
                    System.Threading.Thread.Sleep(song.Duration);
                }
            }
        }

        public void VolumeUp()
        {
            Volume += 5;
            Console.WriteLine("Volume was increased: " + Volume);
        }

        public void VolumeDown()
        {
            Volume -= 5;
            Console.WriteLine("Volume was reduced: " + Volume);
        }

        public void VolumeChanged(int step)
        {
            Volume = step;
            Console.WriteLine("volume was changed: " + Volume);
        }

        public void Lock()
        {
            if (IsLock == false)
            {
                IsLock = true;
                Console.WriteLine("the player was Locked");
            }
        }

        public void UnLock()
        {
            if (IsLock == true)
            {
                IsLock = false;
                Console.WriteLine("the player was UnLocked");
            }
        }

        public bool Start()
        {
            if (IsLock == false)
            {
                _playing = true;
                Console.WriteLine("playing started");
            }
            return _playing;
        }

        public bool Stop()
        {
            if (IsLock == false && _playing == true)
            {
                _playing = false;
                Console.WriteLine("playing stopped");
            }
            return _playing;
        }

        public void SongList()
        {
            foreach (Song song in playlist.Songs)
            {
                if (song.Like == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(song.Title.CutStringExtension());
                    Console.ResetColor();
                }
                else if (song.Like == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(song.Title.CutStringExtension());
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(song.Title.CutStringExtension());
                }
            }
        }
    }
}
