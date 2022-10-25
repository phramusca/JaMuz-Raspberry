using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DotMuz.Database.Models;

namespace DotMuz.Database
{
    public partial class JaMuzContext : DbContext
    {
        public JaMuzContext()
        {
        }

        public JaMuzContext(DbContextOptions<JaMuzContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<DeviceFile> DeviceFile { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Machine> Machine { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<OptionType> OptionType { get; set; }
        public virtual DbSet<Path> Path { get; set; }
        public virtual DbSet<PlayCounter> PlayCounter { get; set; }
        public virtual DbSet<Playlist> Playlist { get; set; }
        public virtual DbSet<PlaylistFilter> PlaylistFilter { get; set; }
        public virtual DbSet<PlaylistOrder> PlaylistOrder { get; set; }
        public virtual DbSet<StatSource> StatSource { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Tagfile> Tagfile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=JaMuz.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient);

                entity.ToTable("client");

                entity.HasIndex(e => e.Login)
                    .IsUnique();

                entity.Property(e => e.IdClient)
                    .HasColumnName("idClient")
                    .ValueGeneratedNever();

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasColumnType("BOOL");

                entity.Property(e => e.IdDevice).HasColumnName("idDevice");

                entity.Property(e => e.IdStatSource).HasColumnName("idStatSource");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasColumnName("pwd");

                entity.HasOne(d => d.IdDeviceNavigation)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.IdDevice)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.IdStatSourceNavigation)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.IdStatSource)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.IdDevice);

                entity.ToTable("device");

                entity.Property(e => e.IdDevice)
                    .HasColumnName("idDevice")
                    .ValueGeneratedNever();

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasColumnName("destination");

                entity.Property(e => e.IdMachine).HasColumnName("idMachine");

                entity.Property(e => e.IdPlaylist).HasColumnName("idPlaylist");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source");

                entity.HasOne(d => d.IdMachineNavigation)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.IdMachine);

                entity.HasOne(d => d.IdPlaylistNavigation)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.IdPlaylist);
            });

            modelBuilder.Entity<DeviceFile>(entity =>
            {
                entity.HasKey(e => new { e.IdFile, e.IdDevice, e.OriRelativeFullPath });

                entity.ToTable("deviceFile");

                entity.Property(e => e.IdFile).HasColumnName("idFile");

                entity.Property(e => e.IdDevice).HasColumnName("idDevice");

                entity.Property(e => e.OriRelativeFullPath).HasColumnName("oriRelativeFullPath");

                entity.HasOne(d => d.IdDeviceNavigation)
                    .WithMany(p => p.DeviceFile)
                    .HasForeignKey(d => d.IdDevice);

                entity.HasOne(d => d.IdFileNavigation)
                    .WithMany(p => p.DeviceFile)
                    .HasForeignKey(d => d.IdFile)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => e.IdFile);

                entity.ToTable("file");

                entity.Property(e => e.IdFile)
                    .HasColumnName("idFile")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddedDate)
                    .IsRequired()
                    .HasColumnName("addedDate");

                entity.Property(e => e.Album)
                    .IsRequired()
                    .HasColumnName("album");

                entity.Property(e => e.AlbumArtist)
                    .IsRequired()
                    .HasColumnName("albumArtist");

                entity.Property(e => e.Artist)
                    .IsRequired()
                    .HasColumnName("artist");

                entity.Property(e => e.BitRate)
                    .IsRequired()
                    .HasColumnName("bitRate");

                entity.Property(e => e.Bpm).HasColumnName("BPM");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment");

                entity.Property(e => e.CoverHash)
                    .IsRequired()
                    .HasColumnName("coverHash");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.DiscNo).HasColumnName("discNo");

                entity.Property(e => e.DiscTotal).HasColumnName("discTotal");

                entity.Property(e => e.Format)
                    .IsRequired()
                    .HasColumnName("format");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasColumnName("genre");

                entity.Property(e => e.GenreModifDate)
                    .IsRequired()
                    .HasColumnName("genreModifDate")
                    .HasDefaultValueSql("\"1970-01-01 00:00:00\"");

                entity.Property(e => e.IdPath).HasColumnName("idPath");

                entity.Property(e => e.LastPlayed)
                    .IsRequired()
                    .HasColumnName("lastPlayed");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.ModifDate)
                    .IsRequired()
                    .HasColumnName("modifDate");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.NbCovers).HasColumnName("nbCovers");

                entity.Property(e => e.PlayCounter).HasColumnName("playCounter");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RatingModifDate)
                    .IsRequired()
                    .HasColumnName("ratingModifDate")
                    .HasDefaultValueSql("\"1970-01-01 00:00:00\"");

                entity.Property(e => e.Saved).HasColumnName("saved");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.TagsModifDate)
                    .IsRequired()
                    .HasColumnName("tagsModifDate")
                    .HasDefaultValueSql("\"1970-01-01 00:00:00\"");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");

                entity.Property(e => e.TrackNo).HasColumnName("trackNo");

                entity.Property(e => e.TrackTotal).HasColumnName("trackTotal");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasColumnName("year");

                entity.HasOne(d => d.IdPathNavigation)
                    .WithMany(p => p.File)
                    .HasForeignKey(d => d.IdPath)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Machine>(entity =>
            {
                entity.HasKey(e => e.IdMachine);

                entity.ToTable("machine");

                entity.Property(e => e.IdMachine)
                    .HasColumnName("idMachine")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Hidden).HasColumnName("hidden");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasKey(e => e.IdOption);

                entity.ToTable("option");

                entity.Property(e => e.IdOption)
                    .HasColumnName("idOption")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdMachine).HasColumnName("idMachine");

                entity.Property(e => e.IdOptionType).HasColumnName("idOptionType");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");

                entity.HasOne(d => d.IdMachineNavigation)
                    .WithMany(p => p.Option)
                    .HasForeignKey(d => d.IdMachine);

                entity.HasOne(d => d.IdOptionTypeNavigation)
                    .WithMany(p => p.Option)
                    .HasForeignKey(d => d.IdOptionType)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OptionType>(entity =>
            {
                entity.HasKey(e => e.IdOptionType);

                entity.ToTable("optionType");

                entity.Property(e => e.IdOptionType)
                    .HasColumnName("idOptionType")
                    .ValueGeneratedNever();

                entity.Property(e => e.Default)
                    .IsRequired()
                    .HasColumnName("default");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Path>(entity =>
            {
                entity.HasKey(e => e.IdPath);

                entity.ToTable("path");

                entity.Property(e => e.IdPath)
                    .HasColumnName("idPath")
                    .ValueGeneratedNever();

                entity.Property(e => e.Checked).HasColumnName("checked");

                entity.Property(e => e.CopyRight).HasColumnName("copyRight");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.MbId).HasColumnName("mbId");

                entity.Property(e => e.ModifDate)
                    .IsRequired()
                    .HasColumnName("modifDate");

                entity.Property(e => e.StrPath)
                    .IsRequired()
                    .HasColumnName("strPath");
            });

            modelBuilder.Entity<PlayCounter>(entity =>
            {
                entity.HasKey(e => new { e.IdFile, e.IdStatSource });

                entity.ToTable("playCounter");

                entity.Property(e => e.IdFile).HasColumnName("idFile");

                entity.Property(e => e.IdStatSource).HasColumnName("idStatSource");

                entity.Property(e => e.PlayCounter1).HasColumnName("playCounter");

                entity.HasOne(d => d.IdFileNavigation)
                    .WithMany(p => p.PlayCounterNavigation)
                    .HasForeignKey(d => d.IdFile)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdStatSourceNavigation)
                    .WithMany(p => p.PlayCounter)
                    .HasForeignKey(d => d.IdStatSource);
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.HasKey(e => e.IdPlaylist);

                entity.ToTable("playlist");

                entity.Property(e => e.IdPlaylist)
                    .HasColumnName("idPlaylist")
                    .ValueGeneratedNever();

                entity.Property(e => e.Hidden).HasColumnName("hidden");

                entity.Property(e => e.LimitDo).HasColumnName("limitDo");

                entity.Property(e => e.LimitUnit)
                    .IsRequired()
                    .HasColumnName("limitUnit");

                entity.Property(e => e.LimitValue).HasColumnName("limitValue");

                entity.Property(e => e.Match)
                    .IsRequired()
                    .HasColumnName("match");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Random).HasColumnName("random");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<PlaylistFilter>(entity =>
            {
                entity.HasKey(e => e.IdPlaylistFilter);

                entity.ToTable("playlistFilter");

                entity.Property(e => e.IdPlaylistFilter)
                    .HasColumnName("idPlaylistFilter")
                    .ValueGeneratedNever();

                entity.Property(e => e.Field)
                    .IsRequired()
                    .HasColumnName("field");

                entity.Property(e => e.IdPlaylist).HasColumnName("idPlaylist");

                entity.Property(e => e.Operator)
                    .IsRequired()
                    .HasColumnName("operator");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");

                entity.HasOne(d => d.IdPlaylistNavigation)
                    .WithMany(p => p.PlaylistFilter)
                    .HasForeignKey(d => d.IdPlaylist)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PlaylistOrder>(entity =>
            {
                entity.HasKey(e => e.IdPlaylistOrder);

                entity.ToTable("playlistOrder");

                entity.Property(e => e.IdPlaylistOrder)
                    .HasColumnName("idPlaylistOrder")
                    .ValueGeneratedNever();

                entity.Property(e => e.Desc).HasColumnName("desc");

                entity.Property(e => e.Field)
                    .IsRequired()
                    .HasColumnName("field");

                entity.Property(e => e.IdPlaylist).HasColumnName("idPlaylist");

                entity.HasOne(d => d.IdPlaylistNavigation)
                    .WithMany(p => p.PlaylistOrder)
                    .HasForeignKey(d => d.IdPlaylist)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<StatSource>(entity =>
            {
                entity.HasKey(e => e.IdStatSource);

                entity.ToTable("statSource");

                entity.Property(e => e.IdStatSource)
                    .HasColumnName("idStatSource")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdDevice).HasColumnName("idDevice");

                entity.Property(e => e.IdMachine).HasColumnName("idMachine");

                entity.Property(e => e.IdStatement).HasColumnName("idStatement");

                entity.Property(e => e.LastMergeDate)
                    .IsRequired()
                    .HasColumnName("lastMergeDate")
                    .HasDefaultValueSql("\"1970-01-01 00:00:00\"");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.RootPath)
                    .IsRequired()
                    .HasColumnName("rootPath");

                entity.Property(e => e.Selected).HasColumnName("selected");

                entity.HasOne(d => d.IdDeviceNavigation)
                    .WithMany(p => p.StatSource)
                    .HasForeignKey(d => d.IdDevice);

                entity.HasOne(d => d.IdMachineNavigation)
                    .WithMany(p => p.StatSource)
                    .HasForeignKey(d => d.IdMachine);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tag");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Tagfile>(entity =>
            {
                entity.HasKey(e => new { e.IdFile, e.IdTag });

                entity.ToTable("tagfile");

                entity.Property(e => e.IdFile).HasColumnName("idFile");

                entity.Property(e => e.IdTag).HasColumnName("idTag");

                entity.HasOne(d => d.IdFileNavigation)
                    .WithMany(p => p.Tagfile)
                    .HasForeignKey(d => d.IdFile)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdTagNavigation)
                    .WithMany(p => p.Tagfile)
                    .HasForeignKey(d => d.IdTag);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
