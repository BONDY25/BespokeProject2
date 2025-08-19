using Microsoft.Data.SqlClient;
using System.Data;

namespace BespokeProject_2
{
    public partial class Exceptions : Form
    {

        //=============================================================================================================================================================================================
        //-- Initialization --//
        //=============================================================================================================================================================================================

        // SQL Server Connection String
        private const string connectionString = SessionMaintenance.connectionString;

        public string userName { get; set; }
        public string sessionId { get; set; }
        public string client { get; set; }

        public Exceptions()
        {
            InitializeComponent();
            this.KeyDown += Exceptions_KeyDown;
            this.KeyPreview = true;
        }

        private void Exceptions_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook($"", "[ExceptionsForm]", "[Exceptions_Load]", $"Form Started");
            PopulateTable();

        }      


        //=============================================================================================================================================================================================
        //-- Operation Methods --//
        //=============================================================================================================================================================================================

        private void PopulateTable()
        {
            DataTable dataTable = new DataTable(); // Create New datatable to Store Results

            string selectQuery = "SELECT Ref_No as [Exceptions] FROM BespokeProjects_Exceptions WHERE Client_ID = @Client_ID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client_ID", ClientID());

                        SqlDataReader reader = cmd.ExecuteReader();
                        dataTable.Load(reader);

                    }
                    conn.Close();

                    resultsTable.DataSource = dataTable; // Populate Table With The Results
                    SessionMaintenance.LogBook($"", "[ExceptionsForm]", "[PopulateTable]", $"Table populated with data from parameter: {ClientID()}");
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An Error occured Populating Table: \n {ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[ExceptionsForm]", "[PopulateTable]", $"FAILED (  {ex.Message}  )");
            }
        }

        private void InsertException()
        {
            string ExceptionRef = txbRefNo.Text;
            string query = "[BespokeProject_Insert_Exceptions] @Ref_No, @Client_ID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ref_No", ExceptionRef);
                        cmd.Parameters.AddWithValue("@Client_ID", ClientID());

                        cmd.ExecuteNonQuery();

                        txbRefNo.Text = null;

                        SessionMaintenance.LogBook($"", "[ExceptionsForm]", "[InsertException]", $"New Exception Reference inserted: {ExceptionRef}");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An Error occured Inserting Data: \n {ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[ExceptionsForm]", "[InsertException]", $"FAILED (  {ex.Message}  )");
            }

        }

        public string ClientID()
        {
            string clientID = null;

            string query = "SELECT [ID] FROM BespokeProject_Clients WHERE [Description] = @Client";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameter and set its value
                        cmd.Parameters.AddWithValue("@Client", client);

                        // Execute the command
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check if there are any results
                            if (reader.Read())
                            {
                                // Get the client ID from the result
                                clientID = reader["ID"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An Error occured getting Client ID: \n {ex.Message}");
            }

            return clientID;
        }

        //=============================================================================================================================================================================================
        //-- Enviroment Events --//
        //=============================================================================================================================================================================================

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnClose);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnClose);
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnAdd);
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnAdd);
        }

        private void txbRefNo_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(txbRefNo);
        }

        private void txbRefNo_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(txbRefNo);
        }

        //=============================================================================================================================================================================================
        //-- Button Click Events --//
        //=============================================================================================================================================================================================

        private void btnClose_Click(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook($"", "[ExceptionsForm]", "[btnClose_Click]", $"Form Closed");
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string exceptionRef = txbRefNo.Text;

            if (string.IsNullOrEmpty(exceptionRef))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"Please enter an Exception Reference");
                return;
            }
            else
            {
                InsertException();
                PopulateTable();
                txbRefNo.Focus();
            }
        }



        //=============================================================================================================================================================================================
        //-- Key Down Events --//
        //=============================================================================================================================================================================================

        // Keyboard Shortcuts
        private void Exceptions_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                txbRefNo.Text = null;
                txbRefNo.Focus();
            }

            // ctrl + S
            if (e.Control && e.KeyCode == Keys.S)
            {

                btnAdd_Click(sender, e);
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {

                btnClose_Click(sender, e);
            }
        }
    }
}
