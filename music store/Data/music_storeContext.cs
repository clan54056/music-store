using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using music_store.Models;

namespace music_store.Data
{
    public class music_storeContext : DbContext
    {
        public music_storeContext (DbContextOptions<music_storeContext> options)
            : base(options)
        {
        }

        public DbSet<music_store.Models.Artist> Artist { get; set; } = default!;

        public DbSet<music_store.Models.Album>? Album { get; set; }

        public DbSet<music_store.Models.Genre>? Genre { get; set; }

        public DbSet<music_store.Models.Song>? Song { get; set; }

        public DbSet<music_store.Models.Playlist>? Playlist { get; set; }
    }
}
