using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayerProject
{
    public abstract class File
    {
        public int Duration;
        public string Title;
        public string Path;
        public bool? Like = null;

        public File()
        {

        }

        public File(string title)
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

        public virtual void GetData()
        {
            Console.WriteLine($"{Title}:\n" +
                              $"Duration: {Duration}\n" +
                              $"Path: {Path}\n");
        }
    }
}
