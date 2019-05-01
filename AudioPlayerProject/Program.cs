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
            Player player = new Player(new ClassicSkin());
            player.Add(new Song("Song1"), new Song("Song2"), new Song("Song3"));
            player.SongList();
            while (true)
            {
                player.ChangeSkin();
                player.SongList();
            }
        }
    }
}
