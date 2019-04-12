namespace OnlineRadioDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Radio
    {
        private List<Song> playList;

        public Radio()
        {
            this.PlayList = new List<Song>();
        }

        public List<Song> PlayList
        {
            get { return this.playList; }
            private set { this.playList = value; }
        }

        public string AddSong(Song song)
        {
            this.playList.Add(song);
            return "Song added.";
        }

        public override string ToString()
        {
            var lenghtPlayList = this.playList.Select(s=>s.GetLengthInSeconds()).Sum();

            return $"Songs added: {this.playList.Count}" + Environment.NewLine +
                $"Playlist length: {lenghtPlayList / 3600}h {lenghtPlayList / 60 % 60}m {lenghtPlayList % 60}s" ;

        }
    }
}
