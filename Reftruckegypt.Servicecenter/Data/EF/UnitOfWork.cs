using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _isDisposed = false;
        private ReftruckDbContext _context;
        public UnitOfWork(ReftruckDbContext context)
        {
            _context = context;
            DriverRepository = new DriverRepository(context);
            ExternalAutoRepairShopRepository = new ExternalAutoRepairShopRepository(context);
            FuelCardRepository = new FuelCardRepository(context);
            FuelTypeRepository = new FuelTypeRepository(context);
            ExternalRepairBillRepository = new ExternalRepairBillRepository(context);
            FuelConsumptionRepository = new FuelConsumptionRepository(context);
            LocationRepository = new LocationRepository(context);
            PeriodRepository = new PeriodRepository(context);
            SparePartRepository = new SparePartRepository(context);
            UomRepository = new UomRepository(context);
            SparePartsBillRepository = new SparePartsBillRepository(context);
            VehicleCategoryRepository = new VehicleCategoryRepository(context);
            VehicleModelRepository = new VehicleModelRepository(context);
            ViolationTypeRepository = new ViolationTypeRepository(context);
            VehicleViolationRepository = new VehicleViolationRepository(context);
            VehicleRepository = new VehicleRepository(context);
            VehicleKilometerReadingRepository = new VehicleKilometerReadingRepository(context);
            SparePartsPriceListRepository = new SparePartsPriceListRepository(context);
            VehicleStateChangeRepository = new VehicleStateChangeRepository(context);
            UserCommandRepository = new UserCommandRepository(context);
            SparePartsBillLineRepository = new SparePartsBillLineRepository(context);
            SparePartPriceListLineRepository = new SparePartPriceListLineRepository(context);
            UomConversionRepository = new UomConversionRepository(context);
            VehicleOverAllStateRepository = new VehicleOverAllStateRepository(context);
            VehicleLicenseRepository = new VehicleLicenseRepository(context);
            UserReportRepository = new UserReportRepository(context);
            InternalMemoRepository = new InternalMemoRepository(context);
        }

        public IDriverRepository DriverRepository { get; private set; }

        public IExternalAutoRepairShopRepository ExternalAutoRepairShopRepository { get; private set; }

        public IFuelCardRepository FuelCardRepository { get; private set; }

        public IFuelTypeRepository FuelTypeRepository { get; private set; }

        public IExternalRepairBillRepository ExternalRepairBillRepository { get; private set; }

        public IFuelConsumptionRepository FuelConsumptionRepository { get; private set; }

        public ILocationRepository LocationRepository { get; private set; }

        public IPeriodRepository PeriodRepository { get; private set; }

        public ISparePartRepository SparePartRepository { get; private set; }

        public IUomRepository UomRepository { get; private set; }

        public ISparePartsBillRepository SparePartsBillRepository { get; private set; }

        public ISparePartsPriceListRepository SparePartsPriceListRepository { get; private set; }

        public IVehicleRepository VehicleRepository { get; private set; }

        public IVehicleCategoryRepository VehicleCategoryRepository { get; private set; }

        public IVehicleModelRepository VehicleModelRepository { get; private set; }

        public IVehicleKilometerReadingRepository VehicleKilometerReadingRepository { get; private set; }

        public IViolationTypeRepository ViolationTypeRepository { get; private set; }

        public IVehicleViolationRepository VehicleViolationRepository { get; private set; }

        public IVehicleStateChangeRepository VehicleStateChangeRepository { get; private set; }
        public IUserCommandRepository UserCommandRepository { get; private set; }

        public ISparePartsBillLineRepository SparePartsBillLineRepository { get; private set; }

        public ISparePartPriceListLineRepository SparePartPriceListLineRepository { get; private set; }

        public IUomConversionRepository UomConversionRepository { get; private set; }
        public IVehicleOverAllStateRepository VehicleOverAllStateRepository { get; private set; }
        public IInternalMemoRepository InternalMemoRepository { get; private set; }
        public IVehicleLicenseRepository VehicleLicenseRepository { get;private set; }
        public IUserReportRepository UserReportRepository { get; private set;  }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _context.Dispose();
                _isDisposed = true;
            }
        }
    }
}
