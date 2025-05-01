using System.Collections.Generic;
using System.Text;

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
        public Artist? Artist { get; set; }

        public ICollection<Track>? Tracks { get; set; } = null;
        public ICollection<Review>? Reviews { get; set; } = null;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Album ID: {Id}");
            sb.AppendLine($"Title: {Title}");
            sb.AppendLine($"Genre: {Genre}");
            sb.AppendLine($"Release Year: {ReleaseYear}");
            sb.AppendLine($"Track Count: {TrackCount}");
            sb.AppendLine($"Label: {Label}");
            sb.AppendLine($"Format: {Format}");
            sb.AppendLine($"Artist ID: {ArtistId}");
            sb.AppendLine($"Artist: {Artist?.ToString() ?? "Unknown"}");
            sb.AppendLine($"Tracks: {(Tracks != null ? Tracks.Count.ToString() : "None")}");
            sb.AppendLine($"Reviews: {(Reviews != null ? Reviews.Count.ToString() : "None")}");
            return sb.ToString();
        }
    }
}
