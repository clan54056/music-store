namespace music_store.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string? ArtistId { get; set; }
        public string? ArtistName { get; set; }
        public string? Title { get; set;}
        public TimeSpan Duration { get; set; }

        //navigation properties

        public Artist? Artist { get; set; }
        public IEnumerable<Album>? Albums { get; set; }
        public IEnumerable<Genre>? Genres { get; set; }
    }
}
