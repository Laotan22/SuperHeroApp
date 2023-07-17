using Microsoft.AspNetCore.Http.HttpResults;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;
using System.ComponentModel;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {

        //private static List<SuperHero> superHeroes = new List<SuperHero>
        //{
        //    new SuperHero
        //    {
        //        Id = 1,
        //        Name = "SpiderMan",
        //        FirstName = "Peter",
        //        LastName = "Parker",
        //        Place = "New York City"
        //    }
        //};

        private readonly DataContext _context;
        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await Save();

            return await _context.SuperHeroes.ToListAsync(); 
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero>? GetSingleHeroById(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            return hero;
        }

        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero hero)
        {
            var superHero = await _context.SuperHeroes.FindAsync(id);
            if (superHero is null) return null;

            superHero.FirstName = hero.FirstName;
            superHero.LastName = hero.LastName;
            superHero.Name = hero.Name;
            superHero.Place = hero.Place;
            //mapping with auto mapper solves this issue.

            await Save();

            return await _context.SuperHeroes.ToListAsync(); ;
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            _context.SuperHeroes.Remove(hero);

            await Save();

            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> SuperHeroExistsAsync(int id)
        {
            bool exists = await _context.SuperHeroes.AnyAsync(p => p.Id == id);
            return exists;
        }
    }
}