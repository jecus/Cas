using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAA.Entity.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CAA.API
{
    
    [ApiController]
    [Route("files")]
    public class FileController : ControllerBase
    {
        private readonly ILogger<FileController> _logger;
        private readonly DataContext _context;

        public FileController(ILogger<FileController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet("{id}/info")]
        public async Task<IActionResult> GetInfoById(int id, bool getDeleted = false)
        {
            var file = await _context.
                AttachedFileDtos
                .Select(i => new
                {
                    i.ItemId,
                    i.IsDeleted,
                    i.CorrectorId,
                    i.Updated,
                    i.FileName,
                    i.FilePath,
                    i.FileSize,
                    i.StoreInDatabase,
                })
                .FirstOrDefaultAsync(i => i.ItemId == id && i.IsDeleted == getDeleted);
            
            return Ok(file);
        }
        
        [HttpPost("info")]
        public async Task<IActionResult> GetInfoByIds([FromBody]ModelIds model, bool getDeleted = false)
        {
            var file = await _context.
                AttachedFileDtos
                .Select(i => new
                {
                    i.ItemId,
                    i.IsDeleted,
                    i.CorrectorId,
                    i.Updated,
                    i.FileName,
                    i.FilePath,
                    i.FileSize,
                    i.StoreInDatabase,
                })
                .Where(i =>  model.Ids.Contains(i.ItemId) && i.IsDeleted == getDeleted).ToListAsync();
            
            return Ok(file);
        }
    }

    public class ModelIds
    {
        public ModelIds()
        {
            Ids = new List<int>();
        }
        public List<int> Ids { get; set; }
    }
}