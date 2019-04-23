using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayerProject
{
    enum genre
    {
        Pop = 0b00000001,
        NotPop = 0b00000010,
        AlmostPop = 0b00000100,
        MoreThanPop = 0b00001000
    };
    class Song
    {
        public int Duration;
        public string Title;
        public string Path;
        public string Lyrics;
        public genre Genre;
        public Artist Artist;
        public Album Album;
        public bool? Like = null;

        public string GetLirycs
        {
            set { Lyrics = value; }
            get { return Lyrics = Title + ": " + Lyrics; }
        }
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
    }
}
