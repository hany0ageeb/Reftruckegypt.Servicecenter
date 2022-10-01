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
            // ... location
            modelBuilder.Entity<Location>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Locations");
            });
            modelBuilder
                .Entity<Location>()
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
            //  ... vehicleCategory
            modelBuilder.Entity<VehicleCategory>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("VehicleCategories");
            });
            modelBuilder
                .Entity<VehicleCategory>()
                .HasIndex(e => e.Name)
                .IsUnique(true)
                .HasName("IDX_UNQ_CATEGORY_NAME");
            modelBuilder
                .Entity<VehicleCategory>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder
                .Entity<VehicleCategory>()
                .Property(e => e.Description)
                .HasMaxLength(500);
            // .... FuelType
            modelBuilder.Entity<FuelType>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("FuelTypes");
            });
            modelBuilder
                .Entity<FuelType>()
                .HasIndex(e => e.Name)
                .HasName("IDX_UNQ_FUEL_TYPE_NAME")
                .IsUnique(true);
            modelBuilder
                .Entity<FuelType>()
                .Property(e => e.Name)
                .HasMaxLength(250)
                .IsRequired();
            modelBuilder
                .Entity<FuelType>()
                .Property(e => e.Description)
                .HasMaxLength(500);
            // ..... VehicleModel
            modelBuilder.Entity<VehicleModel>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("VehicleModels");
            });
            modelBuilder
                .Entity<VehicleModel>()
                .HasIndex(e => e.Name)
                .IsUnique(true)
                .HasName("IDX_UNQ_MODEL_NAME");
            modelBuilder
                .Entity<VehicleModel>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder
                .Entity<VehicleModel>()
                .Property(e => e.Description)
                .HasMaxLength(500);
            modelBuilder
                .Entity<VehicleModel>()
                .HasOptional(e => e.DefaultFuelType)
                .WithMany()
                .HasForeignKey(e => e.DefaultFuelTypeId);
            // .... VehicelOverallState
            modelBuilder.Entity<VehicelOvallState>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("VehicelOvallStates");
            });
            modelBuilder
                .Entity<VehicelOvallState>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder
                .Entity<VehicelOvallState>()
                .HasIndex(e => e.Name)
                .IsUnique(true)
                .HasName("IDX_UNQ_OVERALL_ST_NAME");
            modelBuilder
                .Entity<VehicelOvallState>()
                .Property(e => e.Description)
                .HasMaxLength(500);
            // .... VehicelLicense
            modelBuilder.Entity<VehicelLicense>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("VehicelLicenses");
            });
            modelBuilder
                .Entity<VehicelLicense>()
                .Property(e => e.MotorNumber)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder
                .Entity<VehicelLicense>()
                .Property(e => e.Notes)
                .HasMaxLength(500);
            modelBuilder
                .Entity<VehicelLicense>()
                .HasRequired(e => e.FuelType)
                .WithMany()
                .HasForeignKey(e => e.FuelTypeId);
            modelBuilder
                .Entity<VehicelLicense>()
                .HasRequired(e => e.Vehicel)
                .WithMany(e=>e.VehicelLicenses)
                .HasForeignKey(e => e.VehicleId)
                .WillCascadeOnDelete(true);
            modelBuilder
                .Entity<VehicelLicense>()
                .HasIndex(e => e.MotorNumber)
                .IsUnique(false)
                .HasName("IDX_LICE_MOT_NUM");
            modelBuilder
                .Entity<VehicelLicense>()
                .Property(e => e.TrafficDepartmentName)
                .HasMaxLength(500);
            //  ....... FuelCard
            modelBuilder.Entity<FuelCard>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("FuelCards");
            });
            modelBuilder
                .Entity<FuelCard>()
                .HasIndex(e => e.Number)
                .IsUnique(true)
                .HasName("IDX_UNQ_CARD_NUM");
            modelBuilder
                .Entity<FuelCard>()
                .Property(e => e.Number)
                .IsRequired()
                .HasMaxLength(10);
            modelBuilder
                .Entity<FuelCard>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder
                .Entity<FuelCard>()
                .HasRequired(e => e.Vehicel)
                .WithOptional(e => e.FuelCard)
                .WillCascadeOnDelete(false);
            // ....... Vehicle
            modelBuilder.Entity<Vehicle>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Vehicles");
            });
            modelBuilder
                .Entity<Vehicle>()
                .Property(e => e.ChassisNumber)
                .HasMaxLength(250);
            modelBuilder
                .Entity<Vehicle>()
                .HasRequired(e => e.VehicleCategory)
                .WithMany()
                .HasForeignKey(e => e.VehicleCategoryId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<Vehicle>()
                .HasRequired(e => e.VehicleModel)
                .WithMany()
                .HasForeignKey(e => e.VehicelModelId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<Vehicle>()
                .HasOptional(e => e.OvallState)
                .WithMany()
                .HasForeignKey(e => e.OverallStateId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<Vehicle>()
                .HasOptional(e => e.WorkLocation)
                .WithMany()
                .HasForeignKey(e => e.WorkLocationId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<Vehicle>()
                .HasOptional(e => e.MaintenanceLocation)
                .WithMany()
                .HasForeignKey(e => e.MaintenanceLocationId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<Vehicle>()
                .HasOptional(e => e.Driver)
                .WithOptionalPrincipal();
            // ... ViolationType
            modelBuilder.Entity<ViolationType>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("ViolationTypes");
            });
            modelBuilder
                .Entity<ViolationType>()
                .HasIndex(e => e.Name)
                .IsUnique(true)
                .HasName("IDX_UNQ_VIOLATION_NAME");
            modelBuilder
                .Entity<ViolationType>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder
                .Entity<ViolationType>()
                .Property(e => e.Description)
                .HasMaxLength(500);
            // ... Driver
            modelBuilder
                .Entity<Driver>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder
                .Entity<Driver>()
                .Property(e => e.LicenseNumber)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder
                .Entity<Driver>()
                .HasIndex(e => e.Name)
                .IsUnique(true)
                .HasName("IDX_UNQ_DRIVER_NAME");
            modelBuilder
                .Entity<Driver>()
                .HasIndex(e => e.LicenseNumber)
                .HasName("IDX_DRV_LICENS_NUM");
            // ... Period
            modelBuilder
                .Entity<Period>()
                .Map(m => {
                    m.MapInheritedProperties();
                    m.ToTable("Periods");
                });
            modelBuilder
                .Entity<Period>()
                .HasIndex(e => e.Name)
                .IsUnique(true)
                .HasName("IDX_UNQ_PRD_NAME");
            modelBuilder
                .Entity<Period>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder
                .Entity<Period>()
                .Property(e => e.State)
                .IsRequired()
                .HasMaxLength(50);
            // ... Violation
            modelBuilder
                .Entity<VehicleViolation>()
                .Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("VehicleViolations");
                });
            modelBuilder
                .Entity<VehicleViolation>()
                .HasRequired(e => e.Period)
                .WithMany()
                .HasForeignKey(e => e.PeriodId)
                .WillCascadeOnDelete(true);
            modelBuilder
                .Entity<VehicleViolation>()
                .HasRequired(e => e.Vehicle)
                .WithMany()
                .HasForeignKey(e => e.VehicleId)
                .WillCascadeOnDelete(true);
            modelBuilder
                .Entity<VehicleViolation>()
                .Property(e => e.Notes)
                .HasMaxLength(500);
            // .... FuelConsumption
            modelBuilder
                .Entity<FuelConsumption>()
                .Map(
                    m =>{
                        m.MapInheritedProperties();
                        m.ToTable("FuelConsumptions");
                });
            modelBuilder
                .Entity<FuelConsumption>()
                .HasRequired(e => e.Vehicle)
                .WithMany()
                .HasForeignKey(e => e.VehicleId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<FuelConsumption>()
                .HasRequired(e => e.FuelCard)
                .WithMany()
                .HasForeignKey(e => e.FuelCardId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<FuelConsumption>()
                .HasRequired(e => e.Period)
                .WithMany()
                .HasForeignKey(e => e.PeriodId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<FuelConsumption>()
                .Property(e => e.Notes)
                .HasMaxLength(500);
            // .... ExternalAutoRepairShop
            modelBuilder
                .Entity<ExternalAutoRepairShop>()
                .Map(m => {
                    m.MapInheritedProperties();
                    m.ToTable("ExternalAutoRepairShops"); 
                });
            modelBuilder
                .Entity<ExternalAutoRepairShop>()
                .HasIndex(e => e.Name)
                .IsUnique(true)
                .HasName("IDX_UNQ_SHOP_NAME");
            modelBuilder
                .Entity<ExternalAutoRepairShop>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder
                .Entity<ExternalAutoRepairShop>()
                .Property(e => e.Address)
                .HasMaxLength(500);
            modelBuilder
                .Entity<ExternalAutoRepairShop>()
                .Property(e => e.Phone)
                .HasMaxLength(15);
            // ... ExternalRepairBill
            modelBuilder
                .Entity<ExternalRepairBill>()
                .Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("ExternalRepairBills");
                });
            modelBuilder
                .Entity<ExternalRepairBill>()
                .HasRequired(e => e.Vehicle)
                .WithMany()
                .HasForeignKey(e => e.VehicleId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<ExternalRepairBill>()
                .HasRequired(e => e.ExternalAutoRepairShop)
                .WithMany()
                .HasForeignKey(e => e.ExternalAutoRepairShopId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<ExternalRepairBill>()
                .HasRequired(e => e.Period)
                .WithMany()
                .HasForeignKey(e => e.PeriodId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<ExternalRepairBill>()
                .Property(e => e.Repairs)
                .IsRequired()
                .HasMaxLength(1000);
            // Uom ...
            modelBuilder
                .Entity<Uom>()
                .Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("Uoms");
                });
            modelBuilder
                .Entity<Uom>()
                .HasIndex(e => e.Code)
                .IsUnique(true)
                .HasName("IDX_UNQ_UOM_CODE");
            modelBuilder
                .Entity<Uom>()
                .Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(6);
            modelBuilder
                .Entity<Uom>()
                .Property(e => e.Name)
                .HasMaxLength(250);
            // SparePart ....
            modelBuilder
                .Entity<SparePart>()
                .Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("SpareParts");
                });
            modelBuilder
                .Entity<SparePart>()
                .HasIndex(e => e.Code)
                .IsUnique(true)
                .HasName("IDX_UNQ_PART_CODE");
            modelBuilder
                .Entity<SparePart>()
                .Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder
                .Entity<SparePart>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(500);
            modelBuilder
                .Entity<SparePart>()
                .HasRequired(e => e.PrimaryUom)
                .WithMany()
                .HasForeignKey(e => e.PrimaryUomId)
                .WillCascadeOnDelete(false);
            // UomConversion ...
            modelBuilder
                .Entity<UomConversion>()
                .HasRequired(e => e.FromUom)
                .WithMany()
                .HasForeignKey(e => e.ToUomId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<UomConversion>()
                .HasRequired(e => e.ToUom)
                .WithMany()
                .HasForeignKey(e => e.ToUomId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<UomConversion>()
                .HasOptional(e => e.SparePart)
                .WithMany()
                .HasForeignKey(e => e.SparePartId)
                .WillCascadeOnDelete(false);
        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<VehicleCategory> VehicleCategories { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicelOvallState> VehicelOvallStates { get; set; }
        public DbSet<FuelCard> FuelCards { get; set; }
        public DbSet<VehicelLicense> VehicelLicenses { get; set; }
        public DbSet<Vehicle> Vehicels { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<ViolationType> ViolationTypes { get; set; }
        public DbSet<VehicleViolation> VehicleViolations { get; set; }
        public DbSet<Uom> Uoms { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<UomConversion> UomConversions { get; set; }
        public DbSet<ExternalAutoRepairShop> ExternalAutoRepairShops { get; set; }
        public DbSet<ExternalRepairBill> ExternalRepairBills { get; set; }
    }
}
