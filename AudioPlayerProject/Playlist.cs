using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayerProject
{
    class Playlist<T>
    {
        public string Path;
        public string Title;
        public List<T> FileList = new List<T>();
    }
}
