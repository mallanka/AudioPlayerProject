﻿using System;

namespace AudioPlayerProject
{
    class Player
    {
        private int volume = 50;
        public const int MaxVolume = 100;
        public bool IsLock = false;
        public Song[] Songs;
        private bool playing = false;

        public bool Playing
        {
            get
            {
                return playing;
            }
        }

        public int Volume
        {
            get { return volume; }
            set
            {
                if (value > MaxVolume)
                {
                    volume = MaxVolume;
                }
                else if (value < 0)
                {
                    volume = 0;
                }
                else
                {
                    volume = value;
                }
            }
        }

        public void Play()
        {
            for (int i = 0; i < Songs.Length; i++)
            {
                Console.WriteLine(Songs[i].Title);
                System.Threading.Thread.Sleep(2000);
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
                playing = true;
                Console.WriteLine("playing started");
            }
            return Playing;
        }

        public bool Stop()
        {
            if (IsLock == false && playing == true)
            {
                playing = false;
                Console.WriteLine("playing stopped");
            }
            return Playing;
        }
    }
}
