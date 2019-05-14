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
            Player player = new Player();
            player.LoadSongs("f://m//");
            player.List();
            player.SaveAsPlaylist("f://playlist.xml");
            player.ClearList();
            Console.WriteLine();
            player.LoadPlaylist("f://playlist.xml");
            player.List();
        }
    }
}
