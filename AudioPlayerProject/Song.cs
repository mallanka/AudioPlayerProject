using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayerProject
{
    [Flags] public enum genre
    {
        Pop = 1,
        NotPop = 2,
        AlmostPop = 4,
        MoreThanPop = 8
    };

    public class Song : File
    {
        public string Lyrics;
        public genre Genre;
        public Artist Artist;
        public Album Album;

        public Song(string title)
        {
            Title = title;
        }

        public override void GetData()
        {
            base.GetData();
            Console.WriteLine($"Lyrics: {Lyrics}\n" +
                              $"Genre: {Genre}");
        }
    }
}
