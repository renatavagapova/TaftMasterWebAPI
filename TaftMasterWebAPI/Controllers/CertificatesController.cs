using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using TaftMasterWebAPI.Data;
using TaftMasterWebAPI.Models;

namespace TaftMasterWebAPI.Controllers
{
    [Route("api/certificates")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CertificatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Certificate>>> GetCerts()
        {
            return await _context.Certificates.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Certificate>> GetCert(int id)
        {
            var cert = await _context.Certificates.FindAsync(id);
            if (cert == null) return NotFound();
            return cert;
        }

        [HttpPost]
        public async Task<ActionResult<Certificate>> AddCert(Certificate cert)
        {
            _context.Certificates.Add(cert);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCert), new { id = cert.Id }, cert);
        }
    }
}