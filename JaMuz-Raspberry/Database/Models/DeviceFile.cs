namespace JaMuzRaspberry.Database.Models;

public partial class DeviceFile
{
    public long IdFile { get; set; }
    public long IdDevice { get; set; }
    public string OriRelativeFullPath { get; set; }

    public virtual Device IdDeviceNavigation { get; set; }
    public virtual File IdFileNavigation { get; set; }
}
