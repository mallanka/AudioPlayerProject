using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayerProject
{
    class PlayerStartEventClass
    {
        public void Message()
        {
            Console.WriteLine("Player is started");
        }
    }
    class PlayerStopEventClass
    {
        public void Message()
        {
            Console.WriteLine("Player is stopped");
        }
    }
    class SongPlayEventClass
    {
        public void Message()
        {
            Console.WriteLine("Song is playing");
        }
    }
    class SongListChangedEventClass
    {
        public void Message()
        {
            Console.WriteLine("Playlist was changed");
        }
    }
    class VolumeChangedEventClass
    {
        public void Message()
        {
            Console.WriteLine("Volume was changed");
        }
    }
    class PlayerLockedEventClass
    {
        public void Message()
        {
            Console.WriteLine("Player was locked");
        }
    }
    class PlayerUnlockedEventClass
    {
        public void Message()
        {
            Console.WriteLine("Player was unlocked");
        }
    }
}
