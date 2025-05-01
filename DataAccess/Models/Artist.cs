using System.Collections.Generic;
using System.Text;

namespace MusicCollection.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string ActiveYears { get; set; }
        public string? Biography { get; set; }
        public ICollection<Album>? Albums { get; set; } = null;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Artist ID: {Id}");
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Country: {Country}");
            sb.AppendLine($"Active Years: {ActiveYears}");
            sb.AppendLine($"Biography: {Biography ?? "No biography available"}");
            sb.AppendLine($"Albums: {(Albums != null && Albums.Count > 0 ? Albums.Count.ToString() : "None")}");
            return sb.ToString();
        }
    }
}
