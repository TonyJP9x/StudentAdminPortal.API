using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace StudentAdminPortal.API.Entities
{
    public class StudentAdminContext : DbContext
    {
        public StudentAdminContext(DbContextOptions<StudentAdminContext> options) : base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Address> Address { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTrackingEntites();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTrackingEntites()
        {
            var changeTracker = ChangeTracker.Entries();
            foreach (var entity in changeTracker)
            {
                switch (entity.State)
                {
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        break;
                    case EntityState.Added:
                        break;
                }
            }
        }

        private void ModifyChangeTracker(EntityEntry entity)
        {

        }
    }
}
