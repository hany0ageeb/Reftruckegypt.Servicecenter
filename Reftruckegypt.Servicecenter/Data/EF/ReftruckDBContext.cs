using System;
using Reftruckegypt.Servicecenter.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class ReftruckDbContext : DbContext
    {
        public ReftruckDbContext()
            : base()
        {
            Database.SetInitializer(new ReftruckDbContextInitializer());
        }
        public ReftruckDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer(new ReftruckDbContextInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Location>()
                .HasKey(e => e.Id)
                .HasIndex(e => e.Name)
                .IsUnique(true)
                .HasName("IDX_UNQ_LOCATION_NAME");
            modelBuilder
                .Entity<Location>()
                .Property(e => e.Name)
                .HasMaxLength(250)
                .IsRequired();
            modelBuilder
                .Entity<Location>()
                .Property(e => e.AddressLine)
                .HasMaxLength(500);
            modelBuilder
                .Entity<Location>()
                .Property(e => e.RowVersion).IsRowVersion();
            //  ---------------------------------------------------------------------
        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<VehicleCategory> VehicleCategories { get; set; }
    }
    public class ReftruckDbContextInitializer : CreateDatabaseIfNotExists<ReftruckDbContext>
    {
        protected override void Seed(ReftruckDbContext context)
        {
            var locations = new List<Location>()
            {
                new Location()
                {
                    Name = "المصنع",
                    AddressLine = ""
                },
                new Location()
                {
                    Name = "مركز الخدمة",
                    AddressLine = ""
                },
                new Location()
                {
                    Name = "التوكيل",
                    AddressLine = ""
                }
            };
            var vehicleCategories = new List<VehicleCategory>()
            {
                new VehicleCategory()
                {
                    Name = "Bus",
                    Description = "الاتوبيسات",
                    IsChassisNumberRequired = true,
                    IsFuelCardRequired = true
                },
                new VehicleCategory()
                {
                    Name = "Truck",
                    Description = "السيارات النقل",
                    IsChassisNumberRequired = true,
                    IsFuelCardRequired = true
                },
                new VehicleCategory()
                {
                    Name = "Passanger",
                    Description = "السيارات الملاكى",
                    IsChassisNumberRequired = true,
                    IsFuelCardRequired = true
                },
                new VehicleCategory()
                {
                    Name = "Forklift",
                    Description = "الكلاركات",
                    IsChassisNumberRequired = false,
                    IsFuelCardRequired = false
                }
            };
            context.Locations.AddRange(locations);
            context.VehicleCategories.AddRange(vehicleCategories);

            context.SaveChanges();
        }
    }
}
