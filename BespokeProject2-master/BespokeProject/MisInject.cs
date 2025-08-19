using Microsoft.Data.SqlClient;
using System.Data;

namespace BespokeProject_2
{
    public partial class MisInject : Form
    {
        //=============================================================================================================================================================================================
        //-- Initialization --//
        //=============================================================================================================================================================================================

        private const string connectionString = SessionMaintenance.connectionString;
        public string userName { get; set; }

        public string sessionId { get; set; }

        public MisInject()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        // Form Load --------------------------------------------------------------------------------------------------------------------------------
        private void MisInject_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[MisInject]", "[FormLoad]", "Form Started");
            Text = $"{Environment.UserName.ToUpper()} - Bespoke Project II Mis-Injections";
            GetMisInjection();
        }       

        //=============================================================================================================================================================================================
        //-- Operation Methods --//
        //=============================================================================================================================================================================================

        private void GetMisInjection()
        {
            string query = "SELECT* FROM BespokeProject_LP_MisInject ORDER BY DT_Created DESC";
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
                        // cmd.Parameters.AddWithValue("@Session_Id", sessionId);

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

                SessionMaintenance.LogBook("", "[MisInject]", "[PopulateDataGrid]", $"DataGrid Populated");
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("117", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[MisInject]", "[PopulateDataGrid]", $"FAILED (  {ex.Message}  )");
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

        //=============================================================================================================================================================================================
        //-- Button Click Events --//
        //=============================================================================================================================================================================================

        // Close Button Click --------------------------------------------------------------------------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //=============================================================================================================================================================================================
        //-- Key Down Events --//
        //=============================================================================================================================================================================================

        private void MisInject_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + R
            if (e.Control && e.KeyCode == Keys.R)
            {
                GetMisInjection();
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, e);
            }
        }
    }
}
