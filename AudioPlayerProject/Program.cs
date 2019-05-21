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
            player.PlayerStartEvent += List;
            player.PlayerStopEvent += List;
            player.SongPlayEvent += List;
            player.SongListChangedEvent += List;
            player.VolumeChangedEvent += List;
            player.PlayerLockedEvent += List;
            player.PlayerUnlockedEvent += List;
            player.Start();
            System.Threading.Thread.Sleep(1000);
            player.LoadSongs("f://m//");
            System.Threading.Thread.Sleep(1000);
            player.Play();
            System.Threading.Thread.Sleep(1000);
            player.VolumeUp();
            System.Threading.Thread.Sleep(1000);
            player.Play();
            System.Threading.Thread.Sleep(1000);
            player.Lock();
            player.Play();
            player.UnLock();

            void List()
            {
                if (player.IsLock)
                {
                    Console.WriteLine($"Player status: player is Locked, volume level: {player.Volume}");
                }
                else
                {
                    Console.WriteLine($"Player status: player is unLocked, volume level: {player.Volume}");
                }
                for (int i = 0; i < player.playlist.FileList.Count; i++)
                {
                    if (player.playlist.FileList[i].Path + player.playlist.FileList[i].Title + ".wav" == player.playingSong)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(player.playlist.FileList[i].Path + player.playlist.FileList[i].Title + ".wav");
                        player.mySkin.Render();
                    }
                    else
                    {
                        Console.WriteLine(player.playlist.FileList[i].Path + player.playlist.FileList[i].Title + ".wav");
                    }
                }
            }
        }
    }
}
