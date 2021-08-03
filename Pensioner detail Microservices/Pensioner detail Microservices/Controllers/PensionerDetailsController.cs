using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pensioner_detail_Microservices.Models;

namespace Pensioner_detail_Microservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PensionerDetailsController : ControllerBase
    {
        private readonly Context _context;

        public PensionerDetailsController(Context context)
        {
            _context = context;
        }

        // GET: api/PensionerDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PensionerDetails>>> GetPensioners()
        {
            List<PensionerDetails> users = new List<PensionerDetails>();
            var fileName = "./PensionerData1.xlsx";
            // For .net core, the next line requires the NuGet package, 
            // System.Text.Encoding.CodePages
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    while (reader.Read()) //Each row of the file
                    {
                        users.Add(new PensionerDetails
                        {
                            PAN = reader.GetValue(0).ToString(),
                            Name = reader.GetValue(1).ToString(),
                            Dateofbirth = reader.GetValue(2).ToString(),
                            SalaryEarned = Convert.ToInt32(reader.GetValue(3).ToString()),
                            Allowances = Convert.ToInt32(reader.GetValue(4).ToString()),
                            SelforFamilypension = reader.GetValue(5).ToString(),
                            bank_name = reader.GetValue(6).ToString(),
                            accountNumber = reader.GetValue(7).ToString(),
                            typeofbank = reader.GetValue(8).ToString()
                        });
                    }
                }
            }
            return users.ToList(); //await _context.Pensioners.ToListAsync();
        }

        // GET: api/PensionerDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PensionerDetails>> GetPensionerDetails(string id)
        {
            /* var pensionerDetails = await _context.Pensioners.FindAsync(id);

             if (pensionerDetails == null)
             {
                 return NotFound();
             }
            */
            List<PensionerDetails> users = new List<PensionerDetails>();
            var fileName = "./PensionerData1.xlsx";
            // For .net core, the next line requires the NuGet package, 
            // System.Text.Encoding.CodePages
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    while (reader.Read()) //Each row of the file
                    {
                        users.Add(new PensionerDetails
                        {
                            PAN = reader.GetValue(0).ToString(),
                            Name = reader.GetValue(1).ToString(),
                            Dateofbirth = reader.GetValue(2).ToString(),
                            SalaryEarned = Convert.ToInt32(reader.GetValue(3).ToString()),
                            Allowances = Convert.ToInt32(reader.GetValue(4).ToString()),
                            SelforFamilypension = reader.GetValue(5).ToString(),
                            bank_name = reader.GetValue(6).ToString(),
                            accountNumber = reader.GetValue(7).ToString(),
                            typeofbank = reader.GetValue(8).ToString()
                        });
                    }
                }
            }
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].PAN == id)
                {
                    return users[i];
                }
            }
            return null;
        }

        // PUT: api/PensionerDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPensionerDetails(string id, PensionerDetails pensionerDetails)
        {
            if (id != pensionerDetails.PAN)
            {
                return BadRequest();
            }

            _context.Entry(pensionerDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PensionerDetailsExists(id))
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

        // POST: api/PensionerDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PensionerDetails>> PostPensionerDetails(PensionerDetails pensionerDetails)
        {
            _context.Pensioners.Add(pensionerDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PensionerDetailsExists(pensionerDetails.PAN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPensionerDetails", new { id = pensionerDetails.PAN }, pensionerDetails);
        }

        // DELETE: api/PensionerDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePensionerDetails(string id)
        {
            var pensionerDetails = await _context.Pensioners.FindAsync(id);
            if (pensionerDetails == null)
            {
                return NotFound();
            }

            _context.Pensioners.Remove(pensionerDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PensionerDetailsExists(string id)
        {
            return _context.Pensioners.Any(e => e.PAN == id);
        }
    }
}
