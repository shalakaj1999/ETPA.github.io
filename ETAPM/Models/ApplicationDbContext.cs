namespace ETAPM.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }
         
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<ExtraTimeRequest> ExtraTimeRequests { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<TaskFile> TaskFiles { get; set; }
    }
}
