using Reftruckegypt.Servicecenter.Models;
using System.Data.Entity;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class ReftruckDbContextInitializer : CreateDatabaseIfNotExists<ReftruckDbContext>
    {
        protected override void Seed(ReftruckDbContext context)
        {
            Location[] locations = new Location[]
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
            VehicleCategory[] vehicleCategories = new VehicleCategory[]
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
            FuelType[] fuelTypes = new FuelType[]
            {
                new FuelType()
                {
                    Name = "Diesel",
                    Description = "سولار"
                },
                new FuelType()
                {
                    Name = "Gasoline",
                    Description = "بنزين"
                }
            };
            VehicleModel[] vehicleModels = new VehicleModel[]
            {
                // Buses
                new VehicleModel()
                {
                    Name = "ميكروباص فوتون",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                new VehicleModel()
                {
                    Name = "ميكروباص تويوتا",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                new VehicleModel()
                {
                    Name = "أوتوبيس - شيفروليه - خلف",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                new VehicleModel()
                {
                    Name = "أوتوبيس - شيفروليه - MCV",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                // Trucks
                new VehicleModel()
                {
                    Name = "شيفرليه  - جامبو 5000",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                new VehicleModel()
                {
                    Name = "شيفرليه ديماكس",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                new VehicleModel()
                {
                    Name = "ديماكس دبل كابينة",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                new VehicleModel()
                {
                    Name = "متسوبيشى كانتر",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                new VehicleModel()
                {
                    Name = "شيفرليه  - جامبو 8000",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                new VehicleModel()
                {
                    Name = "مرسيدس شبل",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                new VehicleModel()
                {
                    Name = "نيسان دبل كابينة",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                new VehicleModel()
                {
                    Name = "مرسيدس فان",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                new VehicleModel()
                {
                    Name = "تويوتا فان",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                //Passengers
                new VehicleModel()
                {
                    Name = "هيونداى فيرنا - مانوال",
                    Description = "",
                    DefaultFuelType = fuelTypes[1]
                },
                new VehicleModel()
                {
                    Name = "اسكودا أوكتافيا",
                    Description = "",
                    DefaultFuelType = fuelTypes[1]
                },
                new VehicleModel()
                {
                    Name = "شيفرليه أفيو",
                    Description = "",
                    DefaultFuelType = fuelTypes[1]
                },
                new VehicleModel()
                {
                    Name = "هيونداى فيرنا - أوتوماتيك",
                    Description = "",
                    DefaultFuelType = fuelTypes[1]
                },new VehicleModel()
                {
                    Name = "هيونداى توسان",
                    Description = "",
                    DefaultFuelType = fuelTypes[1]
                },
                new VehicleModel()
                {
                    Name = "نيسان صني  - N17 - أوتوماتيك",
                    Description = "",
                    DefaultFuelType = fuelTypes[1]
                },
                new VehicleModel()
                {
                    Name = "Toyota",
                    Description = "",
                    DefaultFuelType = fuelTypes[1]
                },
                new VehicleModel()
                {
                    Name = "MG5",
                    Description = "",
                    DefaultFuelType = fuelTypes[1]
                },
                new VehicleModel()
                {
                    Name = "أوبل أستر",
                    Description = "",
                    DefaultFuelType = fuelTypes[1]
                },
                //Liftfork
                new VehicleModel()
                {
                    Name = "TCM",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                new VehicleModel()
                {
                    Name = "كاتربلر",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                new VehicleModel()
                {
                    Name = "كوماتسو",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                }
            };
            VehicelOvallState[] overallStates =
            {
                new VehicelOvallState()
                {
                    Name = "حالة ممتازة",
                    Description = ""
                },
                new VehicelOvallState()
                {
                    Name = "حالة جيدة جدا",
                    Description = ""
                },
                new VehicelOvallState()
                {
                    Name = "حالة جيدة",
                    Description = ""
                },
                new VehicelOvallState()
                {
                    Name = "حالة متوسطة",
                    Description = ""
                },
                new VehicelOvallState()
                {
                    Name = "حالة متهالكة",
                    Description = ""
                }
            };
            context.Locations.AddRange(locations);
            context.VehicleCategories.AddRange(vehicleCategories);
            context.FuelTypes.AddRange(fuelTypes);
            context.VehicleModels.AddRange(vehicleModels);
            context.VehicelOvallStates.AddRange(overallStates);
            //
            context.SaveChanges();
        }
    }
}
