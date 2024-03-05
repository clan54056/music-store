namespace music_store.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        public string? Name { get; set; }


        //navigation properties

        public IEnumerable<Album>? Albums { get; set; }
        public IEnumerable<Song>? Songs { get; set; }
    }
}
