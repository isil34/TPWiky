using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TPWikyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Commentaire> Commentaires{ get; set; }

        public TPWikyContext(DbContextOptions<TPWikyContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var g = new Article() { Id = 1, Contenu = "Message 1", Theme = "Roadster", DateCreation = DateOnly.Parse("04/01/2024"), 
                                    DateModification = DateOnly.Parse("04/01/2024"), Auteur="Yoann", Commentaires=new List<Commentaire>() };
            var c1 = new Commentaire() { Auteur="Yoann", Contenu="Les roadsters c'est bien mais ça prend le vent !", 
                                        DateCreation = DateOnly.Parse("04/01/2024"), DateModification = DateOnly.Parse("04/01/2024"), Id=1 , ArticleId=g.Id};


            modelBuilder.Entity<Commentaire>().HasData(c1);
            modelBuilder.Entity<Article>().HasData(g);

            base.OnModelCreating(modelBuilder);
        }
    }
}
