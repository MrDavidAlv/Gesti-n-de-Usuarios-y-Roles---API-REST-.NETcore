using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using empleadosFYMtech.Data;
using empleadosFYMtech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace empleadosFYMtech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametricController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParametricController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("paises")]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPaises()
        {
            return Ok(await _context.Paises.ToListAsync());
        }

        [HttpGet("ciudades")]
        public async Task<ActionResult<IEnumerable<Ciudad>>> GetCiudades()
        {
            return Ok(await _context.Ciudades.ToListAsync());
        }

        [HttpGet("ciudades/{idPais}")]
        public async Task<ActionResult<IEnumerable<Ciudad>>> GetCiudadesByPais(int idPais)
        {
            return Ok(await _context.Ciudades.Where(c => c.IdPais == idPais).ToListAsync());
        }
    }
}
