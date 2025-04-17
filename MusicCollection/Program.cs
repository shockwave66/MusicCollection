using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MusicCollection.Data;
using MusicCollection.Models;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        using var db = new MusicCollectionContext();
        db.Database.Migrate();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Музична колекція ===");
            Console.WriteLine("1. Додати виконавця");
            Console.WriteLine("2. Додати альбом");
            Console.WriteLine("3. Додати трек");
            Console.WriteLine("4. Переглянути всі альбоми");
            Console.WriteLine("0. Вихід");
            Console.Write("Оберіть опцію: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1": AddArtist(db); break;
                case "2": AddAlbum(db); break;
                case "3": AddTrack(db); break;
                case "4": ListAlbums(db); break;
                case "0": return;
                default: break;
            }
            Console.WriteLine("\nНатисніть будь‑яку клавішу…");
            Console.ReadKey();
        }
    }

    static void AddArtist(MusicCollectionContext db)
    {
        Console.Write("Ім'я виконавця: ");
        var name = Console.ReadLine();
        Console.Write("Країна: ");
        var country = Console.ReadLine();
        // Для спрощення Genres і ActiveYears можна заповнювати вручну
        var artist = new Artist { Name = name, Country = country, ActiveYears = "", Biography = "" };
        db.Artists.Add(artist);
        db.SaveChanges();
        Console.WriteLine("Виконавця додано.");
    }

    static void AddAlbum(MusicCollectionContext db)
    {
        var artists = db.Artists.ToList();
        if (!artists.Any())
        {
            Console.WriteLine("Спершу додайте хоча б одного виконавця.");
            return;
        }
        Console.WriteLine("Оберіть виконавця за ID:");
        foreach (var a in artists) Console.WriteLine($"{a.Id}. {a.Name}");
        if (!int.TryParse(Console.ReadLine(), out int artistId) ||
            db.Artists.Find(artistId) is not Artist artist)
        {
            Console.WriteLine("Невірний ID.");
            return;
        }
        Console.Write("Назва альбому: "); var title = Console.ReadLine();
        Console.Write("Жанр: "); var genre = Console.ReadLine();
        Console.Write("Рік випуску: "); var year = int.Parse(Console.ReadLine()!);
        var album = new Album
        {
            Title = title,
            Genre = genre,
            ReleaseYear = year,
            TrackCount = 0,
            Label = "",
            Format = "",
            Artist = artist
        };
        db.Albums.Add(album);
        db.SaveChanges();
        Console.WriteLine("Альбом додано.");
    }

    static void AddTrack(MusicCollectionContext db)
    {
        var albums = db.Albums.ToList();
        if (!albums.Any())
        {
            Console.WriteLine("Спершу додайте хоча б один альбом.");
            return;
        }
        Console.WriteLine("Оберіть альбом за ID:");
        foreach (var a in albums) Console.WriteLine($"{a.Id}. {a.Title}");
        if (!int.TryParse(Console.ReadLine(), out int albumId) ||
            db.Albums.Find(albumId) is not Album album)
        {
            Console.WriteLine("Невірний ID.");
            return;
        }
        Console.Write("Назва треку: "); var title = Console.ReadLine();
        Console.Write("Тривалість (мм:сс): "); var dur = TimeSpan.Parse("00:" + Console.ReadLine());
        Console.Write("Номер у списку: "); var num = int.Parse(Console.ReadLine()!);
        var track = new Track { Title = title, Duration = dur, TrackNumber = num, Album = album };
        db.Tracks.Add(track);
        album.TrackCount++;
        db.SaveChanges();
        Console.WriteLine("Трек додано.");
    }

    static void ListAlbums(MusicCollectionContext db)
    {
        var albums = db.Albums
            .Select(a => new { a.Id, a.Title, Artist = a.Artist.Name, a.ReleaseYear })
            .ToList();
        Console.WriteLine("ID | Назва — Виконавець — Рік");
        foreach (var a in albums)
            Console.WriteLine($"{a.Id} | {a.Title} — {a.Artist} — {a.ReleaseYear}");
    }
}
