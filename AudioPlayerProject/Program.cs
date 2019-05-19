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
            PlayerStartEventClass playerStartEvent = new PlayerStartEventClass();
            PlayerStopEventClass playerStopEvent = new PlayerStopEventClass();
            SongPlayEventClass songPlayEvent = new SongPlayEventClass();
            SongListChangedEventClass songListChangedEvent = new SongListChangedEventClass();
            VolumeChangedEventClass volumeChangedEvent = new VolumeChangedEventClass();
            PlayerLockedEventClass playerLockedEvent = new PlayerLockedEventClass();
            PlayerUnlockedEventClass playerUnlockedEvent = new PlayerUnlockedEventClass();
            Player player = new Player();
            player.PlayerStartEvent += playerStartEvent.Message;
            player.PlayerStopEvent += playerStopEvent.Message;
            player.SongPlayEvent += songPlayEvent.Message;
            player.SongListChangedEvent += songListChangedEvent.Message;
            player.VolumeChangedEvent += volumeChangedEvent.Message;
            player.PlayerLockedEvent += playerLockedEvent.Message;
            player.PlayerUnlockedEvent += playerUnlockedEvent.Message;
        }
    }
}
