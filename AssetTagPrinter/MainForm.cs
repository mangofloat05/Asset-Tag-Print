using System;
using System.Windows.Forms;

namespace AssetTagPrinter
{
    public partial class MainForm : Form
    {
        private PrinterService _printerService;
        private CsvService _csvService;

        public MainForm()
        {
            InitializeComponent();
            _printerService = new PrinterService();
            _csvService = new CsvService();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                var assets = _csvService.ReadAssets("data.csv");
                dataGridViewAssets.DataSource = new BindingSource { DataSource = assets };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading assets: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                _printerService.Open();
                foreach (DataGridViewRow row in dataGridViewAssets.Rows)
                {
                    if (row.DataBoundItem is Asset asset)
                    {
                        _printerService.PrintAssetTag(asset);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error printing: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _printerService?.Close();
            }
        }
    }
}
