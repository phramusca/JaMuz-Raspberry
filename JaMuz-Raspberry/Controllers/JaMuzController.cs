using JaMuzRaspberry.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace JaMuzRaspberry.Controllers;

[ApiController]
[Route("api")]
public class JaMuzController : ControllerBase
{
    private readonly ILogger<JaMuzController> _logger;

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
}
