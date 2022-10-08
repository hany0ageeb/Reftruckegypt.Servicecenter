﻿using System;
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
using Reftruckegypt.Servicecenter.Views.VehicleCategoryViews;
using Reftruckegypt.Servicecenter.Views;
using Reftruckegypt.Servicecenter.Views.VehicleModelViews;
using Reftruckegypt.Servicecenter.Views.ExternalAutoRepairShopViews;
using Reftruckegypt.Servicecenter.ViewModels.VehicleModelViewModels;
using Reftruckegypt.Servicecenter.ViewModels.ExternalAutoRepairShopViewModels;
using Reftruckegypt.Servicecenter.Views.ExternalRepairBillViews;
using Reftruckegypt.Servicecenter.ViewModels.ExternalRepairBillViewModels;
using Reftruckegypt.Servicecenter.ViewModels.PeriodViewModels;
using Reftruckegypt.Servicecenter.Views.PeriodViews;
using Reftruckegypt.Servicecenter.ViewModels.VehicleKilometerReadingViewModels;
using Reftruckegypt.Servicecenter.Views.VehicleKilometerReadingViews;
using Reftruckegypt.Servicecenter.ViewModels.FuelConsumptionViewModels;
using Reftruckegypt.Servicecenter.Views.FuelConsumptionViews;
using Reftruckegypt.Servicecenter.ViewModels.VehicleViolationViewModels;
using Reftruckegypt.Servicecenter.Views.VehicleViolationViews;
using Reftruckegypt.Servicecenter.Views.UomViews;
using Reftruckegypt.Servicecenter.ViewModels.UomViewModels;
using Reftruckegypt.Servicecenter.ViewModels.SparePartViewModels;
using Reftruckegypt.Servicecenter.Views.SparePartViews;
using Reftruckegypt.Servicecenter.ViewModels.UomConversionViewModels;
using Reftruckegypt.Servicecenter.Views.UomConversionViews;
using Reftruckegypt.Servicecenter.Views.DriverViews;
using Reftruckegypt.Servicecenter.ViewModels.DriverViewModels;
using Reftruckegypt.Servicecenter.Views.SparePartsPriceListViews;
using Reftruckegypt.Servicecenter.Views.SparePartsBillViews;
using Reftruckegypt.Servicecenter.ViewModels.SparePartsPriceListViewModels;
using Reftruckegypt.Servicecenter.ViewModels.SparePartsBillViewModels;

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
            using (MainView view = ServiceProvider.GetRequiredService<MainView>())
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
            services.AddTransient(typeof(ReftruckDbContext), (serviceProvider) =>
            {
                return new ReftruckDbContext(Configuration.GetConnectionString("ReftruckDBDevConnection"));
            });
            // Data ....
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IVehicleCategoryRepository, VehicleCategoryRepository>();
            // Validators .....
            services.AddSingleton<IValidator<SparePartsPriceList>, SparePartsPriceListValidator>();
            services.AddSingleton<IValidator<SparePartPriceListLine>, SparePartPriceListLineValidator>();
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
            services.AddSingleton<IValidator<UomConversion>, UomConversionValidator>();
            services.AddSingleton<IValidator<SparePartsBill>, SparePartsBillValidator>();
            services.AddSingleton<IValidator<SparePartsBillLine>, SparePartsBillLineValidator>();
            // ....
            services.AddSingleton<Common.IApplicationContext, Common.WindowsFormsApplicationContext>((sp) =>
            {
                return new Common.WindowsFormsApplicationContext(sp.GetRequiredService<MainView>());
            });
            // ....
            services.AddTransient(typeof(VehicleCategorySearchViewModel));
            services.AddTransient(typeof(ViewModels.NavigatorViewModel));
            services.AddTransient(typeof(VehicleModelSearchViewModel));
            services.AddTransient(typeof(ExternalAutoRepairShopSearchViewModel));
            services.AddTransient(typeof(ExternalRepairBillSearchViewModel));
            services.AddTransient(typeof(PeriodSearchViewModel));
            services.AddTransient(typeof(VehicleKilometerReadingSearchViewModel));
            services.AddTransient(typeof(FuelConsumptionSearchViewModel));
            services.AddTransient(typeof(VehicleViolationSearchViewModel));
            services.AddTransient(typeof(UomSearchViewModel));
            services.AddTransient(typeof(SparePartSearchViewModel));
            services.AddTransient(typeof(UomConversionSearchViewModel));
            services.AddTransient(typeof(DriverSearchViewModel));
            services.AddTransient(typeof(SparePartsPriceListSearchViewModel));
            services.AddTransient(typeof(SparePartsBillSearchViewModel));
            // ....
            services.AddSingleton(typeof(MainView));
            services.AddSingleton(typeof(NavigatorView));
            services.AddTransient(typeof(VehicleCategoriesView));
            services.AddTransient(typeof(VehicleModelsView));
            services.AddTransient(typeof(ExternalAutoRepairShopsView));
            services.AddTransient(typeof(ExternalRepairBillsView));
            services.AddTransient(typeof(PeriodsView));
            services.AddTransient(typeof(VehicleKilometerReadingsView));
            services.AddTransient(typeof(FuelConsumptionsView));
            services.AddTransient(typeof(VehicleViolationsView));
            services.AddTransient(typeof(UomsView));
            services.AddTransient(typeof(SparePartsView));
            services.AddTransient(typeof(UomConversionsView));
            services.AddTransient(typeof(DriversView));
            services.AddTransient(typeof(PriceListsView));
            services.AddTransient(typeof(SparePartsBillsView));
            // ....

        }
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IConfiguration Configuration { get; private set; }
    }
}
