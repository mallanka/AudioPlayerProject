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

    public class Song
    {
        public int Duration;
        public string Title;
        public string Path;
        public string Lyrics;
        public genre Genre;
        public Artist Artist;
        public Album Album;
        public bool? Like = null;

        public Song(string title)
        {
            Title = title;
            Genre = genre.Pop;
        }

        public void SetLike()
        {
            Like = true;
        }

        public void SetDislike()
        {
            Like = false;
        }

        //L9-HW-Player-3/3. Song Deconstruction
        public void Deconstruct(out int duration, out string title, out string path,
            out string lyrics, out Enum songGenre)
        {
            duration = Duration;
            title = Title;
            path = Path;
            lyrics = Lyrics;
            songGenre = Genre;
        }
    }
}
