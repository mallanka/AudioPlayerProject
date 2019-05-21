using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AudioPlayerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.LoadSongs("f://m//");
            player.Play();
        }
    }
}
