using System.Collections.Generic;

namespace JaMuzRaspberry.Database.Models;

public partial class OptionType
{
    public OptionType()
    {
        Option = new HashSet<Option>();
    }

    public long IdOptionType { get; set; }
    public string Name { get; set; }
    public string Default { get; set; }
    public string Type { get; set; }

    public virtual ICollection<Option> Option { get; set; }
}
