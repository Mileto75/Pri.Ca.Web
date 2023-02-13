using Microsoft.EntityFrameworkCore;
using Pri.Ca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Infrastructure.Data
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //Games
            var games = new Game[]
            {
                new Game{ Id = 1,Name="Fifa2000"},
                new Game{ Id = 2,Name="Wolfenstein"},
                new Game{ Id = 3,Name="Minecraft"}
            };
            //categories
            var categories = new Category[]
            {
                new Category { Id = 1, Name = "Sports" },
                new Category { Id = 2, Name = "Action" },
                new Category { Id = 3, Name = "Kids" }
            };
            //CategoryGame
            var categoryGames = new[]
            {
                new {GamesId=1,CategoriesId=1 },
                new {GamesId=1,CategoriesId=2 },
                new {GamesId=1,CategoriesId=3 },
                new {GamesId=2,CategoriesId=1 },
                new {GamesId=2,CategoriesId=3 },
                new {GamesId=2,CategoriesId=2 },
                new {GamesId=3,CategoriesId=1 },
                new {GamesId=3,CategoriesId=2 },
            };
            //hasdata methods
            modelBuilder.Entity<Game>().HasData(games);
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity($"{nameof(Category)}{nameof(Game)}").HasData(categoryGames);
        }
    }
}
