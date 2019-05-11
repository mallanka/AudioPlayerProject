using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayerProject
{
    public class Video : File
    {
        public string Picture { get; set; }

        public Video(string title)
        {
            Title = title;
            Picture = "Playing video";
        }
    }
}
