using System.Collections.Generic;

namespace JaMuzRaspberry.Database.Models;

public partial class Tag
{
    public Tag()
    {
        Tagfile = new HashSet<Tagfile>();
    }

    public long Id { get; set; }
    public string Value { get; set; }

    public virtual ICollection<Tagfile> Tagfile { get; set; }
}
