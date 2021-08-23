using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tython.Data;
using Tython.Models;

namespace Tython.Controllers
{
    [ApiController]
    [Route("/v1/regions")]
    public class RegionController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Region>>> Get([FromServices] DataContext context)
        {
            var regions = await context.Regions.ToListAsync();
            return regions;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Region>> Post([FromServices] DataContext context, [FromBody] Region model)
        {
            if (ModelState.IsValid)
            {
                context.Regions.Add(model);
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