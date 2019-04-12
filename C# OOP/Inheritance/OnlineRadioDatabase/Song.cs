using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRadioDatabase
{
    public class Song
    {
        private string nameArtis;
        private string nameSong;
        private int minutes;
        private int seconds;



        public Song(string[] inputData)
        {
            ValidateArgs(inputData);
            this.NameArtis = inputData[0];
            this.NameSong = inputData[1];
            int[] lengthArgs = ValidateLength(inputData[2]);
            this.Minutes = lengthArgs[0];
            this.Seconds = lengthArgs[1];
        }
        public int Seconds
        {
            get { return this.seconds; }
            private set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Song seconds should be between 0 and 59.");
                }
                this.seconds = value;
            }
        }

        public int Minutes
        {
            get { return this.minutes; }
            protected set
            {
                if (value < 0 || value > 14)
                {
                    throw new ArgumentException("Song minutes should be between 0 and 14.");
                }
                this.minutes = value;
            }
        }


        public string NameSong
        {
            get { return this.nameSong; }
            protected set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new ArgumentException("Song name should be between 3 and 30 symbols.");
                }
                this.nameSong = value;
            }
        }


        public string NameArtis
        {
            get { return this.nameArtis; }
            protected set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
                }
                this.nameArtis = value;
            }
        }

        private int[] ValidateLength(string length)
        {
            var tokens = length.Split(':');
            if (tokens.Length != 2 || tokens.Any(t => !t.All(c => Char.IsDigit(c))))
            {
                throw new ArgumentException("Invalid song length.");
            }

            return tokens.Select(int.Parse).ToArray();
        }

        private void ValidateArgs(string[] tokens)
        {
            if (tokens.Length != 3)
            {
                throw new ArgumentException("Invalid song.");
            }
        }

        public int GetLengthInSeconds()
        {
            return this.minutes * 60 + this.seconds;
        }
    }
}
