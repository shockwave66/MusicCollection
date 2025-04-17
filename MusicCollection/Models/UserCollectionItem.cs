using System;

namespace MusicCollection.Models
{
    public class UserCollectionItem
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public DateTime DateAdded { get; set; }
        public string Status { get; set; } // "Purchased" або "Wishlist"
    }
}
