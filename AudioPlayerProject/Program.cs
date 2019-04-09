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
            Song song = new Song();
            song.Title = "Дым сигарет с ментолом";
            song.Duration = 300;
            song.Artist = new Artist { Name = "Нэнси" };
            Song song2 = new Song();
            song2.Title = "Tired";
            song2.Artist = new Artist { Name = "Corey Taylor" };
            song2.Duration = 250;
            Player player = new Player();
            player.Songs = new Song[] { song, song2 };
            
            while (true)
            {
                switch(Console.ReadKey().Key)
                {
                    case ConsoleKey.Add:
                        player.VolumeUp();
                        break;
                    case ConsoleKey.Subtract:
                        player.VolumeDown();
                        break;
                    case ConsoleKey.P:
                        Console.WriteLine();
                        player.Play();
                        break;
                }
            }
        }
    }
}
