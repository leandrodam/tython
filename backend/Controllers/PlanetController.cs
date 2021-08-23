using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tython.Data;
using Tython.Models;

namespace Tython.Controllers
{
    [ApiController]
    [Route("/v1/planets")]
    public class PlanetController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Planet>>> Get([FromServices] DataContext context)
        {
            var planets = await context.Planets
                .Include(planet => planet.Region)
                .ToListAsync();
            return planets;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Planet>> GetById([FromServices] DataContext context, int id)
        {
            var planet = await context.Planets
                .Include(planet => planet.Region)
                .AsNoTracking()
                .FirstOrDefaultAsync(planet => planet.Id == id);
            return planet;
        }

        [HttpGet]
        [Route("regions/{id:int}")]
        public async Task<ActionResult<List<Planet>>> GetByRegion([FromServices] DataContext context, int id)
        {
            var planet = await context.Planets
                .Include(planet => planet.Region)
                .AsNoTracking()
                .Where(planet => planet.RegionId == id)
                .ToListAsync();
            return planet;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Planet>> Post([FromServices] DataContext context, [FromBody] Planet model)
        {
            if (ModelState.IsValid)
            {
                context.Planets.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}