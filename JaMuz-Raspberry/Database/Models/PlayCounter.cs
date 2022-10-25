using System;
using System.Collections.Generic;

namespace DotMuz.Database.Models
{
    public partial class PlayCounter
    {
        public long IdFile { get; set; }
        public long IdStatSource { get; set; }
        public long PlayCounter1 { get; set; }

        public virtual File IdFileNavigation { get; set; }
        public virtual StatSource IdStatSourceNavigation { get; set; }
    }
}
