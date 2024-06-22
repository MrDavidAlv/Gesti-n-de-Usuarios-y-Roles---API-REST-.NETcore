using empleadosFYMtech.Interfaces;
using empleadosFYMtech.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace empleadosFYMtech.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParametersController : ControllerBase
    {
        private readonly IParametersService _parametersService;

        public ParametersController(IParametersService parametersService)
        {
            _parametersService = parametersService;
        }

        // Endpoint para consultar los países
        [HttpGet("paises")]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPaises()
        {
            var paises = await _parametersService.GetPaisesAsync();
            return Ok(paises);
        }

        // Endpoint para consultar las ciudades
        [HttpGet("ciudades")]
        public async Task<ActionResult<IEnumerable<Ciudad>>> GetCiudades()
        {
            var ciudades = await _parametersService.GetCiudadesAsync();
            return Ok(ciudades);
        }

        // Endpoint para consultar las ciudades por país
        [HttpGet("ciudades/{idPais}")]
        public async Task<ActionResult<IEnumerable<Ciudad>>> GetCiudadesByPais(int idPais)
        {
            var ciudades = await _parametersService.GetCiudadesByPaisAsync(idPais);
            return Ok(ciudades);
        }
    }
}
