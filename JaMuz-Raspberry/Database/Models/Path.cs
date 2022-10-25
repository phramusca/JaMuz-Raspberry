using System;
using System.Collections.Generic;

namespace DotMuz.Database.Models
{
    public partial class Path
    {
        public Path()
        {
            File = new HashSet<File>();
        }

        public long IdPath { get; set; }
        public string StrPath { get; set; }
        public string ModifDate { get; set; }
        public long Deleted { get; set; }
        public long Checked { get; set; }
        public long CopyRight { get; set; }
        public string MbId { get; set; }

        public virtual ICollection<File> File { get; set; }
    }
}
