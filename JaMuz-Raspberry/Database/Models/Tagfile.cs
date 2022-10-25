namespace JaMuzRaspberry.Database.Models;

public partial class Tagfile
{
    public long IdFile { get; set; }
    public long IdTag { get; set; }

    public virtual File IdFileNavigation { get; set; }
    public virtual Tag IdTagNavigation { get; set; }
}
