using System;
using System.Collections.Generic;

namespace DotMuz.Database.Models
{
    public partial class PlaylistFilter
    {
        public long IdPlaylistFilter { get; set; }
        public string Field { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
        public long? IdPlaylist { get; set; }

        public virtual Playlist IdPlaylistNavigation { get; set; }
    }
}
