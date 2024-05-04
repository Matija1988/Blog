using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        { 
            
        
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, 
                    Name="Action", 
                    CategoryDescription= "Genre that focuses on stories that involve high-stakes, high-energy, and fast-paced events", 
                    DisplayOrder= 1 },
                new Category { 
                    Id = 2, 
                    Name = "SciFi", 
                    CategoryDescription= "Genre of speculative fiction, which typically deals with imaginative and futuristic concepts such as advanced science and technology, space exploration, time travel, parallel universes, and extraterrestrial life. ",
                    DisplayOrder = 2 },
                new Category { Id = 3,
                    Name = "Hard SciFi", 
                    CategoryDescription = "Hard science fiction is a category of science fiction characterized by concern for scientific accuracy and logic.",
                    DisplayOrder = 3 }
                );
        }
    }
}
