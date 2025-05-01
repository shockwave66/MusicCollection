using System;
using System.Collections.Generic;

namespace MusicCollection.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public int TrackNumber { get; set; }
        public string MusicBy { get; set; }
        public string LyricsBy { get; set; }

        public int AlbumId { get; set; }
        public Album? Album { get; set; }

        public ICollection<PlaylistTrack>? PlaylistTracks { get; set; } = new List<PlaylistTrack>();
    }
}
