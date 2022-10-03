using System;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IDriverRepository DriverRepository { get; }
        IExternalAutoRepairShopRepository ExternalAutoRepairShopRepository { get; }
        IFuelCardRepository FuelCardRepository { get; }
        IFuelTypeRepository FuelTypeRepository { get; }
        IExternalRepairBillRepository ExternalRepairBillRepository { get; }
        IFuelConsumptionRepository FuelConsumptionRepository { get; }
        ILocationRepository LocationRepository { get; }
        IPeriodRepository PeriodRepository { get; }
        ISparePartRepository SparePartRepository { get; }
        IUomRepository UomRepository { get; }
        ISparePartsBillRepository SparePartsBillRepository { get; }
        ISparePartsPriceListRepository SparePartsPriceListRepository { get; }
        IVehicleRepository VehicleRepository { get; }
        IVehicleCategoryRepository VehicleCategoryRepository { get; }
        IVehicleModelRepository VehicleModelRepository { get; }
        IVehicleKilometerReadingRepository VehicleKilometerReadingRepository { get; }
        IViolationTypeRepository ViolationTypeRepository { get; }
        IVehicleViolationRepository VehicleViolationRepository { get; }
        IVehicleStateChangeRepository VehicleStateChangeRepository { get; }
        IUserCommandRepository UserCommandRepository { get; }
        int Complete();
    }
}
