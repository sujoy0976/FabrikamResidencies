using Microsoft.EntityFrameworkCore;
using FabrikamResidences_Activities.Models;
using System;
using System.Threading.Tasks;

namespace FabrikamResidences_Activities.Data
{
    public class ActivityContext : DbContext
    {
        public ActivityContext(DbContextOptions<ActivityContext> options)
        : base(options)
        { }

        public DbSet<ActivityModel> Activity { get; set; }

        // tried to use this normal means of seeding data through
        //   OnModelCreating, but experienced a key already exists issue 
        //   when trying to add a new entity in the Activities Create method.
        //   Suspect an issue with trying to use the InMemoryDatabase in this way.
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    var now = DateTime.Now;

        //    modelBuilder.Entity<ActivityModel>().HasData(
        //        new ActivityModel()
        //        {
        //            Name = "Bingo",
        //            Description = "Come join us for an exciting game of Bingo with great prizes.",
        //            Date = new DateTime(now.Year, now.Month, now.AddDays(2).Day, 12, 00, 00)
        //        },
        //        new ActivityModel()
        //        {
        //            Name = "Shuffleboard Competition",
        //            Description = "Meet us at the Shuffleboard court!",
        //            Date = new DateTime(now.Year, now.Month, now.AddDays(5).Day, 18, 00, 00)
        //        });
        //}
    }
}