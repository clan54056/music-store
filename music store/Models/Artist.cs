using System.ComponentModel;

namespace music_store.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        [DisplayName("Navn")]
        public string? Name { get; set; }


        //navigation properties
        [DisplayName("Album")]
        public IEnumerable<Album>? Albums { get; set; }
        [DisplayName("Sange")]
        public IEnumerable<Song>? Songs { get; set; }
    }
}
