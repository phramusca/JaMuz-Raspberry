using JaMuzRaspberry.Database.Models;
using LibVLCSharp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JaMuzRaspberry.Controllers;

[ApiController]
[Route("api")]
public class JaMuzController : ControllerBase
{
    private readonly ILogger<JaMuzController> _logger;
    private static LibVLC _libVLC;
    private static MediaPlayer _mediaPlayer;

    public JaMuzController(ILogger<JaMuzController> logger)
    {
        _logger = logger;
        _libVLC = new LibVLC(enableDebugLogs: true);
    }

    [HttpGet("marley")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<File>))]
    public IActionResult Get()
    {
        try
        {
            using var db = new Database.JaMuzContext();
            var files = db.File
                .Where(b => b.Rating > 3 && b.Artist.Contains("Marley"))
                .OrderBy(b => b.TrackNo)
                .ToList();
            return Ok(files);
        } catch(SqliteException ex)
        {
            _logger.LogError(ex, "Error in Get");
            return NotFound(ex.Message);
        }
    }

    [HttpGet("play/{id}")]
    public IActionResult PlayFile([FromRoute] long id)
    {
        if(_mediaPlayer != null && _mediaPlayer.IsPlaying)
        {
            return BadRequest("Already playing");
        }
        using var db = new Database.JaMuzContext();
        File file = db.File.Find(id);
        Path path = db.Path.Find(file.IdPath);
        //var rootPath = "/home/raph/Musique/Archive";
        var rootPath = "/media/pi/MAXTOR/Musique-BAK/Archive";
        var filename = System.IO.Path.Combine(rootPath, path.StrPath, file.Name);
        var media = new Media(_libVLC, new Uri(filename), ":no-video");
        _mediaPlayer = new MediaPlayer(media);

        //mediaPlayer.SetAudioFormatCallback(AudioSetup, AudioCleanup);
        //mediaPlayer.SetAudioCallbacks(PlayAudio, PauseAudio, ResumeAudio, FlushAudio, DrainAudio);

        _mediaPlayer.Play();
        //mediaPlayer.Time = 20_000; // Seek the video 20 seconds

        return Ok();
    }

    [HttpGet("/stop")]
    public IActionResult StopFile()
    {
        _mediaPlayer?.Stop();
        return Ok();
    }

    //private void OnPlaybackStopped(object sender, StoppedEventArgs args)
    //{
    //    outputDevice.Dispose();
    //    outputDevice = null;
    //    audioFile.Dispose();
    //    audioFile = null;
    //}
}