using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;
using System.ComponentModel;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            try
            {
                var hero = await _superHeroService.GetAllHeroes();
                return Ok(hero);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetSingleHeroById([FromRoute] int id)
        {
            var hero = await _superHeroService.GetSingleHeroById(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (hero is null)
                return NotFound("Superhero does not exist.");

            return Ok(hero);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody] SuperHero hero)
        {
           if (!ModelState.IsValid) { return BadRequest(ModelState); }

           var superHero = await _superHeroService.AddHero(hero);

           return Ok(superHero);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero([FromRoute] int id, [FromBody] SuperHero hero)
        {
            if (hero is null)
                return NotFound("Superhero does not exist.");

            var superHero = await _superHeroService.UpdateHero(id, hero);

            if (!ModelState.IsValid) return NotFound(ModelState);

            return Ok(superHero);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> DeleteHero([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _superHeroService.SuperHeroExistsAsync(id))
                return NotFound("Superhero does not exist.");

            var hero = await _superHeroService.DeleteHero(id);
            
            return Ok(hero);
        }
    }
}

