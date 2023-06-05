using App.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace App.DAL.DataContext
{
    public class DbPetsContext : DbContext
    {
        public DbPetsContext(DbContextOptions<DbPetsContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cat1 = new Category { Id = 1, Name = "Mammals" };
            var cat2 = new Category { Id = 2, Name = "Birds" };
            var cat3 = new Category { Id = 3, Name = "Fish" };
            var cat4 = new Category { Id = 4, Name = "Reptiles" };
            var cat5 = new Category { Id = 5, Name = "Amphibians" };

            modelBuilder.Entity<Category>().HasData(cat1, cat2, cat3, cat4, cat5);

            modelBuilder.Entity<Animal>().HasData(
                new Animal { Id = 1, Name = "Eagle", Age = 2, CategoryId = cat2.Id, Description = "A majestic bird known for soaring flight.", PictureName = "Eagle.jpg" },
                new Animal { Id = 2, Name = "Lizard", Age = 3, CategoryId = cat4.Id, Description = "A scaly reptile with the ability to regenerate its tail.", PictureName = "Lizard.jpg" },
                new Animal { Id = 3, Name = "Dog", Age = 4, CategoryId = cat1.Id, Description = "A loyal and domesticated mammal often kept as a pet.", PictureName = "Dog.jpg" },
                new Animal { Id = 4, Name = "Bass", Age = 1, CategoryId = cat3.Id, Description = "A popular freshwater fish among anglers.", PictureName = "Bass.jpg" },
                new Animal { Id = 5, Name = "Tiger", Age = 7, CategoryId = cat1.Id, Description = "A powerful carnivorous mammal with distinctive orange fur and black stripes.", PictureName = "Tiger.jpg" },
                new Animal { Id = 6, Name = "Parrot", Age = 2, CategoryId = cat2.Id, Description = "A colorful bird known for mimicking human speech.", PictureName = "Parrot.jpg" },
                new Animal { Id = 7, Name = "Salmon", Age = 2, CategoryId = cat3.Id, Description = "A migratory fish that spawns in freshwater and returns to the ocean.", PictureName = "Salmon.jpg" },
                new Animal { Id = 8, Name = "Snake", Age = 6, CategoryId = cat4.Id, Description = "A long, legless reptile with slithering movement.", PictureName = "Snake.jpg" },
                new Animal { Id = 9, Name = "Frog", Age = 1, CategoryId = cat5.Id, Description = "An amphibian with a unique life cycle including a tadpole stage.", PictureName = "Frog.jpg" },
                new Animal { Id = 10, Name = "Cheetah", Age = 5, CategoryId = cat1.Id, Description = "A swift-running mammal known for incredible speed and agility.", PictureName = "Cheetah.jpg" }
            );

            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = 1, AnimalId = 1, Text = "I Love Eagles" },
                new Comment { Id = 2, AnimalId = 1, Text = "Woww" },
                new Comment { Id = 3, AnimalId = 1, Text = "Amazing" },
                new Comment { Id = 4, AnimalId = 1, Text = "I wish i had wings" },
                new Comment { Id = 5, AnimalId = 5, Text = "Thats the best tiger i ever saw" },
                new Comment { Id = 6, AnimalId = 5, Text = "How much does it cost?" },
                new Comment { Id = 8, AnimalId = 5, Text = "Should i be scared?" },
                new Comment { Id = 9, AnimalId = 2, Text = "I Had a lizerd once" },
                new Comment { Id = 10, AnimalId = 3, Text = "Reminds me of sparky :D" },
                new Comment { Id = 11, AnimalId = 4, Text = "I was looking for bass guitar and somehow got here??" },
                new Comment { Id = 12, AnimalId = 6, Text = "Repet after me 'I Love Coco'" },
                new Comment { Id = 13, AnimalId = 7, Text = "Great now Im hungry" },
                new Comment { Id = 14, AnimalId = 8, Text = "Ohhh helll nah" },
                new Comment { Id = 15, AnimalId = 9, Text = "Aww thats cute!" },
                new Comment { Id = 16, AnimalId = 10, Text = "I ben I can outrun her ptf.." }
                );

        }


    }
}
