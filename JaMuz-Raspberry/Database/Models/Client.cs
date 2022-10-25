namespace JaMuzRaspberry.Database.Models;

public partial class Client
{
    public long IdClient { get; set; }
    public string Login { get; set; }
    public string Pwd { get; set; }
    public string Name { get; set; }
    public long? IdDevice { get; set; }
    public long? IdStatSource { get; set; }
    public byte[] Enabled { get; set; }

    public virtual Device IdDeviceNavigation { get; set; }
    public virtual StatSource IdStatSourceNavigation { get; set; }
}
