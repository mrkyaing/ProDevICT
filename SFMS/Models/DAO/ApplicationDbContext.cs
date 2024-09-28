using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SFMS.Models.DAO
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUsers(builder);
            this.SeedRoles(builder);
            this.SeedUserRoles(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            IdentityUser user = new IdentityUser()
            {
                Id = "U1",
                UserName = "Admin",
                NormalizedUserName = "Admin",
                PasswordHash = "Admin@123",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "09256275319"
            };
            builder.Entity<IdentityUser>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "R1", Name = "Admin", ConcurrencyStamp = DateTime.Now.ToString(), NormalizedName = "Admin" },
                new IdentityRole() { Id = "R2", Name = "Teacher", ConcurrencyStamp = DateTime.Now.ToString(), NormalizedName = "Teacher" },
                 new IdentityRole() { Id = "R3", Name = "Student", ConcurrencyStamp = DateTime.Now.ToString(), NormalizedName = "Student" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "U1", UserId = "R1" }
                );
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<FinePolicy> FinePolicies { get; set; }
        public DbSet<FineTransaction> FineTransactions { get; set; }
        public DbSet<TeacherCourses> TeacherCourses { get; set; }
        public DbSet<ContactAnyQuery> ContactAnyQueries { get; set; }
        public DbSet<NewStudentRegister> NewStudentRegisters { get; set; }
    }
}
