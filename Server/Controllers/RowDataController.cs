using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SingleGridFormWebApp.Server;
using SingleGridFormWebApp.Shared;

namespace SingleGridFormWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RowDataController : ControllerBase
    {
        private readonly FormContext _context;

        public RowDataController(FormContext context)
        {
            _context = context;
        }

        // GET: api/RowData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RowData>>> GetRowDataSet()
        {
            return await _context.RowDataSet.ToListAsync();
        }

        // GET: api/RowData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RowData>> GetRowData(int id)
        {
            var rowData = await _context.RowDataSet.FindAsync(id);

            if (rowData == null)
            {
                return NotFound();
            }

            return rowData;
        }

        // PUT: api/RowData/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRowData(int id, RowData rowData)
        {
            if (id != rowData.Id)
            {
                return BadRequest();
            }

            _context.Entry(rowData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RowDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RowData
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RowData>> PostRowData(RowData rowData)
        {
            _context.RowDataSet.Add(rowData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRowData", new { id = rowData.Id }, rowData);
        }

        // DELETE: api/RowData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRowData(int id)
        {
            var rowData = await _context.RowDataSet.FindAsync(id);
            if (rowData == null)
            {
                return NotFound();
            }

            _context.RowDataSet.Remove(rowData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RowDataExists(int id)
        {
            return _context.RowDataSet.Any(e => e.Id == id);
        }
    }
}
