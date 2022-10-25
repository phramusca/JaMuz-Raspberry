using System.Collections.Generic;

namespace JaMuzRaspberry.Database.Models;

public partial class Device
{
    public Device()
    {
        Client = new HashSet<Client>();
        DeviceFile = new HashSet<DeviceFile>();
        StatSource = new HashSet<StatSource>();
    }

    public long IdDevice { get; set; }
    public string Name { get; set; }
    public string Source { get; set; }
    public string Destination { get; set; }
    public long? IdPlaylist { get; set; }
    public long IdMachine { get; set; }

    public virtual Machine IdMachineNavigation { get; set; }
    public virtual Playlist IdPlaylistNavigation { get; set; }
    public virtual ICollection<Client> Client { get; set; }
    public virtual ICollection<DeviceFile> DeviceFile { get; set; }
    public virtual ICollection<StatSource> StatSource { get; set; }
}
