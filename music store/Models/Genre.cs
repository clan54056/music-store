namespace music_store.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        //navigation properties

        public Album? Album { get; set; }
    }
}
