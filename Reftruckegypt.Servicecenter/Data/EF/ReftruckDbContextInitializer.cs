using Reftruckegypt.Servicecenter.Models;
using System.Data.Entity;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class ReftruckDbContextInitializer : CreateDatabaseIfNotExists<ReftruckDbContext>
    {
        protected override void Seed(ReftruckDbContext context)
        {
            // ....
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
            // ...
            Period[] periods = new Period[]
            {
                new Period()
                {
                    FromDate = new System.DateTime(2022, 8, 1),
                    ToDate = new System.DateTime(2022, 8, 31),
                    Name = "Aug-2022",
                    State = PeriodStates.OpenState
                }
            };
            // ....
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
            // .....
           
            VehicleOvallState[] overallStates =
            {
                new VehicleOvallState()
                {
                    Name = "حالة ممتازة",
                    Description = ""
                },
                new VehicleOvallState()
                {
                    Name = "حالة جيدة جدا",
                    Description = ""
                },
                new VehicleOvallState()
                {
                    Name = "حالة جيدة",
                    Description = ""
                },
                new VehicleOvallState()
                {
                    Name = "حالة متوسطة",
                    Description = ""
                },
                new VehicleOvallState()
                {
                    Name = "حالة متهالكة",
                    Description = ""
                }
            };
            // ...
            ExternalAutoRepairShop[] externalAutoRepairShops = new ExternalAutoRepairShop[]
            {
                new ExternalAutoRepairShop()
                {
                    Name = "المركز الهندسي",
                    Address = "العاشر",
                    Phone = "",
                    IsEnabled = true
                },
                new ExternalAutoRepairShop()
                {
                    Name = "المنصور للسيارات",
                    Address = "الهرم",
                    Phone = "",
                    IsEnabled = true
                },
                new ExternalAutoRepairShop()
                {
                    Name = "بريدجستون",
                    Address = "العاشر",
                    Phone = "",
                    IsEnabled = true
                },
                new ExternalAutoRepairShop()
                {
                    Name = "محطة توتال",
                    Address = "العاشر",
                    Phone = "",
                    IsEnabled = true
                },
                new ExternalAutoRepairShop()
                {
                    Name = "ورشة الأسطي عبد الله",
                    Address = "العاشر",
                    Phone = "",
                    IsEnabled = true
                }
            };
            // ....
            // ........
            Uom[] uoms = new Uom[]
            {
                new Uom()
                {
                    Code = "EACH",
                    Name = "عدد"
                },
                new Uom()
                {
                    Code = "KG",
                    Name = "Kilogram"
                },
                new Uom()
                {
                    Code = "MT",
                    Name = "متر"
                },
                new Uom()
                {
                    Code = "LT",
                    Name = "Litre"
                }
            };
            // ...
            ViolationType[] violationTypes = new ViolationType[]
            {
                new ViolationType()
                {
                    Name = "Speed Violation",
                    Description = "مخالفة السرعة المقررة",
                    IsEnabled = true
                }
            };
            // ........
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
            VehicleModel[] vehicleModels = new VehicleModel[]
           {
                // Buses
                new VehicleModel()
                {
                    // 0
                    Name = "ميكروباص فوتون",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                new VehicleModel()
                {
                    // 1
                    Name = "ميكروباص تويوتا",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                new VehicleModel()
                {
                    // 2
                    Name = "أوتوبيس - شيفروليه - خلف",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                new VehicleModel()
                {
                    // 3
                    Name = "أوتوبيس - شيفروليه - MCV",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                // Trucks
                new VehicleModel()
                {
                    // 4
                    Name = "شيفرليه  - جامبو 5000",
                    Description = "",
                    DefaultFuelType = fuelTypes[0]
                },
                new VehicleModel()
                {
                    // 5
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
            // ...
            Vehicle[] vehicles = new Vehicle[]
            {
                new Vehicle()
                {
                    ChassisNumber = "71001700",
                    VehicleCategory = vehicleCategories[0],
                    VehicleModel = vehicleModels[3],
                    WorkingState = VehicleStates.Working,
                    ModelYear = 2011,
                    WorkLocation = locations[0],
                    InternalCode = "9735",
                    FuelCard = new FuelCard()
                    {
                        Number = "88434",
                        Name = "Chevrolet MCV",
                        Registration = "9735C W R"
                    }
                },
                new Vehicle()
                {
                    ChassisNumber = "7100200",
                    VehicleCategory = vehicleCategories[0],
                    VehicleModel = vehicleModels[3],
                    WorkingState = VehicleStates.Working,
                    ModelYear = 2012,
                    WorkLocation = locations[0],
                    InternalCode = "1295",
                    FuelCard = new FuelCard()
                    {
                        Number = "139562",
                        Name = "Chevrolet MCV",
                        Registration = "1295C L R"
                    }
                },
                new Vehicle()
                {
                    ChassisNumber = "7100169",
                    VehicleCategory = vehicleCategories[0],
                    VehicleModel = vehicleModels[3],
                    WorkingState = VehicleStates.Working,
                    ModelYear = 2011,
                    WorkLocation = locations[0],
                    InternalCode = "9736",
                    FuelCard = new FuelCard()
                    {
                        Number = "88435",
                        Name = "Chevrolet MCV",
                        Registration = "9736C W R"
                    }
                },
                new Vehicle()
                {
                    ChassisNumber = "260476",
                    VehicleCategory = vehicleCategories[0],
                    VehicleModel = vehicleModels[3],
                    WorkingState = VehicleStates.Working,
                    ModelYear = 2015,
                    WorkLocation = locations[0],
                    InternalCode = "2736",
                    FuelCard = new FuelCard()
                    {
                        Number = "138900",
                        Name = "Chevrolet MCV",
                        Registration = "2736K A R"
                    }
                },
                new Vehicle()
                {
                    ChassisNumber = "260475",
                    VehicleCategory = vehicleCategories[0],
                    VehicleModel = vehicleModels[3],
                    WorkingState = VehicleStates.Working,
                    ModelYear = 2015,
                    WorkLocation = locations[0],
                    InternalCode = "2735",
                    FuelCard = new FuelCard()
                    {
                        Number = "138904",
                        Name = "Chevrolet MCV",
                        Registration = "2735K A R"
                    }
                },
                new Vehicle()
                {
                    ChassisNumber = "7100318",
                    VehicleCategory = vehicleCategories[0],
                    VehicleModel = vehicleModels[3],
                    WorkingState = VehicleStates.Working,
                    ModelYear = 2013,
                    WorkLocation = locations[0],
                    InternalCode = "1832",
                    FuelCard = new FuelCard()
                    {
                        Number = "88432",
                        Name = "Chevrolet MCV",
                        Registration = "1832C L R"
                    }
                },
                new Vehicle()
                {
                    ChassisNumber = "771589",
                    VehicleCategory = vehicleCategories[0],
                    VehicleModel = vehicleModels[3],
                    WorkingState = VehicleStates.Working,
                    ModelYear = 2016,
                    WorkLocation = locations[0],
                    InternalCode = "2764",
                    FuelCard = new FuelCard()
                    {
                        Number = "138858",
                        Name = "Chevrolet MCV",
                        Registration = "2764K A R"
                    }
                },
                new Vehicle()
                {
                    ChassisNumber = "7101033",
                    VehicleCategory = vehicleCategories[0],
                    VehicleModel = vehicleModels[3],
                    WorkingState = VehicleStates.Working,
                    ModelYear = 2012,
                    WorkLocation = locations[0],
                    InternalCode = "1485",
                    FuelCard = new FuelCard()
                    {
                        Number = "145088",
                        Name = "",
                        Registration = ""
                    }
                },
                new Vehicle()
                {
                    ChassisNumber = "232685",
                    VehicleCategory = vehicleCategories[0],
                    VehicleModel = vehicleModels[3],
                    WorkingState = VehicleStates.Working,
                    ModelYear = 2015,
                    WorkLocation = locations[0],
                    InternalCode = "2435",
                    FuelCard = new FuelCard()
                    {
                        Number = "148580",
                        Name = "Chevrolet MCV",
                        Registration = "2435K A R"
                    }
                },
                new Vehicle()
                {
                    ChassisNumber = "7102315",
                    VehicleCategory = vehicleCategories[0],
                    VehicleModel = vehicleModels[2],
                    WorkingState = VehicleStates.Working,
                    ModelYear = 2015,
                    WorkLocation = locations[0],
                    InternalCode = "8716",
                    FuelCard = new FuelCard()
                    {
                        Number = "88430",
                        Name = "Khalaf Bus",
                        Registration = "8716B M R"
                    }
                },
                new Vehicle()
                {
                    ChassisNumber = "232687",
                    VehicleCategory = vehicleCategories[0],
                    VehicleModel = vehicleModels[3],
                    WorkingState = VehicleStates.Working,
                    ModelYear = 2015,
                    WorkLocation = locations[0],
                    InternalCode = "2431",
                    FuelCard = new FuelCard()
                    {
                        Number = "138908",
                        Name = "Chevrolet MCV",
                        Registration = "2431K A R"
                    }
                },
                new Vehicle()
                {
                    ChassisNumber = "804409",
                    VehicleCategory = vehicleCategories[0],
                    VehicleModel = vehicleModels[3],
                    WorkingState = VehicleStates.Working,
                    ModelYear = 2017,
                    WorkLocation = locations[0],
                    InternalCode = "3165",
                    FuelCard = new FuelCard()
                    {
                        Number = "138907",
                        Name = "Chevrolet MCV",
                        Registration = "3165K A R"
                    }
                },
                new Vehicle()
                {
                    ChassisNumber = "ME030042",
                    VehicleCategory = vehicleCategories[0],
                    VehicleModel = vehicleModels[3],
                    WorkingState = VehicleStates.Working,
                    ModelYear = 2021,
                    WorkLocation = locations[0],
                    InternalCode = "3248",
                    FuelCard = new FuelCard()
                    {
                        Number = "99185",
                        Name = "Chevrolet MCV",
                        Registration = "3248K A R"
                    }
                },
                new Vehicle()
                {
                    ChassisNumber = "ME030088",
                    VehicleCategory = vehicleCategories[0],
                    VehicleModel = vehicleModels[3],
                    WorkingState = VehicleStates.Working,
                    ModelYear = 2021,
                    WorkLocation = locations[0],
                    InternalCode = "3249",
                    FuelCard = new FuelCard()
                    {
                        Number = "187952",
                        Name = "Chevrolet MCV",
                        Registration = "3249K A R"
                    }
                },
                new Vehicle()
                {
                    ChassisNumber = "11199",
                    VehicleCategory = vehicleCategories[0],
                    VehicleModel = vehicleModels[0],
                    WorkingState = VehicleStates.Working,
                    ModelYear = 2019,
                    WorkLocation = locations[0],
                    InternalCode = "1739",
                    FuelCard = new FuelCard()
                    {
                        Number = "88423",
                        Name = "Foton",
                        Registration = "1739C L R"
                    }
                }
            };
            // ...
            ExternalRepairBill[] externalRepairBills = new ExternalRepairBill[]
            {
                new ExternalRepairBill()
                {
                    BillDate = new System.DateTime(2022, 8, 16),
                    Repairs = "تيل + قبقاب حديد",
                    Period = periods[0],
                    ExternalAutoRepairShop = externalAutoRepairShops[0],
                    Vehicle = vehicles[0],
                    SupplierBillNumber = "B-01-01",
                    TotalAmountInEGP = 3121.0M
                }
            };
            // ...
            UserCommand[] userCommands = new UserCommand[]
            {
                new UserCommand()
                {
                    Sequence = 10,
                    Name = nameof(VehicleCategory),
                    DisplayName = "Vehicle Categories"
                },
                new UserCommand()
                {
                    Sequence = 20,
                    Name = nameof(VehicleModel),
                    DisplayName = "Vehicle Models"
                },
                new UserCommand()
                {
                    Sequence = 30,
                    Name = nameof(ExternalAutoRepairShop),
                    DisplayName = "External Auto Repair Shops"
                },
                new UserCommand()
                {
                    Sequence = 40,
                    Name = nameof(ExternalRepairBill),
                    DisplayName = "External Repair Bills"
                },
                new UserCommand()
                {
                    Sequence = 50,
                    Name = nameof(Period),
                    DisplayName = "Periods"
                },
                new UserCommand()
                {
                    Sequence = 60,
                    Name = nameof(VehicleKilometerReading),
                    DisplayName = "Kilometer Readings"
                },
                new UserCommand()
                {
                    Sequence = 70,
                    Name = nameof(FuelConsumption),
                    DisplayName = "Fuel Consumption"
                },
                new UserCommand()
                {
                    Sequence = 80,
                    Name = nameof(VehicleViolation),
                    DisplayName = "Vehicle Violations"
                },
                new UserCommand()
                {
                    Sequence = 90,
                    Name = nameof(Uom),
                    DisplayName = "Units Of Measure"
                },
                new UserCommand()
                {
                    Sequence = 100,
                    Name = nameof(SparePart),
                    DisplayName = "Spare Parts"
                },
                new UserCommand()
                {
                    Sequence = 110,
                    Name = nameof(UomConversion),
                    DisplayName = "Units Of Measure Conversions"
                },
                new UserCommand()
                {
                    Sequence = 120,
                    Name = nameof(Driver),
                    DisplayName = "Drivers"
                }
            };
            // ...
            context.Locations.AddRange(locations);
            context.VehicleCategories.AddRange(vehicleCategories);
            context.FuelTypes.AddRange(fuelTypes);
            context.VehicleModels.AddRange(vehicleModels);
            context.VehicelOvallStates.AddRange(overallStates);
            context.ExternalAutoRepairShops.AddRange(externalAutoRepairShops);
            context.Uoms.AddRange(uoms);
            context.ViolationTypes.AddRange(violationTypes);
            context.Vehicels.AddRange(vehicles);
            context.UserCommands.AddRange(userCommands);
            context.Periods.AddRange(periods);
            context.ExternalRepairBills.AddRange(externalRepairBills);
            // ........
            context.SaveChanges();
        }
    }
}
