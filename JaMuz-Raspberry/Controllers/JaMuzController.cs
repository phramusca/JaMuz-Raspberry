using JaMuzRaspberry.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace JaMuzRaspberry.Controllers;

[ApiController]
[Route("[controller]")]
public class JaMuzController : ControllerBase
{
    private readonly ILogger<JaMuzController> _logger;

    public JaMuzController(ILogger<JaMuzController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public List<File> Get()
    {
        try
        {
            using (var db = new Database.JaMuzContext())
            {
                var files = db.File
                    .Where(b => b.Rating > 3 && b.Artist.Contains("Marley"))
                    .OrderBy(b => b.TrackNo)
                    .ToList();

                return files;
            }
        } catch(SqliteException ex)
        {
            _logger.LogError(ex, "Error in Get");
            return null;
        }
    }
}
