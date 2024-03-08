using System.ComponentModel;

namespace music_store.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        [DisplayName("Navn")]
        public string? Name { get; set; }
        [DisplayName("Beskrivelse")]
        public string? Description { get; set; }

        //navigation properties
        [DisplayName("Album")]
        public IEnumerable<Album>? Albums { get; set; }

    }
}
