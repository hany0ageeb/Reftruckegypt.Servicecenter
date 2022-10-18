using Microsoft.Extensions.DependencyInjection;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Reftruckegypt.Servicecenter.ViewModels.DriverViewModels;
using Reftruckegypt.Servicecenter.ViewModels.ExternalRepairBillViewModels;
using Reftruckegypt.Servicecenter.ViewModels.FuelConsumptionViewModels;
using Reftruckegypt.Servicecenter.ViewModels.VehicleKilometerReadingViewModels;
using Reftruckegypt.Servicecenter.ViewModels.VehicleViolationViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Views
{
    public partial class MainView : Form 
    {
        private NavigatorView _navigatorView;
        public  bool IsExportEnabled 
        {
            get => exportToolStripMenuItem.Enabled;
            set
            {
                exportToolStripMenuItem.Enabled = value;
            }
        }
        public  void SetExportDisplayName(string displayName = "Export")
        {
            exportToolStripMenuItem.Text = displayName;
        }
        public void AddExportAction(EventHandler action)
        {
            exportToolStripMenuItem.Click += action;
        }
        public  void RemoveExportAction(EventHandler action)
        {
            
            exportToolStripMenuItem.Click -= action;
        }
        public void SetReportsMenu(IEnumerable<Models.UserReport> reports)
        {
            reportsToolStripMenuItem.DropDownItems.Clear();
            foreach(var rpt in reports)
            {
                var menuItem = new ToolStripMenuItem(rpt.DisplayName);
                menuItem.Click += (o, e) => rpt.Execute();
                this.reportsToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }
        public MainView()
        {
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            Load += (o, e) =>
            {
                _navigatorView = Program.ServiceProvider.GetRequiredService<NavigatorView>();
                _navigatorView.MdiParent = this;
                _navigatorView.Show();
            };
            openFileDialog1.Filter = "Excel Files (*.xlsx) | *.xlsx";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Multiselect = false;
            openFileDialog1.RestoreDirectory = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _navigatorView.Close();
        }

        private async void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    List<string> headers = ReadFileColumnHeaders(openFileDialog1.FileName);
                    using (ImportMappingViews.DriverMappingView driverMappingView = new ImportMappingViews.DriverMappingView(headers, openFileDialog1.FileName))
                    {
                        if (driverMappingView.ShowDialog(this) == DialogResult.OK && driverMappingView.Mapper != null)
                        {
                            using (var scope = Program.ServiceProvider.CreateScope())
                            {
                                DriverSearchViewModel driverSearchViewModel = scope.ServiceProvider.GetRequiredService<DriverSearchViewModel>();
                                Progress<int> progress = new Progress<int>();
                                toolStripProgressBar1.Visible = true;
                                toolStripProgressBar1.Value = 0;
                                progress.ProgressChanged += Progress_ProgressChanged;
                                string errorMessage = await driverSearchViewModel.ImportFromExcelFile(driverMappingView.Mapper, progress);
                                if (!string.IsNullOrEmpty(errorMessage))
                                {
                                    using (ImportErrorsView errorsView = new ImportErrorsView(errorMessage))
                                    {
                                        errorsView.ShowDialog(this);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                toolStripProgressBar1.Visible = false;
                toolStripProgressBar1.Value = 0;
                Cursor = Cursors.Default;
            }
        }
        private async void externalRepairInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    List<string> headers = ReadFileColumnHeaders(openFileDialog1.FileName);
                    using (ImportMappingViews.ExternalRepairBillMappingView externalRepairBillMappingView = new ImportMappingViews.ExternalRepairBillMappingView(headers, openFileDialog1.FileName))
                    {
                        if(externalRepairBillMappingView.ShowDialog(this) == DialogResult.OK && externalRepairBillMappingView.Mapper != null)
                        {
                            using (var scope = Program.ServiceProvider.CreateScope())
                            {
                                ExternalRepairBillSearchViewModel searchViewModel = scope.ServiceProvider.GetRequiredService<ExternalRepairBillSearchViewModel>();
                                Progress<int> progress = new Progress<int>();
                                toolStripProgressBar1.Visible = true;
                                toolStripProgressBar1.Value = 0;
                                progress.ProgressChanged += Progress_ProgressChanged;
                                string errorMessage = await searchViewModel.ImportFromExcelFile(externalRepairBillMappingView.Mapper, progress);
                                if (!string.IsNullOrEmpty(errorMessage))
                                {
                                    using (ImportErrorsView errorsView = new ImportErrorsView(errorMessage))
                                    {
                                        errorsView.ShowDialog(this);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                toolStripProgressBar1.Visible = false;
                toolStripProgressBar1.Value = 0;
                Cursor = Cursors.Default;
            }
        }
        private async void vehicleKilmeterReadingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    List<string> headers = ReadFileColumnHeaders(openFileDialog1.FileName);
                    using(ImportMappingViews.VehicleKilometerReadingMappingView vehicleKilometerReadingMapping = new ImportMappingViews.VehicleKilometerReadingMappingView(headers, openFileDialog1.FileName))
                    {
                        if(vehicleKilometerReadingMapping.ShowDialog(this) == DialogResult.OK && vehicleKilometerReadingMapping.Mapper != null)
                        {
                            using (var scope = Program.ServiceProvider.CreateScope())
                            {
                                VehicleKilometerReadingSearchViewModel searchViewModel = scope.ServiceProvider.GetRequiredService<VehicleKilometerReadingSearchViewModel>();
                                Progress<int> progress = new Progress<int>();
                                toolStripProgressBar1.Visible = true;
                                toolStripProgressBar1.Value = 0;
                                progress.ProgressChanged += Progress_ProgressChanged;
                                string errorMessage = await searchViewModel.ImportFromExcelFile(vehicleKilometerReadingMapping.Mapper, progress);
                                if (!string.IsNullOrEmpty(errorMessage))
                                {
                                    using (ImportErrorsView errorsView = new ImportErrorsView(errorMessage))
                                    {
                                        errorsView.ShowDialog(this);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                toolStripProgressBar1.Visible = false;
                toolStripProgressBar1.Value = 0;
                Cursor = Cursors.Default;
            }
        }
        private async void vehiclesViolationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    List<string> headers = ReadFileColumnHeaders(openFileDialog1.FileName, 6);
                    using(ImportMappingViews.VehicleViolationMappingView violationMappingView = new ImportMappingViews.VehicleViolationMappingView(headers, openFileDialog1.FileName))
                    {
                        if(violationMappingView.ShowDialog(this) == DialogResult.OK && violationMappingView.Mapper != null)
                        {
                            using (var scope = Program.ServiceProvider.CreateScope())
                            {
                                VehicleViolationSearchViewModel searchViewModel = scope.ServiceProvider.GetRequiredService<VehicleViolationSearchViewModel>();
                                Progress<int> progress = new Progress<int>();
                                toolStripProgressBar1.Visible = true;
                                toolStripProgressBar1.Value = 0;
                                progress.ProgressChanged += Progress_ProgressChanged;
                                string errorMessage = await searchViewModel.ImportFromExcelFile(violationMappingView.Mapper, progress);
                                if (!string.IsNullOrEmpty(errorMessage))
                                {
                                    using (ImportErrorsView errorsView = new ImportErrorsView(errorMessage))
                                    {
                                        errorsView.ShowDialog(this);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                toolStripProgressBar1.Visible = false;
                toolStripProgressBar1.Value = 0;
                Cursor = Cursors.Default;
            }
        }
       
        private async void fuelConsumptionsToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                // Read File Headers ....
                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    List<string> headers = ReadFileColumnHeaders(openFileDialog1.FileName);
                    using (ImportMappingViews.FuelConsumptionMappingView fuelConsumptionMappingView = new ImportMappingViews.FuelConsumptionMappingView(headers,openFileDialog1.FileName))
                    {
                        
                        if(fuelConsumptionMappingView.ShowDialog(this) == DialogResult.OK && fuelConsumptionMappingView.Mapper != null)
                        {
                            using(var scope = Program.ServiceProvider.CreateScope())
                            {
                                FuelConsumptionSearchViewModel fuelConsumptionSearchViewModel = scope.ServiceProvider.GetRequiredService<FuelConsumptionSearchViewModel>();
                                Progress<int> progress = new Progress<int>();
                                toolStripProgressBar1.Visible = true;
                                toolStripProgressBar1.Value = 0;
                                progress.ProgressChanged += Progress_ProgressChanged;
                                string errorMessage = await fuelConsumptionSearchViewModel.ImportFromExcelFile(fuelConsumptionMappingView.Mapper, progress);
                                if (!string.IsNullOrEmpty(errorMessage))
                                {
                                    using(ImportErrorsView errorsView = new ImportErrorsView(errorMessage))
                                    {
                                        errorsView.ShowDialog(this);
                                    }
                                }
                            }
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                toolStripProgressBar1.Visible = false;
                toolStripProgressBar1.Value = 0;
                Cursor = Cursors.Default;
            }
        }

        private void Progress_ProgressChanged(object sender, int e)
        {
            if(toolStripProgressBar1.Value != e)
            {
                toolStripProgressBar1.Value = e;
            }
        }

        private List<string> ReadFileColumnHeaders(string fileName, int startRowIndex = 1)
        {
            List<string> columnsHeaders = new List<string>();
            XSSFWorkbook book = null;
            try
            {
                book = new XSSFWorkbook(fileName);
                ISheet sheet = book.GetSheetAt(0);
                if (sheet != null)
                {
                    IRow row = sheet.GetRow(startRowIndex - 1);
                    if (row != null)
                    {
                        for (int index = 0; index < row.LastCellNum; index++)
                        {
                            ICell cell = row.GetCell(index);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (!string.IsNullOrEmpty(cellValue))
                                {
                                    columnsHeaders.Add(cellValue);
                                }
                            }
                        }
                    }
                }
                
            }
            finally
            {
                if (book != null)
                    book.Close();
            }
            return columnsHeaders;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(AboutView aboutView = new AboutView())
            {
                aboutView.ShowDialog(this);
            }
        }

       
    }
}
