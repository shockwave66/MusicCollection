using System.Collections.Generic;

namespace MusicCollection.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public int TrackCount { get; set; }
        public string Label { get; set; }
        public string Format { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public ICollection<Track> Tracks { get; set; } = new List<Track>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
