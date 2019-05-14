using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AudioPlayerProject
{
    [Flags] public enum genre
    {
        Pop = 1,
        NotPop = 2,
        AlmostPop = 4,
        MoreThanPop = 8
    };
    [Serializable]
    public class Song
    {
        public string Lyrics;
        public int Duration;
        public string Title;
        public string Path;
        public bool? Like = null;
        public genre Genre;
        public Artist Artist;
        public Album Album;

        public Song() { }

        public Song(string title)
        {
            Title = title;
        }        

        public void SetLike()
        {
            Like = true;
        }

        public void SetDislike()
        {
            Like = false;
        }
        
        public void GetData()
        {
            Console.WriteLine($"{Title}:\n" +
                              $"Duration: {Duration}\n" +
                              $"Path: {Path}\n");
        }
    }
}
