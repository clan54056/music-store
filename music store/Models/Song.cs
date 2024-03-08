using System.ComponentModel;

namespace music_store.Models
{
    public class Song
    {
        public int SongId { get; set; }
        [DisplayName("Titel")]
        public string? Title { get; set;}
        [DisplayName("Varighed min:sek")]
        public TimeSpan Duration { get; set; }
        [DisplayName("Kunstner")]
        public int ArtistId { get; set; }
        public int? AlbumId { get; set; }
        [DisplayName("Spilleliste")]
        public int? PlaylistId { get; set; }

        public string FormattedDuration
        {
            get { return $"{(int)Duration.TotalMinutes:D2}:{Duration.Seconds:D2}"; }
        }

        //navigation properties
        [DisplayName("Kunstner")]
        public Artist? Artist { get; set; }
        [DisplayName("Spillelister")]
        public IEnumerable<Playlist>? Playlists { get; set; }
        public Album? Album { get; set; }
    }
}
