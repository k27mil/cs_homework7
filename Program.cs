using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_homework7
{
    public class Song
    {
        private string _name;
        private string _author;
        private Song _prev;

        public void SetName(string name) { _name = name; }
        public void SetAuthor(string author) { _author = author; }
        public void SetPrev(Song prev) { _prev = prev; }

        public string Title() { return $"{_name} - {_author}"; }

        public void Print() { Console.WriteLine(Title()); }

        public override bool Equals(object d)
        {
            Song other = d as Song;
            if (other != null)
            {
                return _name == other._name && _author == other._author;
            }
            return false;
        }

        public override int GetHashCode() { return Title().GetHashCode(); }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Song song1 = new Song();
            song1.SetName("Blinding Lights");
            song1.SetAuthor("The Weeknd");
            song1.SetPrev(null);

            Song song2 = new Song();
            song2.SetName("Starboy");
            song2.SetAuthor("The Weeknd");
            song2.SetPrev(song1);

            Song song3 = new Song();
            song3.SetName("90");
            song3.SetAuthor("Pompeya");
            song3.SetPrev(song2);

            Song song4 = new Song();
            song4.SetName("Champagne Coast");
            song4.SetAuthor("Blood Orange");
            song4.SetPrev(song3);

            List<Song> songs = new List<Song> { song1, song2, song3, song4 };

            foreach (Song song in songs)
            {
                song.Print();
            }

            Console.WriteLine();
            Console.WriteLine($"Первая и вторая песня одинаковые: {songs[0].Equals(songs[1])}");
        }
    
    }
}
