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

        public ISparePartsPriceListRepository SparePartsPriceListRepository => throw new System.NotImplementedException();

        public IVehicleRepository VehicleRepository => throw new System.NotImplementedException();

        public IVehicleCategoryRepository VehicleCategoryRepository => throw new System.NotImplementedException();

        public IVehicleModelRepository VehicleModelRepository => throw new System.NotImplementedException();

        public IVehicleKilometerReadingRepository VehicleKilometerReadingRepository => throw new System.NotImplementedException();

        public IViolationTypeRepository ViolationTypeRepository => throw new System.NotImplementedException();

        public IVehicleViolationRepository VehicleViolationRepository => throw new System.NotImplementedException();

        public IVehicleStateChangeRepository VehicleStateChangeRepository => throw new System.NotImplementedException();

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
