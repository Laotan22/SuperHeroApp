using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> GetAllHeroes();
        SuperHero GetSingleHeroById(int id);
        List<SuperHero> AddHero(SuperHero hero);
        List<SuperHero> UpdateHero(int id, SuperHero hero);
        List<SuperHero> DeleteHero(int id);
    }
}
