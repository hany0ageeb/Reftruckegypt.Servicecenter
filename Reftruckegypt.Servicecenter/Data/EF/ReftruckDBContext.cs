using Reftruckegypt.Servicecenter.Models;
using System.Data.Entity;
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
                .HasMaxLength(VehicleCategory.MaxVehicleCategoryNameLength);
            modelBuilder
                .Entity<VehicleCategory>()
                .Property(e => e.Description)
                .HasMaxLength(VehicleCategory.MaxVehicleCategoryDescriptionLength);
            // .... FuelType
            modelBuilder.Entity<FuelType>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("FuelTypes");
            });
            modelBuilder
                .Entity<FuelType>()
                .Ignore(e => e.Self);
            modelBuilder
                .Entity<FuelType>()
                .HasIndex(e => e.Name)
                .HasName("IDX_UNQ_FUEL_TYPE_NAME")
                .IsUnique(true);
            modelBuilder
                .Entity<FuelType>()
                .Property(e => e.Name)
                .HasMaxLength(FuelType.MaxFuelTypeNameLength)
                .IsRequired();
            modelBuilder
                .Entity<FuelType>()
                .Property(e => e.Description)
                .HasMaxLength(FuelType.MaxFuelTypeDescriptionLength);
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
                .HasMaxLength(VehicleModel.NameMaxLength);
            modelBuilder
                .Entity<VehicleModel>()
                .Property(e => e.Description)
                .HasMaxLength(VehicleModel.DescriptionMaxLength);
            modelBuilder
                .Entity<VehicleModel>()
                .HasOptional(e => e.DefaultFuelType)
                .WithMany()
                .HasForeignKey(e => e.DefaultFuelTypeId);
            // .... VehicelOverallState
            modelBuilder.Entity<VehicleOvallState>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("VehicelOvallStates");
            });
            modelBuilder
                .Entity<VehicleOvallState>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder
                .Entity<VehicleOvallState>()
                .HasIndex(e => e.Name)
                .IsUnique(true)
                .HasName("IDX_UNQ_OVERALL_ST_NAME");
            modelBuilder
                .Entity<VehicleOvallState>()
                .Property(e => e.Description)
                .HasMaxLength(500);
            // .... VehicelLicense
            modelBuilder.Entity<VehicleLicense>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("VehicelLicenses");
            });
            modelBuilder
                .Entity<VehicleLicense>()
                .Property(e => e.MotorNumber)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder
                .Entity<VehicleLicense>()
                .Property(e => e.Notes)
                .HasMaxLength(500);
            modelBuilder
                .Entity<VehicleLicense>()
                .HasRequired(e => e.FuelType)
                .WithMany()
                .HasForeignKey(e => e.FuelTypeId);
            modelBuilder
                .Entity<VehicleLicense>()
                .HasRequired(e => e.Vehicel)
                .WithMany(e=>e.VehicelLicenses)
                .HasForeignKey(e => e.VehicleId)
                .WillCascadeOnDelete(true);
            modelBuilder
                .Entity<VehicleLicense>()
                .HasIndex(e => e.MotorNumber)
                .IsUnique(false)
                .HasName("IDX_LICE_MOT_NUM");
            modelBuilder
                .Entity<VehicleLicense>()
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
                .HasMaxLength(FuelCard.MaxFuelCardNumberLength);
            modelBuilder
                .Entity<FuelCard>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(FuelCard.MaxFuelCardNameLength);
            modelBuilder
                .Entity<FuelCard>()
                .Property(e => e.Registration)
                .HasMaxLength(FuelCard.MaxFuelCardRegistrationLength);
            modelBuilder
                .Entity<FuelCard>()
                .HasRequired(e => e.Vehicle)
                .WithOptional(e => e.FuelCard)
                .WillCascadeOnDelete(true);
            modelBuilder
                .Entity<FuelCard>()
                .Property(e => e.Id)
                .HasColumnAnnotation("ForeignKey", "Vehicle");
            // ....... Vehicle
            modelBuilder
                .Entity<Vehicle>()
                .Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Vehicles");
            });
            modelBuilder
                .Entity<Vehicle>()
                .HasIndex(e => e.InternalCode)
                .IsUnique(true)
                .HasName("IDX_UNQ_VEHICLE_INTER_CODE");
            modelBuilder
                .Entity<Vehicle>()
                .Property(e => e.InternalCode)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder
                .Entity<Vehicle>()
                .Ignore(e => e.Self);
            modelBuilder
                .Entity<Vehicle>()
                .Property(e => e.ChassisNumber)
                .HasMaxLength(250);
            modelBuilder
                .Entity<Vehicle>()
                .HasRequired(e => e.VehicleCategory)
                .WithMany(e=>e.Vehicles)
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
            modelBuilder
                .Entity<Vehicle>()
                .HasOptional(e => e.FuelCard)
                .WithRequired(e => e.Vehicle)
                .WillCascadeOnDelete(true);
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
                .HasMaxLength(ViolationType.MaxNameLength);
            modelBuilder
                .Entity<ViolationType>()
                .Property(e => e.Description)
                .HasMaxLength(ViolationType.MaxDescriptionLength);
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
            modelBuilder
                .Entity<Driver>()
                .Property(e => e.TrafficDepartmentName)
                .HasMaxLength(250);

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
                .HasMaxLength(Period.MaxPeriodNameLength);
            modelBuilder
                .Entity<Period>()
                .Property(e => e.State)
                .IsRequired()
                .HasMaxLength(Period.MaxPeriodStateLength);
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
                .HasMaxLength(VehicleViolation.MaxNotesLength);
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
                .HasMaxLength(FuelConsumption.MaxFuelConsumptionNotesLength);
            // .... ExternalAutoRepairShop
            modelBuilder
                .Entity<ExternalAutoRepairShop>()
                .Map(m => {
                    m.MapInheritedProperties();
                    m.ToTable("ExternalAutoRepairShops"); 
                });
            modelBuilder
                .Entity<ExternalAutoRepairShop>()
                .Ignore(e => e.Self);
            modelBuilder
                .Entity<ExternalAutoRepairShop>()
                .HasIndex(e => e.Name)
                .IsUnique(true)
                .HasName("IDX_UNQ_SHOP_NAME");
            modelBuilder
                .Entity<ExternalAutoRepairShop>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(ExternalAutoRepairShop.MaxNameLength);
            modelBuilder
                .Entity<ExternalAutoRepairShop>()
                .Property(e => e.Address)
                .HasMaxLength(ExternalAutoRepairShop.MaxAddressLength);
            modelBuilder
                .Entity<ExternalAutoRepairShop>()
                .Property(e => e.Phone)
                .HasMaxLength(ExternalAutoRepairShop.MaxPhoneLength);
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
                .HasIndex(e => e.BillDate)
                .IsUnique(false)
                .HasName("IDX_EXT_REP_BILL_DATE");
            modelBuilder
                .Entity<ExternalRepairBill>()
                .HasIndex(e => e.Number)
                .IsUnique(true)
                .HasName("IDX_UNQ_EXT_REP_BILL_NUM");
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
                .HasMaxLength(ExternalRepairBill.MaxRepairsLength);
            modelBuilder
                .Entity<ExternalRepairBill>()
                .Property(e => e.SupplierBillNumber)
                .HasMaxLength(ExternalRepairBill.MaxSupplierBillNumberLength);
            modelBuilder
                .Entity<ExternalRepairBill>()
                .Property(e => e.Number)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder
                .Entity<ExternalRepairBill>()
                .Property(e => e.BillImageFilePath)
                .HasMaxLength(ExternalRepairBill.MaxBillImageFilePathLength);
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
                .HasMaxLength(Uom.CodeMaxLength);
            modelBuilder
                .Entity<Uom>()
                .Property(e => e.Name)
                .HasMaxLength(Uom.NameMaxLength);
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
                .HasMaxLength(SparePart.MaxSparePartCodeLength);
            modelBuilder
                .Entity<SparePart>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(SparePart.MaxSparePartNameLength);
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
            // SparePartPriceList
            modelBuilder
                .Entity<SparePartsPriceList>()
                .Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("SparePartsPriceLists");
                });
            modelBuilder
                .Entity<SparePartsPriceList>()
                .Property(e => e.Number)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder
                .Entity<SparePartsPriceList>()
                .HasRequired(e => e.Period)
                .WithOptional()
                .WillCascadeOnDelete(true);
            modelBuilder
                .Entity<SparePartsPriceList>()
                .HasMany(e => e.Lines)
                .WithRequired(e => e.SparePartsPriceList)
                .WillCascadeOnDelete(true);
            // SparePartPriceList
            modelBuilder
                .Entity<SparePartPriceListLine>()
                .Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("SparePartPriceListLines");
                });
            modelBuilder
                .Entity<SparePartPriceListLine>()
                .HasRequired(e => e.SparePart)
                .WithMany()
                .HasForeignKey(e => e.SparePartId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<SparePartPriceListLine>()
                .HasRequired(e => e.Uom)
                .WithMany()
                .HasForeignKey(e => e.UomId)
                .WillCascadeOnDelete(false);
            // SparePartsBill
            modelBuilder
                .Entity<SparePartsBill>()
                .Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("SparePartsBills");
                });
            modelBuilder
                .Entity<SparePartsBill>()
                .HasRequired(e => e.Vehicle)
                .WithMany()
                .HasForeignKey(e => e.VehicleId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<SparePartsBill>()
                .HasRequired(e => e.Period)
                .WithMany()
                .HasForeignKey(e => e.PeriodId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<SparePartsBill>()
                .HasMany(e => e.Lines)
                .WithRequired(e=>e.SparePartsBill)
                .WillCascadeOnDelete(true);
            modelBuilder
                .Entity<SparePartsBill>()
                .Property(e => e.Number)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder
                .Entity<SparePartsBill>()
                .Property(e => e.Repairs)
                .HasMaxLength(500);
            // SparePartsBillLine
            modelBuilder
                .Entity<SparePartsBillLine>()
                .Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("SparePartsBillLines");
                });
            modelBuilder
                .Entity<SparePartsBillLine>()
                .HasRequired(e => e.SparePart)
                .WithMany()
                .HasForeignKey(e => e.SparePartId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<SparePartsBillLine>()
                .HasRequired(e => e.Uom)
                .WithMany()
                .HasForeignKey(e => e.UomId)
                .WillCascadeOnDelete(false);
            // VehicleKilometerReading
            modelBuilder
                .Entity<VehicleKilometerReading>()
                .Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("VehicleKilometerReadings");
                });
            modelBuilder
                .Entity<VehicleKilometerReading>()
                .HasRequired(e => e.Vehicle)
                .WithMany()
                .HasForeignKey(e => e.VehicleId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<VehicleKilometerReading>()
                .HasRequired(e => e.Period)
                .WithMany()
                .HasForeignKey(e => e.PeriodId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<VehicleKilometerReading>()
                .Property(e => e.Notes)
                .HasMaxLength(VehicleKilometerReading.VehicleKilometerReadingNotesMaxLength);
            // VehicleStateChange
            modelBuilder
               .Entity<VehicleStateChange>()
               .Map(m =>
               {
                   m.MapInheritedProperties();
                   m.ToTable("VehicleStateChanges");
               });
            modelBuilder
                .Entity<VehicleStateChange>()
                .HasRequired(e => e.Vehicle)
                .WithMany()
                .HasForeignKey(e => e.VehicleId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<VehicleStateChange>()
                .HasRequired(e => e.Period)
                .WithMany()
                .HasForeignKey(e => e.PeriodId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<VehicleStateChange>()
                .Property(e => e.State)
                .IsRequired()
                .HasMaxLength(VehicleStateChange.MaxStateLength);
            modelBuilder
                .Entity<VehicleStateChange>()
                .Property(e => e.Notes)
                .HasMaxLength(VehicleStateChange.MaxNotesLength);
            // ... UserCommand
            modelBuilder
                .Entity<UserCommand>()
                .Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("UserCommands");
                });
            modelBuilder
                .Entity<UserCommand>()
                .HasIndex(e => e.Name)
                .IsUnique(true)
                .HasName("IDX_UNQ_UCOMMAND_NAME");
            modelBuilder
                .Entity<UserCommand>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder
                .Entity<UserCommand>()
                .Property(e => e.DisplayName)
                .HasMaxLength(500);
            modelBuilder
                .Entity<UserCommand>()
                .Ignore(e => e.Execute);
        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<VehicleCategory> VehicleCategories { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleOvallState> VehicelOvallStates { get; set; }
        public DbSet<FuelCard> FuelCards { get; set; }
        public DbSet<VehicleLicense> VehicelLicenses { get; set; }
        public DbSet<Vehicle> Vehicels { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<ViolationType> ViolationTypes { get; set; }
        public DbSet<VehicleViolation> VehicleViolations { get; set; }
        public DbSet<Uom> Uoms { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<UomConversion> UomConversions { get; set; }
        public DbSet<ExternalAutoRepairShop> ExternalAutoRepairShops { get; set; }
        public DbSet<ExternalRepairBill> ExternalRepairBills { get; set; }
        public DbSet<SparePartsBill> SparePartsBills { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<FuelConsumption> FuelConsumptions { get; set; }
        public DbSet<SparePartsPriceList> SparePartsPriceLists { get; set; }
        public DbSet<VehicleKilometerReading> VehicleKilometerReadings { get; set; }
        public DbSet<VehicleStateChange> VehicleStateChanges { get; set; }
        public DbSet<UserCommand> UserCommands { get; set; }
    }
}
