using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero>? GetSingleHeroById(int id);
        Task<List<SuperHero>> AddHero(SuperHero hero);
        Task<List<SuperHero>?> UpdateHero(int id, SuperHero hero);
        Task<List<SuperHero>?> DeleteHero(int id);
        Task<bool> SuperHeroExistsAsync(int id);
    }
}
