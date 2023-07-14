using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                Name = "SpiderMan",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York City"
            }
        };

        public List<SuperHero> AddHero(SuperHero hero)
        {
            //if (hero == null) return null;
            var superHero = superHeroes.Find(x => x.Id == hero.Id);
            
            superHeroes.Add(hero);
            
            return superHeroes;
        }

        public List<SuperHero> DeleteHero(int id)
        {
            var superHero = superHeroes.Find(x => x.Id == id);
            if (superHero == null) return null;

            superHeroes.Remove(superHero);
            return superHeroes;
        }

        public List<SuperHero> GetAllHeroes()
        {
            return superHeroes;
        }

        public SuperHero GetSingleHeroById(int id)
        {
            var superHero = superHeroes.Where(x => x.Id == id).FirstOrDefault();


            if (superHero == null)
            {
                return null;
            }

            return superHero;
        }

        public List<SuperHero> UpdateHero(int id, SuperHero hero)
        {
            var superHero = superHeroes.Find(x => x.Id == id);

            if (superHero == null)
                return null;

            superHero.FirstName = hero.FirstName;
            superHero.LastName = hero.LastName;
            superHero.Name = hero.Name;
            superHero.Place = hero.Place;

            //superHeroes.Add(hero);
            return superHeroes;
        }
    }
}