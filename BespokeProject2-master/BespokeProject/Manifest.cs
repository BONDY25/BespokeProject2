using Microsoft.Data.SqlClient;
using System.Data;

namespace BespokeProject_2
{
    public partial class Manifest : Form
    {
        //=============================================================================================================================================================================================
        //-- Initialization --//
        //=============================================================================================================================================================================================

        private const string connectionString = SessionMaintenance.connectionString;
        public string userName { get; set; }
        public string sessionId { get; set; }
        public string licesnePlate { get; set; }
        public string plateStatus = "";

        public Manifest()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void Manifest_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[ManifestForm]", "[FormLoad]", "Form Started");
            Text = $"{Environment.UserName.ToUpper()} - Bespoke Project II Manifest";
            txbPlate.Text = licesnePlate;
            lblLocation.Visible = false;
            lblTotal.Visible = false;
            lblStatus.Visible = false;
            btnCancel.Visible = false;
            btnComplete.Visible = false;
            if (!string.IsNullOrEmpty(licesnePlate))
            {
                GetPlate(licesnePlate);
            }
        }

        private void Manifest_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionMaintenance.LogBook("", "[ManifestForm]", "[FormClosing]", "Form Closed");
        }

        //=============================================================================================================================================================================================
        //-- Operation Methods --//
        //=============================================================================================================================================================================================

        // Get Results --------------------------------------------------------------------------------------------------------------------------------
        private void GetResults()
        {
            string query = "EXECUTE [BespokeProject_LP_Get_Details] @Mode, @Session_Id, @Search";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Mode", "3");
                        cmd.Parameters.AddWithValue("@Session_Id", sessionId);
                        cmd.Parameters.AddWithValue("@Search", licesnePlate);
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
            // Catch Errors
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("117", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[ManifestForm]", "[GetResults]", $"FAILED: Code 117 (  {ex.Message}  )");
            }
        }

        // Populate History Table --------------------------------------------------------------------------------------------------------------------------------
        private void PopulateDataGrid()
        {
            string query = "SELECT Consignment, DT_Created FROM BespokeProject_LP_Man_Results WHERE Session_Id = @Session_Id ORDER BY DT_Created DESC";

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

                SessionMaintenance.LogBook("", "[ManifestForm]", "[PopulateDataGrid]", $"DataGrid Populated");
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("117", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[ManifestForm]", "[PopulateDataGrid]", $"FAILED: Code 177 (  {ex.Message}  )");
            }
        }

        // Clear Results Tables --------------------------------------------------------------------------------------------------------------------------------
        private void ClearResults(string mode)
        {
            string query = "";
            switch (mode)
            {
                case "1": query = "DELETE BespokeProject_LP_Input_Results WHERE Session_Id = @Session_Id"; break;
                case "2": query = "DELETE BespokeProject_LP_Search_Results WHERE Session_Id = @Session_Id"; break;
                case "3": query = "DELETE BespokeProject_LP_Man_Results WHERE Session_Id = @Session_Id"; break;
            }

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

                    }

                    conn.Close(); // Close SQL Connection
                }
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("212", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[ManifestForm]", "[ClearResults]", $"FAILED: Code 212 (  {ex.Message}  )");
            }
        }

        // Get Color --------------------------------------------------------------------------------------------------------------------------------
        private Color GetColour(string prefix)
        {
            string query = "SELECT Pram_1 FROM BespokeProject_LP_Carriers WHERE Prefix = @Prefix";
            string colorString = "";
            Color color = Color.White;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Prefix", prefix);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                colorString = reader["Pram_1"].ToString();
                            }
                        }

                    }
                    conn.Close();
                }
            }
            // Catch Errors
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("204", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[ManifestForm]", "[GetColour]", $"FAILED: Code 204 (  {ex.Message}  )");
            }

            switch (colorString)
            {
                case "Red": color = Color.Red; break;
                case "AliceBlue": color = Color.AliceBlue; break;
                case "Gold": color = Color.Gold; break;
                case "DeepSkyBlue": color = Color.DeepSkyBlue; break;
                case "LimeGreen": color = Color.LimeGreen; break;
                case "Orange": color = Color.Orange; break;
                case "Yellow": color = Color.Yellow; break;
                case "Turquoise": color = Color.Turquoise; break;
                case "Cyan": color = Color.Cyan; break;
                case "Violet": color = Color.Violet; break;
                case "HotPink": color = Color.HotPink; break;
                case "DarkGray": color = Color.DarkGray; break;
            }

            return color;
        }

        // Get Totals --------------------------------------------------------------------------------------------------------------------------------
        private void GetTotals(string licensePlate)
        {
            string Total = "";
            string status = "";
            string location = "";
            string query = "EXECUTE [BespokeProject_LP_Get_Totals] @License_Plate";


            try
            {
                // Start SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@License_Plate", licensePlate);


                        // Execute Data Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Populate variables from reader
                            while (reader.Read())
                            {
                                status = reader["Status"].ToString();
                                location = reader["Location"].ToString();
                                Total = reader["Totals"].ToString();
                            }
                        }

                    }

                    conn.Close(); // Close SQL Connection

                }

                plateStatus = status;

                // Update UI Elements
                lblStatus.Text = $"Status: {status}";
                lblLocation.Text = $"Location: {location}";
                lblTotal.Text = $"Total Consignments: {Total}";

                lblLocation.Visible = true;
                lblTotal.Visible = true;
                lblStatus.Visible = true;

            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("117", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[ManifestForm]", "[GetTotals]", $"FAILED: Code 117 (  {ex.Message}  )");
            }

        }

        // Check License Plate --------------------------------------------------------------------------------------------------------------------------------
        private bool CheckPlate(string licensePlate)
        {
            bool plate = false;
            string query = "SELECT COUNT(*) FROM BespokeProject_LP_Headers WHERE status = 30 AND License_Plate = @License_Plate";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@License_Plate", licensePlate);
                        int count = (int)cmd.ExecuteScalar();

                        if (count >= 1)
                        {
                            plate = true;
                        }
                    }
                    conn.Close();
                }
            }
            // Catch Errors
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("217", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[ManifestForm]", "[CheckPlate]", $"FAILED: Code 217 (  {ex.Message}  )");
            }

            return plate;
        }

        // Get License Plate --------------------------------------------------------------------------------------------------------------------------------
        private void GetPlate(string licesnePlate)
        {
            GetResults();
            PopulateDataGrid();
            GetTotals(licesnePlate);

            string btnText = "";

            switch (plateStatus)
            {
                case "Open": btnText = "Complete"; btnComplete.Visible = true; btnCancel.Visible = false; break;
                case "Complete": btnText = "Reopen"; btnComplete.Visible = true; btnCancel.Visible = false; break;
                case "Cancelled": btnText = "Disabled"; btnComplete.Visible = false; btnCancel.Visible = false; break;
            }

            btnComplete.Text = btnText;
        }


        // Complete Manifest --------------------------------------------------------------------------------------------------------------------------------
        private void UpdateManifest(string licensePlate, string status)
        {
            string query = "EXECUTE [BespokeProject_LP_Complete_Man] @License_Plate, @User, @Update";

            try
            {
                // Start SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@License_Plate", licensePlate);
                        cmd.Parameters.AddWithValue("@User", userName);
                        cmd.Parameters.AddWithValue("@Update", status);

                        // Execute Query
                        cmd.ExecuteNonQuery();

                    }

                    conn.Close(); // Close SQL Connection
                }

                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowInfo($"License plate Updated");
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("116", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[ManifestForm]", "[UpdateManifest]", $"FAILED: Code 116 (  {ex.Message}  )");
            }

        }

        // Check Mis-Injection --------------------------------------------------------------------------------------------------------------------------------
        private int CheckMisInject(string licensePlate)
        {
            string query = "SELECT COUNT(*) FROM BespokeProject_LP_MisInject WHERE License_Plate = @License_Plate";
            int misInject = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@License_Plate", licensePlate);
                        int count = (int)cmd.ExecuteScalar();

                        misInject = count;

                    }
                    conn.Close();
                }
            }
            // Catch Errors
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("217", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[ManifestForm]", "[CheckMisInject]", $"FAILED: Code 217 (  {ex.Message}  )");
            }

            return misInject;
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

        // Clear Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnClear);
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnClear);
        }

        // Complete Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnComplete_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnComplete);
        }

        private void btnComplete_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnComplete);
        }

        // Cancel Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnCancel);
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnCancel);
        }

        // Open Plate Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnOpenPlate_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnOpenPlate);
        }

        private void btnOpenPlate_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnOpenPlate);
        }

        // License Plate Field --------------------------------------------------------------------------------------------------------------------------------
        private void txbPlate_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(txbPlate);
        }
        private void txbPlate_Leave(object sender, EventArgs e)
        {
            licesnePlate = txbPlate.Text;
            if (!string.IsNullOrEmpty(licesnePlate))
            {
                txbPlate.BackColor = GetColour(licesnePlate.Substring(0, 3));
                GetPlate(licesnePlate);
            }
            else
            {
                SessionMaintenance.ControlLeave(txbPlate);
            }
        }


        // Cell Formatting --------------------------------------------------------------------------------------------------------------------------------
        private void dgHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if we are in the first column
            if (e.ColumnIndex == 0 && e.Value != null)
            {
                // Get the cell value in the first column as a string
                string licensePlate = e.Value.ToString();

                // Extract the first three letters as the prefix
                string prefix = licensePlate.Length >= 3 ? licensePlate.Substring(0, 3) : licensePlate;

                // Get the color from the database using the prefix
                Color rowColor = GetColour(prefix);

                // Set the row color
                dgHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor = rowColor;
            }
        }

        //=============================================================================================================================================================================================
        //-- Button Click Events --//
        //=============================================================================================================================================================================================


        // Close Button Click --------------------------------------------------------------------------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            ClearResults("3");
            try
            {
                this.Close();
            }
            catch (Exception ex)  // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("Error Closing Module");
                SessionMaintenance.LogBook($"ERROR", "[ManifestForm]", "[btnClose_Click]", $"FAILED (  {ex.Message}  )");
                Application.Exit();
            }
        }

        // Clear Button Click --------------------------------------------------------------------------------------------------------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearResults("3");
            txbPlate.Text = "";
            dgHistory.DataSource = null;
            dgHistory.Refresh();
            plateStatus = "";
            lblLocation.Text = "";
            lblTotal.Text = "";
            lblStatus.Text = "";
            lblLocation.Visible = false;
            lblTotal.Visible = false;
            lblStatus.Visible = false;
            btnCancel.Visible = false;
            btnComplete.Visible = false;
            txbPlate.Focus();
            txbPlate.BackColor = Color.Yellow;

        }

        // Complete Button Click --------------------------------------------------------------------------------------------------------------------------------
        private void btnComplete_Click(object sender, EventArgs e)
        {
            string licensePlate = txbPlate.Text;

            if (string.IsNullOrEmpty(licensePlate))
            {
                new CustomMessageBox().ShowDefError("210", $"");
                return;
            }

            CustomMessageBox messageBox = new CustomMessageBox();

            // Confirm update
            if (!messageBox.ShowQuestion("Update?", $"Are You sure you want to update {licensePlate}?", "Happy"))
                return;

            int misInjectCount = CheckMisInject(licensePlate);

            // Handle potential mis-injections
            if (misInjectCount >= 1)
            {
                new MisInject
                {
                    sessionId = sessionId,
                    userName = userName
                }.Show();

                if (!messageBox.ShowQuestion("Mis-Injection!", $"{licensePlate} has {misInjectCount} potential mis-injection(s). Are you sure?", "Angry") ||
                    !messageBox.ShowQuestion("Mis-Injection!", $"You are about to update a license plate with potential mis-injection(s). Continue?", "Angry"))
                    return;
            }

            // Update manifest based on plate status
            UpdateManifest(licensePlate, plateStatus == "Open" ? "220" : "30");

            // Fetch updated plate information
            GetPlate(licensePlate);
        }


        // Cancel Button Click --------------------------------------------------------------------------------------------------------------------------------
        private void btnCancel_Click(object sender, EventArgs e)
        {
            string licensePlate = txbPlate.Text;
            if (string.IsNullOrEmpty(licensePlate))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("210", $"");
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                bool result = messageBox.ShowQuestion("Cancel?", $"Are You sure you want to cancel {licensePlate}?", "Happy");
                if (result == true)
                {
                    UpdateManifest(licensePlate, "200");
                }
                else
                {
                    return;
                }
            }
            GetPlate(licensePlate);
        }

        private void btnOpenPlate_Click(object sender, EventArgs e)
        {
            OpenPlate openPlate = new OpenPlate();
            openPlate.sessionId = sessionId;
            openPlate.userName = userName;
            openPlate.formMode = 1;
            openPlate.Show();
            this.Close();
        }

        //=============================================================================================================================================================================================
        //-- Key Down Events --//
        //=============================================================================================================================================================================================

        
        private void Manifest_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                btnClear_Click(sender, e);
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, e);
            }
        }
    }
}
