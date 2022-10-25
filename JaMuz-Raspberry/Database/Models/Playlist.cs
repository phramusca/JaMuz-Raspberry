using System;
using System.Collections.Generic;

namespace DotMuz.Database.Models
{
    public partial class Playlist
    {
        public Playlist()
        {
            Device = new HashSet<Device>();
            PlaylistFilter = new HashSet<PlaylistFilter>();
            PlaylistOrder = new HashSet<PlaylistOrder>();
        }

        public long IdPlaylist { get; set; }
        public string Name { get; set; }
        public long LimitDo { get; set; }
        public long LimitValue { get; set; }
        public string LimitUnit { get; set; }
        public string Type { get; set; }
        public string Match { get; set; }
        public long Random { get; set; }
        public long Hidden { get; set; }

        public virtual ICollection<Device> Device { get; set; }
        public virtual ICollection<PlaylistFilter> PlaylistFilter { get; set; }
        public virtual ICollection<PlaylistOrder> PlaylistOrder { get; set; }
    }
}
