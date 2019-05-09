using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayerProject
{
    class Player<T>
    {
        private bool _playing = false;
        private int _volume = 50;
        public const int MaxVolume = 100;
        public bool IsLock = false;
        public Playlist<T> playlist = new Playlist<T>();
        public Skin mySkin;

        public Player()
        {
            this.mySkin = new ClassicSkin();
            this.mySkin.Render();
        }

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
            foreach (var file in playlist.FileList)
            {
                switch (file)
                {
                    case Song x when x.Genre.HasFlag(filter):
                        {
                            Console.WriteLine(x.Title.CutStringExtension() + " " + x.Duration);
                            System.Threading.Thread.Sleep(x.Duration);
                            break;
                        }
                    case Video x:
                        {
                            Console.WriteLine(x.Picture);
                            Console.WriteLine(x.Title.CutStringExtension() + " " + x.Duration);
                            System.Threading.Thread.Sleep(x.Duration);
                            break;
                        }
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

        public void List()
        {
            foreach (var file in playlist.FileList)
            {
                switch (file)
                {
                    case Song x:
                    {
                        if (x.Like == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(x.Title.CutStringExtension());
                            Console.ResetColor();
                        }
                        else if (x.Like == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(x.Title.CutStringExtension());
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine(x.Title.CutStringExtension());
                        }
                        break;
                    }
                    case Video x:
                    {
                        if (x.Like == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(x.Title.CutStringExtension());
                            Console.ResetColor();
                        }
                        else if (x.Like == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(x.Title.CutStringExtension());
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine(x.Title.CutStringExtension());
                        }
                        break;
                    }
                }
                
            }
        }

        public void AddFileToPlaylist(params T[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                playlist.FileList.Add(list[i]);
            }
        }
        public void ChangeSkin()
        {
            mySkin = new ClassicSkin();
            Console.WriteLine("what skin you want to apply? write a number" +
                              "\n1. Classic skin" +
                              "\n2. Color skin" +
                              "\n3. Font size skin");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                default:
                    mySkin = new ClassicSkin();
                    break;
                case ConsoleKey.D2:
                    mySkin = new ColorSkin();
                    break;
                case ConsoleKey.D3:
                    mySkin = new EyesSkin();
                    break;
            }
            mySkin.Render();
            mySkin.Clear();
        }

    }
}
