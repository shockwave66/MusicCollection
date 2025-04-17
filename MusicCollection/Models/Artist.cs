using System.Collections.Generic;

namespace MusicCollection.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string ActiveYears { get; set; }
        public string Biography { get; set; }
        public ICollection<string> Genres { get; set; } = new List<string>();
        public ICollection<Album> Albums { get; set; } = new List<Album>();
    }
}
