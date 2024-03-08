using System.ComponentModel;

namespace music_store.Models
{
    public class Album
    {
        [DisplayName("Album")]
        public int AlbumId { get; set; }
        [DisplayName("Genre")]
        public int GenreId { get; set; }
        [DisplayName("Kunstner")]
        public int ArtistId { get; set; }
        [DisplayName("Sang")]
        public int SongId { get; set; }
        [DisplayName("Titel")]
        public string? Title { get; set; }
        [DisplayName("Pris")]
        public double Price { get; set; }
        [DisplayName("Album billede")]
        public string? AlbumArtUrl { get; set; }

        //navigation properties
        [DisplayName("Kunstner")]
        public Artist? Artist { get; set; }
        public Genre? Genre { get; set; }
        [DisplayName("Sange")]
        public IEnumerable<Song>? Songs { get; set; }
    }
}
