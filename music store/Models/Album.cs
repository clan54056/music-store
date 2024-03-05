namespace music_store.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public string? Title { get; set; }
        public double Price { get; set; }
        public string? AlbumArtUrl { get; set; }

        //navigation properties

        public Artist? Artist { get; set; }
        public Genre? Genre { get; set; }
    }
}
