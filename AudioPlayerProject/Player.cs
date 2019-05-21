using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Media;

namespace AudioPlayerProject
{
    class Player : IDisposable
    {
        private bool _playing = false;
        private int _volume = 50;
        public const int MaxVolume = 100;
        public bool IsLock = false;
        public Playlist playlist = new Playlist();
        public Skin mySkin;
        private SoundPlayer soundPlayer;
        private bool disposed = false;

        public delegate void PlayerDelegate();
        public event PlayerDelegate VolumeChangedEvent;
        public event PlayerDelegate SongPlayEvent;
        public event PlayerDelegate PlayerLockedEvent;
        public event PlayerDelegate PlayerUnlockedEvent;
        public event PlayerDelegate PlayerStartEvent;
        public event PlayerDelegate PlayerStopEvent;
        public event PlayerDelegate SongListChangedEvent;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
            }
        }

        ~Player()
        {
            Dispose(false);
        }

        public Player()
        {
            this.mySkin = new ClassicSkin();
            this.mySkin.Render();
            soundPlayer = new SoundPlayer();
        }

        public bool Playing
        {
            get { return _playing; }
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
                VolumeChangedEvent();
            }
        }

        public void Play()
        {
            foreach (var file in playlist.FileList)
            {
                Console.WriteLine(file.Title.CutStringExtension());
                soundPlayer.SoundLocation = file.Path + file.Title + ".wav";
                soundPlayer.PlaySync();
                SongPlayEvent();
            }
        }

        public void VolumeUp()
        {
            Volume += 5;
        }

        public void VolumeDown()
        {
            Volume -= 5;
        }

        public void VolumeChanged(int step)
        {
            Volume = step;
        }

        public void Lock()
        {
            if (IsLock == false)
            {
                IsLock = true;
                PlayerLockedEvent();
            }
        }

        public void UnLock()
        {
            if (IsLock == true)
            {
                IsLock = false;
                PlayerUnlockedEvent();
            }
        }
        
        public void Start()
        {
            if (IsLock == false)
            {
                _playing = true;
                PlayerStartEvent();
            }
        }

        public void Stop()
        {
            if (IsLock == false && _playing == true)
            {
                _playing = false;
                PlayerStopEvent();
            }
        }

        public void List()
        {
            foreach (var file in playlist.FileList)
            {
                if (file.Like == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(file.Title.CutStringExtension());
                    Console.ResetColor();
                }
                else if (file.Like == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(file.Title.CutStringExtension());
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(file.Title.CutStringExtension());
                }
            }
        }


        
        public void AddFileToPlaylist(params Song[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                playlist.FileList.Add(list[i]);
            }
            SongListChangedEvent();
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
        public void ClearList()                 
        {
            playlist.FileList.Clear();
            SongListChangedEvent();
        }

        public void LoadSongs(string path)      
        {
            foreach (var songTitle in Directory.GetFiles(path))
            {
                playlist.FileList.Add(new Song(songTitle.Replace(path, "").Replace(".wav", "")) { Path = path });
            }
            SongListChangedEvent();
        }

        public void SaveAsPlaylist(string path)                
        {
            XmlSerializer xmlPlaylist = new XmlSerializer(typeof(List<Song>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlPlaylist.Serialize(fs, playlist.FileList);
            }
        }

        public void LoadPlaylist(string path)                  
        {
            XmlSerializer xmlPlaylist = new XmlSerializer(typeof(List<Song>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                playlist.FileList = (List<Song>)xmlPlaylist.Deserialize(fs);
            }
            SongListChangedEvent();
        }
    }
}
