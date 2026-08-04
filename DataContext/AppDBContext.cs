using InterviewPrepApp.Models;
using Microsoft.EntityFrameworkCore;
namespace InterviewPrepApp.DataContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<TopicsModel> Topics { get; set; }
        public DbSet<QuestionsModel> Questions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TopicsModel>()
                .HasOne(t => t.Category)
                .WithMany()
                .HasForeignKey(t => t.CategoryId);
        }


    }
}
