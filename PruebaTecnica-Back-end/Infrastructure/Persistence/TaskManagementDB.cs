using Microsoft.EntityFrameworkCore;
using PruebaTecnica_Back_end.Domain.Entities;

namespace PruebaBackend.Infrastructure.Persistence
{

    public class TaskManagementDB : DbContext
    {
        public TaskManagementDB(DbContextOptions<TaskManagementDB> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(tb =>
            {
                tb.HasKey(col => col.Id);
                tb.Property(col => col.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
                tb.Property(col => col.UserName).HasMaxLength(50);
                tb.Property(col => col.Email).HasMaxLength(50);
                tb.Property(col => col.Password).HasMaxLength(50);
                tb.Property(col => col.Role).HasMaxLength(50);
            });
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1, 
                UserName = "admin",
                Email = "admin@gmail.com",
                Password = "Admin123", 
                Role = "Admin"
            });

            modelBuilder.Entity<TaskItem>(tb =>
            {

                tb.HasKey(col => col.TaskId);
                tb.Property(col => col.TaskId)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd();
                tb.Property(col => col.Title).HasMaxLength(50);
                tb.Property(col => col.Description).HasMaxLength(50);
                tb.Property(col => col.Status).HasMaxLength(50);
                tb.Property(col => col.AssignedTo).HasMaxLength(50);
            });
            modelBuilder.Entity<TaskItem>().ToTable("TasksItem");
        }
    }
}
