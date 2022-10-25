using System.Collections.Generic;

namespace JaMuzRaspberry.Database.Models;

public partial class File
{
    public File()
    {
        DeviceFile = new HashSet<DeviceFile>();
        PlayCounterNavigation = new HashSet<PlayCounter>();
        Tagfile = new HashSet<Tagfile>();
    }

    public long IdFile { get; set; }
    public long IdPath { get; set; }
    public string Name { get; set; }
    public long Rating { get; set; }
    public string LastPlayed { get; set; }
    public long PlayCounter { get; set; }
    public string AddedDate { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }
    public string AlbumArtist { get; set; }
    public string Title { get; set; }
    public long TrackNo { get; set; }
    public long TrackTotal { get; set; }
    public long DiscNo { get; set; }
    public long DiscTotal { get; set; }
    public string Genre { get; set; }
    public string Year { get; set; }
    public double Bpm { get; set; }
    public string Comment { get; set; }
    public long NbCovers { get; set; }
    public string BitRate { get; set; }
    public string Format { get; set; }
    public long Length { get; set; }
    public long Size { get; set; }
    public string ModifDate { get; set; }
    public long Deleted { get; set; }
    public string CoverHash { get; set; }
    public string RatingModifDate { get; set; }
    public string TagsModifDate { get; set; }
    public string GenreModifDate { get; set; }
    public long Saved { get; set; }

    public virtual Path IdPathNavigation { get; set; }
    public virtual ICollection<DeviceFile> DeviceFile { get; set; }
    public virtual ICollection<PlayCounter> PlayCounterNavigation { get; set; }
    public virtual ICollection<Tagfile> Tagfile { get; set; }
}
