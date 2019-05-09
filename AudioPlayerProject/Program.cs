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
            Player<Song> player = new Player<Song>();
            player.AddFileToPlaylist(new Song("Song1"), new Song("Song2"), new Song("Song3"));
            player.playlist.FileList[2].SetLike();
            player.List();

            Player<Video> videoPlayer = new Player<Video>();
            videoPlayer.AddFileToPlaylist(new Video("video1"), new Video("video2"));
            videoPlayer.playlist.FileList[0].SetDislike();
            videoPlayer.List();
        }
    }
}
