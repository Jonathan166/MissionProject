using MissionProject.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace XaviersSchool.Models
{
    public class MissionContext : DbContext
    {
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Mutant> Mutants { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}