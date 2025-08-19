using Microsoft.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace BespokeProject_2
{
    public partial class DashboardForm : Form
    {
        //=============================================================================================================================================================================================
        //-- Initialization --//
        //=============================================================================================================================================================================================

        private const string connectionString = SessionMaintenance.connectionString;

        public DashboardForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        // Form Load & Close --------------------------------------------------------------------------------------------------------------------------------
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[DashboardForm]", "[FormLoad]", "Form Started");
            Text = $"{Environment.UserName.ToUpper()} - Bespoke Project II Dashboard";
            RefreshResults();
        }
        private void DashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionMaintenance.LogBook("", "[DashboardForm]", "[FormClosing]", "Form Closed");
        }

        //=============================================================================================================================================================================================
        //-- Operation Methods --//
        //=============================================================================================================================================================================================

        // Refresh Results --------------------------------------------------------------------------------------------------------------------------------
        private void RefreshResults()
        {
            PopulateDataGrids(1);
            PopulateDataGrids(2);
            PopulateTotals(1);
            PopulateTotals(2);

            lblTitle.Text = $"Dashboard @ {DateTime.Now}";
        }

        // Populate Tables --------------------------------------------------------------------------------------------------------------------------------
        private void PopulateDataGrids(int pram)
        {
            DataGridView dataGrid = null;
            DataTable dataTable = new DataTable();
            string query = "";

            switch (pram)
            {
                case 1:
                    dataGrid = dglog;
                    query = "SELECT DT_Created,Domain_User,Form,Event,Notes FROM BespokeProject_LogBook WHERE CAST(DT_Created as date) = CAST(GETDATE() as date) ORDER BY DT_Created DESC";
                    break;
                case 2:
                    dataGrid = dgConsign;
                    query = "SELECT* FROM BespokeProject_LP_Details WHERE CAST(DT_Created as date) = CAST(GETDATE() as date) ORDER BY DT_Created DESC";
                    break;
            }

            try
            {
                // Start SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Execute Query
                        cmd.ExecuteNonQuery();

                        // Execute Data Reader
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Populate DataTable From Reader
                        dataTable.Load(reader);
                    }

                    conn.Close(); // Close SQL Connection

                    // Populate Data Grid
                    dataGrid.DataSource = dataTable;
                    dataGrid.Refresh();
                }

            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("117", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[DashboardForm]", "[PopulateDataGrid]", $"FAILED: Code 177 (  {ex.Message}  )");
            }

        }

        // Populate Totals --------------------------------------------------------------------------------------------------------------------------------
        private void PopulateTotals(int pram)
        {
            Label label = null;
            string query = "";
            string results = "";
            string labelText = "";

            switch (pram)
            {
                case 1:
                    label = lblLog;
                    query = "SELECT COUNT(*) as Results FROM BespokeProject_LogBook WHERE CAST(DT_Created as date) = CAST(GETDATE() as date)";
                    labelText = "Log Entries: ";
                    break;
                case 2:
                    label = lblConsign;
                    query = "SELECT COUNT(*) as Results FROM BespokeProject_LP_Details WHERE CAST(DT_Created as date) = CAST(GETDATE() as date)";
                    labelText = "Consignments: ";
                    break;
                default: label = lblTitle; break;
            }

            try
            {
                // Start SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Execute Data Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Populate variables from reader
                            while (reader.Read())
                            {
                                results = reader["Results"].ToString();
                            }
                        }
                    }

                    conn.Close(); // Close SQL Connection

                }

                label.Text = labelText + results;

            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("117", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[DashboardForm]", "[PopulateTotals]", $"FAILED: Code 117 (  {ex.Message}  )");
            }

        }

        //=============================================================================================================================================================================================
        //-- Enviroment Events --//
        //=============================================================================================================================================================================================

        // Close Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnClose);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnClose);
        }

        // Refresh Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnRefresh_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnRefresh);
        }

        private void btnRefresh_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnRefresh);
        }

        //=============================================================================================================================================================================================
        //-- Button Click Events --//
        //=============================================================================================================================================================================================

        // Close Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Refresh Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshResults();
        }

        //=============================================================================================================================================================================================
        //-- Key Down Events --//
        //=============================================================================================================================================================================================

        private void DashboardForm_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + R
            if (e.Control && e.KeyCode == Keys.G)
            {
                btnRefresh_Click(sender, e);
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, e);
            }
        }
    }
}
