using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace aspnetserver.Data
{
    internal sealed class AppDBContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Post[] postToSeed = new Post[6];
            for(int i = 0; i < 6; i++)
            {
                postToSeed[i] = new Post
                {
                    PostId = i+10,
                    Title = $"Post {i}",
                    Content = $"This is post {i} and it has some very interesting content. I have also liked the video and subscribed."
                };

            }
            modelBuilder.Entity<Post>().HasData(postToSeed);
        }
    }
}
