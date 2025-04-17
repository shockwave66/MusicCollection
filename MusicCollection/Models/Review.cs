namespace MusicCollection.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public int Rating { get; set; }  // 1–5
        public string Comment { get; set; }
    }
}
