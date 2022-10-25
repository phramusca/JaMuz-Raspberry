using System;
using System.Collections.Generic;

namespace DotMuz.Database.Models
{
    public partial class PlaylistOrder
    {
        public long IdPlaylistOrder { get; set; }
        public long Desc { get; set; }
        public string Field { get; set; }
        public long? IdPlaylist { get; set; }

        public virtual Playlist IdPlaylistNavigation { get; set; }
    }
}
