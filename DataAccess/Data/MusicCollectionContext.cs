using Microsoft.EntityFrameworkCore;
using MusicCollection.Models;

namespace MusicCollection.Data
{
    public class MusicCollectionContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<UserCollectionItem> UserCollectionItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistTrack> PlaylistTracks { get; set; }


        public MusicCollectionContext() {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Встанови свій рядок підключення до SQL Server
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MusicCollectionDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artist>().HasData(
                new Artist
                {
                    Id = 1,
                    Name = "Pink Floyd",
                    Country = "United Kingdom",
                    ActiveYears = "1965 - 2014",
                    Biography = "An iconic progressive rock band known for albums like 'The Dark Side of the Moon'.",
                }
            );

            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    Id = 1,
                    Title = "The Dark Side of the Moon",
                    Genre = "Progressive Rock",
                    ReleaseYear = 1973,
                    TrackCount = 10,
                    Label = "Harvest Records",
                    Format = "Vinyl",
                    ArtistId = 1
                }
            );


            // Налаштування many-to-many для Playlist–Track
            modelBuilder.Entity<PlaylistTrack>()
                .HasKey(pt => new { pt.PlaylistId, pt.TrackId });

            modelBuilder.Entity<PlaylistTrack>()
                .HasOne(pt => pt.Playlist)
                .WithMany(p => p.PlaylistTracks)
                .HasForeignKey(pt => pt.PlaylistId);

            modelBuilder.Entity<PlaylistTrack>()
                .HasOne(pt => pt.Track)
                .WithMany(t => t.PlaylistTracks)
                .HasForeignKey(pt => pt.TrackId);

            // У разі потреби додаткові налаштування
        }
    }
}
