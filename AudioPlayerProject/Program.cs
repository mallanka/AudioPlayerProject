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
            using (Player player = new Player())
            {
                player.LoadSongs("f://m//");
                player.Play();
                player.Dispose();
            }
        }
    }
}
