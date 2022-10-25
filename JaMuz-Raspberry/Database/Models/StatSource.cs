using System;
using System.Collections.Generic;

namespace DotMuz.Database.Models
{
    public partial class StatSource
    {
        public StatSource()
        {
            Client = new HashSet<Client>();
            PlayCounter = new HashSet<PlayCounter>();
        }

        public long IdStatSource { get; set; }
        public string Location { get; set; }
        public long IdStatement { get; set; }
        public string RootPath { get; set; }
        public long IdMachine { get; set; }
        public string Name { get; set; }
        public long? IdDevice { get; set; }
        public long Selected { get; set; }
        public string LastMergeDate { get; set; }

        public virtual Device IdDeviceNavigation { get; set; }
        public virtual Machine IdMachineNavigation { get; set; }
        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<PlayCounter> PlayCounter { get; set; }
    }
}
