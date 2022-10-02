using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using Reftruckegypt.Servicecenter.Data.EF;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models.Validation;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.ViewModels.VehicleCategoryViewModels;


namespace Reftruckegypt.Servicecenter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run();
            using(var context = new ReftruckDbContext(Configuration.GetConnectionString("ReftruckDBDevConnection")))
            {
                var vehicles = context.Vehicels.ToList();
                MessageBox.Show(vehicles[0].FuelCard?.Number);
            }
        }
        static Program()
        {
            var builder =
                new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            // DbContext ...
            services.AddTransient(typeof(ReftruckDbContext), (serviceProvider) =>
            {
                return new ReftruckDbContext(Configuration.GetConnectionString("ReftruckDBDevConnection"));
            });
            // Data ....
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IVehicleCategoryRepository, VehicleCategoryRepository>();
            // Validators .....
            services.AddSingleton<IValidator<Driver>,DriverValidator>();
            services.AddSingleton<IValidator<ExternalAutoRepairShop>, ExternalAutoRepairShopValidator>();
            services.AddSingleton<IValidator<ExternalRepairBill>, ExternalRepairBillValidator>();
            services.AddSingleton<IValidator<FuelCard>, FuelCardValidator>();
            services.AddSingleton<IValidator<FuelConsumption>, FuelConsumptionValidator>();
            services.AddSingleton<IValidator<FuelType>, FuelTypeValidator>();
            services.AddSingleton<IValidator<Location>, LocationValidator>();
            services.AddSingleton<IValidator<Period>, PeriodValidator>();
            services.AddSingleton<IValidator<Uom>, UomValidator>();
            services.AddSingleton<IValidator<VehicleCategory>, VehicleCategoryValidator>();
            services.AddSingleton<IValidator<VehicleKilometerReading>, VehicleKilometerReadingValidator>();
            services.AddSingleton<IValidator<VehicleModel>, VehicleModelValidator>();
            services.AddSingleton<IValidator<VehicleStateChange>, VehicleStateChangeValidator>();
            services.AddSingleton<IValidator<VehicleViolation>, VehicleViolationValidator>();
            services.AddSingleton<IValidator<ViolationType>, ViolationTypeValidator>();
            services.AddSingleton<IValidator<SparePart>, SparePartValidator>();
            // ....
            services.AddSingleton<Common.IApplicationContext, Common.WindowsFormsApplicationContext>();
            // ....
            services.AddTransient(typeof(VehicleCategorySearchViewModel));
            // ....

        }
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IConfiguration Configuration { get; private set; }
    }
}
