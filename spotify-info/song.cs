using System;

namespace spotify_info
{
    class song
    {

        public currentlyplaying Song_info { get; set; }

        public class Local_info
        {
            public string path { get; set; }
            public bool downloaded { get; set; }
            public DateTime time { get; set; }
        }

        public currentlyplaying song_info;
        public Local_info local_Info;

    }
}
