using Pokemon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pokemon.Controllers
{
    public class PokemonController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<Pokemon.Models.Pokemon> pokemons;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                pokemons = db.Pokemons.ToList();
            }
            return Ok(pokemons);
        }

        public IHttpActionResult Get(int id)
        {
            Pokemon.Models.Pokemon pokemon;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                pokemon = db.Pokemons.Find(id);
            }
            return Ok(pokemon);
        }

        public IHttpActionResult Post(Pokemon.Models.Pokemon pokemon)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Pokemons.Add(pokemon);
                db.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult PUT(Pokemon.Models.Pokemon pokemon)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var currentPokemon = db.Pokemons.Find(pokemon.Id);
                currentPokemon.Name = pokemon.Name;
                currentPokemon.Type = pokemon.Type;
                db.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult DELETE(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var currentPokemon = db.Pokemons.Find(id);
                db.Pokemons.Remove(currentPokemon);
                db.SaveChanges();
            }
            return Ok();
        }
    }
}
