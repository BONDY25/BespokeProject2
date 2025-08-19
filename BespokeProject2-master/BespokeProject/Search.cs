using Microsoft.Data.SqlClient;
using System.Data;

namespace BespokeProject_2
{
    public partial class Search : Form
    {
        //=============================================================================================================================================================================================
        //-- Initialization --//
        //=============================================================================================================================================================================================

        private const string connectionString = SessionMaintenance.connectionString;
        public string userName { get; set; }

        public string sessionId { get; set; }

        public Search()
        {
            InitializeComponent();
        }

        // Form Load --------------------------------------------------------------------------------------------------------------------------------
        private void Search_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[Search]", "[FormLoad]", "Form Started");
            Text = $"{Environment.UserName.ToUpper()} - Bespoke Project II Input";
        }

        // Form Close --------------------------------------------------------------------------------------------------------------------------------
        private void Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionMaintenance.LogBook("", "[Search]", "[FormLoad]", "Form Closed");
        }

        //=============================================================================================================================================================================================
        //-- Operation Methods --//
        //=============================================================================================================================================================================================

        // Get Results --------------------------------------------------------------------------------------------------------------------------------
        private void GetResults(string search)
        {
            string query = "EXECUTE [BespokeProject_LP_Get_Details] @Mode, @Session_Id, @Search";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Mode", "2");
                        cmd.Parameters.AddWithValue("@Session_Id", sessionId);
                        cmd.Parameters.AddWithValue("@Search", search);
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }

                SessionMaintenance.LogBook("", "[Search]", "[GetResults]", $"Search Executed: {search}");
            }
            // Catch Errors
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("117", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[Search]", "[GetResults]", $"FAILED: Code 117 (  {ex.Message}  )");
            }
        }

        // Populate History Table --------------------------------------------------------------------------------------------------------------------------------
        private void PopulateDataGrid()
        {
            string query = "SELECT [License_Plate], [Consignment], [DT_Created], [Status], [Last_Updated], [Last_Upd_User] FROM BespokeProject_LP_Search_Results WHERE Session_Id = @Session_Id ORDER BY DT_Created DESC";

            DataTable dataTable = new DataTable();

            try
            {
                // Start SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@Session_Id", sessionId);

                        // Execute Query
                        cmd.ExecuteNonQuery();

                        // Execute Data Reader
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Populate DataTable From Reader
                        dataTable.Load(reader);
                    }

                    conn.Close(); // Close SQL Connection

                    // Populate Data Grid
                    dgHistory.DataSource = dataTable;
                    dgHistory.Refresh();
                }

                SessionMaintenance.LogBook("", "[Search]", "[PopulateDataGrid]", $"DataGrid Populated");
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("117", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[Search]", "[PopulateDataGrid]", $"FAILED: Code 117 (  {ex.Message}  )");
            }
        }

        // SearchFunction --------------------------------------------------------------------------------------------------------------------------------
        private void SearchFunction(string search)
        {
            GetResults(search);
            PopulateDataGrid();
        }

        //=============================================================================================================================================================================================
        //-- Enviroment Events --//
        //=============================================================================================================================================================================================

        // Search Field --------------------------------------------------------------------------------------------------------------------------------
        private void txbSearch_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(txbSearch);
        }

        private void txbSearch_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(txbSearch);
            btnSearch_Click(sender, e);
        }

        // Search Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnSearch);
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnSearch);
        }

        // Close Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnClose);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnClose);
        }

        //=============================================================================================================================================================================================
        //-- Button Click Events --//
        //=============================================================================================================================================================================================

        // Close Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)  // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("Error Closing Module");
                SessionMaintenance.LogBook($"ERROR", "[SearchForm]", "[btnClose_Click]", $"FAILED (  {ex.Message}  )");
                Application.Exit();
            }
        }

        // Search Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txbSearch.Text;
            SearchFunction(search);
        }

        //=============================================================================================================================================================================================
        //-- Key Down Events --//
        //=============================================================================================================================================================================================

        // Keyboard Shortcuts --------------------------------------------------------------------------------------------------------------------------------
        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                dgHistory.DataSource = null;
                dgHistory.Refresh();
                txbSearch.Text = "";
                txbSearch.Focus();
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, e);
            }
        }
    }
}
