using Microsoft.Data.SqlClient;

namespace BespokeProject_2
{
    public partial class CarrierManagement : Form
    {
        //=============================================================================================================================================================================================
        //-- Initialization --//
        //=============================================================================================================================================================================================

        private const string connectionString = SessionMaintenance.connectionString;
        public string userName { get; set; }

        public string sessionId { get; set; }

        public CarrierManagement()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        // Form Load --------------------------------------------------------------------------------------------------------------------------------
        private void CarrierManagement_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[CarrierManager]", "[FormLoad]", "Form Started");
            Text = $"{Environment.UserName.ToUpper()} - Bespoke Project II Carrier Manager";
            PopulateComboBox(cbColour, 1);
            PopulateComboBox(cbStatus, 2);
            txbCarrier.Focus();
            UpdateColour("");
            txbDescr.Enabled = false;
            txbPrefix.Enabled = false;
            cbStatus.Enabled = false;
            cbColour.Enabled = false;
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
                SessionMaintenance.LogBook($"ERROR", "[CarrierManager]", "[PopulateComboBox]", $"FAILED: Code 122 (  {ex.Message}  )");
                Application.Exit();
            }
        }

        //=============================================================================================================================================================================================
        //-- Operation Methods --//
        //=============================================================================================================================================================================================

        // Save Carrier --------------------------------------------------------------------------------------------------------------------------------
        private void SaveCarrier(string carrier, string descr, string prefix, string colour, string active)
        {
            string query = "EXECUTE [BespokeProject_LP_Update_Carriers] @Carrier, @Description, @Prefix, @Colour, @Active, @User";

            try
            {
                // Start SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@Carrier", carrier);
                        cmd.Parameters.AddWithValue("@Description", descr);
                        cmd.Parameters.AddWithValue("@Prefix", prefix);
                        cmd.Parameters.AddWithValue("@Colour", colour);
                        cmd.Parameters.AddWithValue("@Active", active);
                        cmd.Parameters.AddWithValue("@User", userName);

                        // Execute Query
                        cmd.ExecuteNonQuery();

                    }

                    conn.Close(); // Close SQL Connection
                }

                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowInfo($"Carrier {carrier} Updated");
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("223", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[CarrierManager]", "[SaveCarrier]", $"FAILED: Code 223 (  {ex.Message}  )");
            }

        }

        // Get Carrier --------------------------------------------------------------------------------------------------------------------------------
        private void GetCarrier(string carrier)
        {

            string query = "EXECUTE [BespokeProject_LP_Get_Carrier] @Carrier";
            string descr = "";
            string prefix = "";
            string status = "";
            string colour = "";

            try
            {
                // Start SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@Carrier", carrier);


                        // Execute Data Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Populate variables from reader
                            while (reader.Read())
                            {
                                descr = reader["Description"].ToString();
                                prefix = reader["Prefix"].ToString();
                                colour = reader["Colour"].ToString();
                                status = reader["Status"].ToString();
                            }
                        }

                    }

                    conn.Close(); // Close SQL Connection

                }

                txbCarrier.Text = carrier;
                txbDescr.Text = descr;
                txbPrefix.Text = prefix;
                cbColour.Text = colour;
                cbStatus.Text = status;

                UpdateColour(colour);

            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("117", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[CarrierManager]", "[GetCarrier]", $"FAILED: Code 117 (  {ex.Message}  )");
            }
        }

        // Update Colour --------------------------------------------------------------------------------------------------------------------------------
        private void UpdateColour(string colorstring)
        {
            Color color = Color.White;

            switch (colorstring)
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
                default: color = Color.White; break;
            }

            lblColor.BackColor = color;
        }

        // Clear Fields --------------------------------------------------------------------------------------------------------------------------------
        private void ClearFields()
        {
            txbCarrier.Text = "";
            txbDescr.Text = "";
            txbPrefix.Text = "";
            cbColour.Text = "";
            cbStatus.Text = "";
            cbColour.SelectedItem = null;
            cbStatus.SelectedItem = null;
            txbDescr.Enabled = false;
            txbPrefix.Enabled = false;
            cbStatus.Enabled = false;
            cbColour.Enabled = false;
            UpdateColour("");

        }

        //=============================================================================================================================================================================================
        //-- Enviroment Events --//
        //=============================================================================================================================================================================================

        // Carrier Field --------------------------------------------------------------------------------------------------------------------------------
        private void txbCarrier_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(txbCarrier);
        }

        private void txbCarrier_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(txbCarrier);
            string carrier = txbCarrier.Text;
            if (!string.IsNullOrEmpty(carrier))
            {
                ClearFields();
                txbDescr.Enabled = true;
                txbPrefix.Enabled = true;
                cbStatus.Enabled = true;
                cbColour.Enabled = true;

                GetCarrier(carrier);
            }
            else
            {
                ClearFields();
            }

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

        // Prefix Field --------------------------------------------------------------------------------------------------------------------------------
        private void txbPrefix_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(txbPrefix);
        }

        private void txbPrefix_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(txbPrefix);
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

        // Colour Field --------------------------------------------------------------------------------------------------------------------------------
        private void cbColour_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(cbColour);
        }

        private void cbColour_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(cbColour);
        }

        private void cbColour_TextChanged(object sender, EventArgs e)
        {
            string color = "";

            if (cbColour.SelectedItem != null)
            {
                color = cbColour.SelectedItem.ToString();
            }

            UpdateColour(color);
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
            SessionMaintenance.LogBook("", "[CarrierManager]", "[FormClose]", "Form Closed");
            this.Close();
        }

        // Save Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            string carrier = txbCarrier.Text;
            string descr = txbDescr.Text;
            string prefix = txbPrefix.Text;
            string status = "";
            string colour = "";

            if (cbStatus.SelectedItem != null)
            {
                status = cbStatus.SelectedItem.ToString();
            }
            if (cbColour.SelectedItem != null)
            {
                colour = cbColour.SelectedItem.ToString();
            }

            if (string.IsNullOrEmpty(carrier))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("218", $"");
                return;
            }
            else if (string.IsNullOrEmpty(descr))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("219", $"");
                return;
            }
            else if (string.IsNullOrEmpty(prefix))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("220", $"");
                return;
            }
            else if (string.IsNullOrEmpty(status))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("221", $"");
                return;
            }
            else if (string.IsNullOrEmpty(colour))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("222", $"");
                return;
            }
            else
            {
                SaveCarrier(carrier, descr, prefix, colour, status);
            }
        }

        // Clear Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            txbCarrier.Focus();
        }

        //=============================================================================================================================================================================================
        //-- Key Down Events --//
        //=============================================================================================================================================================================================

        private void CarrierManagement_KeyDown(object sender, KeyEventArgs e)
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
