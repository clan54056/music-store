namespace music_store.Models
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public string? Name { get; set;}
        public string? Description { get; set;}
        public TimeSpan Duration { get; }

        //navigation properties

        public IEnumerable<Song>? Songs { get; set; }
        public IEnumerable<Album>? Albums { get; set; }
        public IEnumerable<Genre>? Genres { get; set; }
        public IEnumerable<Artist>? Artists { get; set; }
    }
}
