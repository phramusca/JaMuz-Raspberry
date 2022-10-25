using System;
using System.Collections.Generic;

namespace DotMuz.Database.Models
{
    public partial class Machine
    {
        public Machine()
        {
            Device = new HashSet<Device>();
            Option = new HashSet<Option>();
            StatSource = new HashSet<StatSource>();
        }

        public long IdMachine { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Hidden { get; set; }

        public virtual ICollection<Device> Device { get; set; }
        public virtual ICollection<Option> Option { get; set; }
        public virtual ICollection<StatSource> StatSource { get; set; }
    }
}
