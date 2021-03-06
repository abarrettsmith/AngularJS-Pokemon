namespace Pokemon.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pokemon.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Pokemon.Models.ApplicationDbContext context)
        {

            context.Pokemons.AddOrUpdate(
                x => x.Name,
                new Pokemon.Models.Pokemon() { Name = "Pikachu", Type = "Electric" },
                new Pokemon.Models.Pokemon() { Name = "Charizard", Type = "Fire" },
                new Pokemon.Models.Pokemon() { Name = "Squirtle", Type = "Water" }
                );
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
