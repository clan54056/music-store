using System.ComponentModel;

namespace music_store.Models
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        [DisplayName("Navn")]
        public string? Name { get; set;}
        [DisplayName("Beskrivelse")]
        public string? Description { get; set;}
        [DisplayName("Varighed min:sek")]
        public TimeSpan Duration { get; }

        //navigation properties
        [DisplayName("Sange")]
        public IEnumerable<Song>? Songs { get; set; }

    }
}
