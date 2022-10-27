# JaMuz-Raspberry

/!\ UNDER DEVELOPMENT /!\

A Web Api to play audio files from JaMuz database on a Raspberry, from Jamuz-Remote.

## Prerequisites

### Raspberry

- [Install Raspberry Pi OS](https://www.raspberrypi.com/software/) (by Raspberry)
- Install LibVLC using "[Getting started on LibVLCSharp for Linux](https://code.videolan.org/videolan/LibVLCSharp/-/blob/3.x/docs/linux-setup.md)" guide by VLC team.
- Deploy the application
  - Enable SSH and install dotnet on your Raspberry using "[Deploy .NET apps to Raspberry Pi](https://learn.microsoft.com/en-us/dotnet/iot/deployment)" guid by Microsoft.
  - Here is my script to deploy and connect to Raspberry. You can adapt it to suit your case:

```bash
sshfs pi@192.168.1.145:/ /media/raph/recalbox/
rsync -a --progress --exclude={'**/bin**','**/obj'} ~/Documents/04-Creations/Dev/Repos/JaMuz-Raspberry /media/raph/recalbox/home/pi/Documents
ssh pi@192.168.1.145
```

### Linux

- [Install dotnet on Ubuntu](https://learn.microsoft.com/fr-fr/dotnet/core/install/linux-ubuntu) (by Microsoft)
- [Getting started on LibVLCSharp for Linux](https://code.videolan.org/videolan/LibVLCSharp/-/blob/3.x/docs/linux-setup.md) (by VLC)

### Windows

- [Install dotnet](https://dotnet.microsoft.com/en-us/download) (by Microsoft)

## Run

```bash
cd Documents/JaMuz-Raspberry/
cd ~/Documents/JaMuz-Raspberry/JaMuz-Raspberry/
dotnet run
```

## Resources

- [Tutoriel : Création d’une API web avec ASP.NET Core](https://learn.microsoft.com/fr-fr/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio) (by Microsoft)
- Eventually, [Use C# and .NET to develop your own GUI apps for the Raspberry Pi](https://tutorials-raspberrypi.com/write-raspberry-pi-gui-apps-c-sharp-dot-net/) [check if it works with Avalonia first]
