using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using Reftruckegypt.Servicecenter.ViewModels.VehicleModelViewModels;
using Reftruckegypt.Servicecenter.ViewModels.ExternalAutoRepairShopViewModels;
using Reftruckegypt.Servicecenter.ViewModels.ExternalRepairBillViewModels;
using Reftruckegypt.Servicecenter.Views.VehicleStateChangeViews;
using Reftruckegypt.Servicecenter.Views.VehicleViews;
using Reftruckegypt.Servicecenter.Views;
using Reftruckegypt.Servicecenter.Views.VehicleCategoryViews;
using Reftruckegypt.Servicecenter.ViewModels.PeriodViewModels;
using Reftruckegypt.Servicecenter.ViewModels.DriverViewModels;

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
            using (Views.MainView view = ServiceProvider.GetRequiredService<Views.MainView>())
            {
                Application.Run(view);
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
            services.AddTransient(typeof(Data.EF.ReftruckDbContext), (serviceProvider) =>
            {
                return new Data.EF.ReftruckDbContext(Configuration.GetConnectionString("ReftruckDBDevConnection"));
            });
            // Data ....
            services.AddTransient<Data.Abstractions.IUnitOfWork, Data.EF.UnitOfWork>();
            services.AddTransient<Data.Abstractions.IVehicleCategoryRepository, Data.EF.VehicleCategoryRepository>();
            // Validators .....
            services
                .AddSingleton<IValidator<SparePartsPriceList>, SparePartsPriceListValidator>()
                .AddSingleton<IValidator<SparePartPriceListLine>, SparePartPriceListLineValidator>()
                .AddSingleton<IValidator<Driver>,DriverValidator>()
                .AddSingleton<IValidator<ExternalAutoRepairShop>, ExternalAutoRepairShopValidator>()
                .AddSingleton<IValidator<ExternalRepairBill>, ExternalRepairBillValidator>()
                .AddSingleton<IValidator<Vehicle>, VehicleValidator>()
                .AddSingleton<IValidator<VehicleLicense>, VehicleLicenseValidator>()
                .AddSingleton<IValidator<FuelCard>, FuelCardValidator>()
                .AddSingleton<IValidator<FuelConsumption>, FuelConsumptionValidator>()
                .AddSingleton<IValidator<FuelType>, FuelTypeValidator>()
                .AddSingleton<IValidator<Location>, LocationValidator>()
                .AddSingleton<IValidator<Period>, PeriodValidator>()
                .AddSingleton<IValidator<Uom>, UomValidator>()
                .AddSingleton<IValidator<VehicleCategory>, VehicleCategoryValidator>()
                .AddSingleton<IValidator<VehicleKilometerReading>, VehicleKilometerReadingValidator>()
                .AddSingleton<IValidator<VehicleModel>, VehicleModelValidator>()
                .AddSingleton<IValidator<VehicleStateChange>, VehicleStateChangeValidator>()
                .AddSingleton<IValidator<VehicleViolation>, VehicleViolationValidator>()
                .AddSingleton<IValidator<ViolationType>, ViolationTypeValidator>()
                .AddSingleton<IValidator<SparePart>, SparePartValidator>()
                .AddSingleton<IValidator<UomConversion>, UomConversionValidator>()
                .AddSingleton<IValidator<SparePartsBill>, SparePartsBillValidator>()
                .AddSingleton<IValidator<SparePartsBillLine>, SparePartsBillLineValidator>();
            // ....
            services.AddSingleton<Common.IApplicationContext, Common.WindowsFormsApplicationContext>((sp) =>
            {
                return new Common.WindowsFormsApplicationContext(sp.GetRequiredService<Views.MainView>());
            });
            // ....
            services.AddTransient(typeof(ViewModels.VehicleCategoryViewModels.VehicleCategorySearchViewModel));
            services.AddTransient(typeof(ViewModels.NavigatorViewModel));
            services.AddTransient(typeof(VehicleModelSearchViewModel));
            services.AddTransient(typeof(ExternalAutoRepairShopSearchViewModel));
            services.AddTransient(typeof(ExternalRepairBillSearchViewModel));
            services.AddTransient(typeof(PeriodSearchViewModel));
            services.AddTransient(typeof(ViewModels.VehicleKilometerReadingViewModels.VehicleKilometerReadingSearchViewModel));
            services.AddTransient(typeof(ViewModels.FuelConsumptionViewModels.FuelConsumptionSearchViewModel));
            services.AddTransient(typeof(ViewModels.VehicleViolationViewModels.VehicleViolationSearchViewModel));
            services.AddTransient(typeof(ViewModels.UomViewModels.UomSearchViewModel));
            services.AddTransient(typeof(ViewModels.SparePartViewModels.SparePartSearchViewModel));
            services.AddTransient(typeof(ViewModels.UomConversionViewModels.UomConversionSearchViewModel));
            services.AddTransient(typeof(DriverSearchViewModel));
            services.AddTransient(typeof(ViewModels.SparePartsPriceListViewModels.SparePartsPriceListSearchViewModel));
            services.AddTransient(typeof(ViewModels.SparePartsBillViewModels.SparePartsBillSearchViewModel));
            services.AddTransient(typeof(ViewModels.FuelCardViewModels.FuelCardSearchViewModel));
            services.AddTransient(typeof(ViewModels.VehicleViewModels.VehicleSearchViewModel))
                .AddTransient(typeof(ViewModels.VehicleStateChangeViewModels.VehicleStateChangeSearchViewModel));
            // ....
            services.AddSingleton(typeof(Views.MainView));
            services.AddSingleton(typeof(NavigatorView));
            services.AddTransient(typeof(VehicleCategoriesView));
            services.AddTransient(typeof(Views.VehicleModelViews.VehicleModelsView));
            services.AddTransient(typeof(Views.ExternalAutoRepairShopViews.ExternalAutoRepairShopsView));
            services.AddTransient(typeof(Views.ExternalRepairBillViews.ExternalRepairBillsView));
            services.AddTransient(typeof(Views.PeriodViews.PeriodsView));
            services.AddTransient(typeof(Views.VehicleKilometerReadingViews.VehicleKilometerReadingsView));
            services.AddTransient(typeof(Views.FuelConsumptionViews.FuelConsumptionsView));
            services.AddTransient(typeof(Views.VehicleViolationViews.VehicleViolationsView));
            services.AddTransient(typeof(Views.UomViews.UomsView));
            services.AddTransient(typeof(Views.SparePartViews.SparePartsView));
            services.AddTransient(typeof(Views.UomConversionViews.UomConversionsView));
            services.AddTransient(typeof(Views.DriverViews.DriversView));
            services.AddTransient(typeof(Views.SparePartsPriceListViews.PriceListsView));
            services.AddTransient(typeof(Views.SparePartsBillViews.SparePartsBillsView));
            services.AddTransient(typeof(Views.FuelCardViews.FuelCardsView));
            services.AddTransient(typeof(VehiclesView))
                .AddTransient(typeof(VehicleStateChangesView));
            
            // ....

        }
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IConfiguration Configuration { get; private set; }
    }
}
