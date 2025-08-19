using Microsoft.Data.SqlClient;

namespace BespokeProject_2
{
    public partial class LocationManager : Form
    {
        //=============================================================================================================================================================================================
        //-- Initialization --//
        //=============================================================================================================================================================================================

        private const string connectionString = SessionMaintenance.connectionString;
        public string userName { get; set; }

        public string sessionId { get; set; }

        private InputEdit inputEdit;
        public LocationManager(InputEdit inputEdit)
        {
            InitializeComponent();
            this.inputEdit = inputEdit;
        }

        // Form Load --------------------------------------------------------------------------------------------------------------------------------
        private void LocationManager_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[LocationManager]", "[FormLoad]", "Form Started");
            Text = $"{Environment.UserName.ToUpper()} - Bespoke Project II Location Manager";
            PopulateComboBox(cbStatus, 2);
            txbLocation.Focus();
            txbDescr.Enabled = false;
            cbStatus.Enabled = false;
        }        

        // Populate Combo Boxes --------------------------------------------------------------------------------------------------------------------------------
        private void PopulateComboBox(System.Windows.Forms.ComboBox comboBox, int cb)
        {
            string query = "";


            switch (cb)
            {
                case 1: query = "SELECT [Colour] as [Description] FROM [BespokeProject_LP_Colours] WHERE [Active] = 1 ORDER BY [ID]"; break;
                case 2: query = "SELECT [Description] FROM [BespokeProject_LP_Status] WHERE ID IN ('001','002') ORDER BY [ID]"; break;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBox.Items.Clear();

                            while (reader.Read())
                            {
                                comboBox.Items.Add(reader["Description"].ToString());
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("112", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[LocationManager]", "[PopulateComboBox]", $"FAILED: Code 122 (  {ex.Message}  )");
                Application.Exit();
            }
        }

        //=============================================================================================================================================================================================
        //-- Operation Methods --//
        //=============================================================================================================================================================================================

        // Save Carrier --------------------------------------------------------------------------------------------------------------------------------
        private void SaveLocation(string location, string descr, string active)
        {
            string query = "EXECUTE [BespokeProject_LP_Update_Locations] @Location, @Description, @Active, @User";

            try
            {
                // Start SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@Location", location);
                        cmd.Parameters.AddWithValue("@Description", descr);
                        cmd.Parameters.AddWithValue("@Active", active);
                        cmd.Parameters.AddWithValue("@User", userName);

                        // Execute Query
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close(); // Close SQL Connection
                }

                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowInfo($"Location {location} Updated");

                inputEdit.PopulateComboBox();
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("225", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[LocationManager]", "[SaveLocation]", $"FAILED: Code 225 (  {ex.Message}  )");
            }

        }

        // Get Carrier --------------------------------------------------------------------------------------------------------------------------------
        private void GetLocation(string location)
        {

            string query = "EXECUTE [BespokeProject_LP_Get_Location] @Location";
            string descr = "";
            string status = "";

            try
            {
                // Start SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@Location", location);

                        // Execute Data Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Populate variables from reader
                            while (reader.Read())
                            {
                                descr = reader["Description"].ToString();
                                status = reader["Status"].ToString();
                            }
                        }

                    }

                    conn.Close(); // Close SQL Connection

                }

                txbLocation.Text = location;
                txbDescr.Text = descr;
                cbStatus.Text = status;

            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("117", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[LocationManager]", "[GetLocation]", $"FAILED: Code 117 (  {ex.Message}  )");
            }
        }

        // Clear Fields --------------------------------------------------------------------------------------------------------------------------------
        private void ClearFields()
        {
            txbLocation.Text = "";
            txbDescr.Text = "";
            cbStatus.Text = "";
            cbStatus.SelectedItem = null;
            txbDescr.Enabled = false;
            cbStatus.Enabled = false;
        }

        //=============================================================================================================================================================================================
        //-- Enviroment Events --//
        //=============================================================================================================================================================================================

        // Location Field --------------------------------------------------------------------------------------------------------------------------------
        private void txbLocation_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(txbLocation);
        }

        private void txbLocation_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(txbLocation);
            string carrier = txbLocation.Text;
            if (!string.IsNullOrEmpty(carrier))
            {
                ClearFields();
                txbDescr.Enabled = true;
                cbStatus.Enabled = true;
                GetLocation(carrier);
            }
            else
            {
                ClearFields();
            }
        }

        // Status Field --------------------------------------------------------------------------------------------------------------------------------
        private void cbStatus_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(cbStatus);
        }

        private void cbStatus_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(cbStatus);
        }

        // Description Field --------------------------------------------------------------------------------------------------------------------------------
        private void txbDescr_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(txbDescr);
        }

        private void txbDescr_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(txbDescr);
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

        // Clear Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnClear);
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnClear);
        }

        // Save Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnSave);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnSave);
        }

        //=============================================================================================================================================================================================
        //-- Button Click Events --//
        //=============================================================================================================================================================================================

        // Close Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[LocationManager]", "[FormClose]", "Form Closed");
            this.Close();
        }

        // Save Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            string location = txbLocation.Text;
            string descr = txbDescr.Text;
            string status = "";

            if (cbStatus.SelectedItem != null)
            {
                status = cbStatus.SelectedItem.ToString();
            }

            if (string.IsNullOrEmpty(location))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("224", $"");
                return;
            }
            else if (string.IsNullOrEmpty(descr))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("219", $"");
                return;
            }
            else if (string.IsNullOrEmpty(status))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("221", $"");
                return;
            }
            else
            {
                SaveLocation(location, descr, status);
            }
        }

        // Clear Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            txbLocation.Focus();
        }

        //=============================================================================================================================================================================================
        //-- Key Down Events --//
        //=============================================================================================================================================================================================

        private void LocationManagement_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                btnClear_Click(sender, e);
            }

            // ctrl + S
            if (e.Control && e.KeyCode == Keys.S)
            {
                btnSave_Click(sender, e);
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, e);
            }
        }
    }
}
