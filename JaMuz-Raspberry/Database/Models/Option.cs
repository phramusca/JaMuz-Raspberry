using System;
using System.Collections.Generic;

namespace DotMuz.Database.Models
{
    public partial class Option
    {
        public long IdOption { get; set; }
        public long IdMachine { get; set; }
        public long IdOptionType { get; set; }
        public string Value { get; set; }

        public virtual Machine IdMachineNavigation { get; set; }
        public virtual OptionType IdOptionTypeNavigation { get; set; }
    }
}
