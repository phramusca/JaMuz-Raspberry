using JaMuzRaspberry.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using NAudio.Wave;
using System.Collections.Generic;
using System.Linq;

namespace JaMuzRaspberry.Controllers;

[ApiController]
[Route("api")]
public class JaMuzController : ControllerBase
{
    private readonly ILogger<JaMuzController> _logger;
    private static WaveOutEvent outputDevice;
    private static AudioFileReader audioFile;

    public JaMuzController(ILogger<JaMuzController> logger)
    {
        _logger = logger;
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
    public IActionResult PlayFile([FromRoute] int id)
    {
        PlayFile();
        return Ok();
    }

    [HttpGet("/stop")]
    public IActionResult StopFile()
    {
        outputDevice?.Stop();
        return Ok();
    }

    private void PlayFile()
    {
        var filename = @"C:\Users\xxxx.mp3";
        if (outputDevice == null)
        {
            outputDevice = new WaveOutEvent();
            outputDevice.PlaybackStopped += OnPlaybackStopped;
        }
        if (audioFile == null)
        {
            audioFile = new AudioFileReader(filename);
            outputDevice.Init(audioFile);
        }
        outputDevice.Play();
    }

    private void OnPlaybackStopped(object sender, StoppedEventArgs args)
    {
        outputDevice.Dispose();
        outputDevice = null;
        audioFile.Dispose();
        audioFile = null;
    }
}