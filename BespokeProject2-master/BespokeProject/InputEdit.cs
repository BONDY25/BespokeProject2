using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace BespokeProject_2
{
    public partial class InputEdit : Form
    {
        //=============================================================================================================================================================================================
        //-- Initialization --//
        //=============================================================================================================================================================================================

        private const string connectionString = SessionMaintenance.connectionString;
        public string userName { get; set; }

        public string sessionId { get; set; }

        public bool misInject = false;
        private bool isRed = true;

        public int formMode = 1; // 1 = Input Mode, 0 = Edit Mode.

        // Constants for messages and other settings
        private static class InstructionMessages
        {
            public const string ChooseLocation = "PLEASE CHOOSE A LOCATION!";
            public const string EnterConsignment = "PLEASE ENTER A CONSIGNMENT NUMBER!";
            public const string EnterLicensePlate = "PLEASE ENTER A LICENSE PLATE NUMBER!";
            public const string LicensePlateNotOpen = "License plate {0} is not currently open.";
            public const string MismatchConsignment = "THE CONSIGNMENT DOES NOT MATCH THE CARRIER FOR THE LICENSE PLATE";
            public const string MisInjection = "POTENTIAL MIS-INJECTION!!! A SHIPMENT MAY HAVE BEEN SCANNED INTO THE INCORRECT LICENSE PLATE, PLEASE DELETE THE INCORRECT SHIPMENT!";
        }

        public InputEdit()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        // Form Load --------------------------------------------------------------------------------------------------------------------------------
        private void InputEdit_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[InputEdit]", "[FormLoad]", "Form Started", lblStatus);
            Text = $"{Environment.UserName.ToUpper()} - Bespoke Project II Input";
            PopulateComboBox();
            GetResults();
            PopulateDataGrid();
            rbtnInput.Checked = true;
            UpdateInstructions(0);
            msMain.BackColor = Color.Black;
            msMain.ForeColor = Color.White;
            cntMain.BackColor = Color.White;
        }

        // Form Close --------------------------------------------------------------------------------------------------------------------------------
        private void InputEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionMaintenance.LogBook("", "[InputEdit]", "[FormClosing]", "Form Closed", lblStatus);
        }


        // Populate Drop Down Menus --------------------------------------------------------------------------------------------------------------------------------
        public void PopulateComboBox()
        {
            string query = "SELECT [Description] FROM BespokeProject_LP_Locations WHERE [Active] = 1 ORDER BY [ID]";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cbLocation.Items.Clear();

                            while (reader.Read())
                            {
                                cbLocation.Items.Add(reader["Description"].ToString());
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
                SessionMaintenance.LogBook($"ERROR", "[InputEdit]", "[PopulateComboBox]", $"FAILED (  {ex.Message}  )", lblStatus);
                Application.Exit();
            }
        }

        //=============================================================================================================================================================================================
        //-- Operation Methods --//
        //=============================================================================================================================================================================================

        // Update Form Mode --------------------------------------------------------------------------------------------------------------------------------
        private void UpdateMode()
        {
            misInject = false;
            if (rbtnInput.Checked && !rbtnEdit.Checked)
            {
                SetInputMode();
                SessionMaintenance.LogBook("", "[InputEdit]", "[UpdateMode]", "Mode Changed: Input", lblStatus);
            }
            else if (rbtnEdit.Checked && !rbtnInput.Checked)
            {
                SetEditMode();
                SessionMaintenance.LogBook("", "[InputEdit]", "[UpdateMode]", "Mode Changed: Edit", lblStatus);
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("215", $"");
                SessionMaintenance.LogBook($"ERROR", "[InputEdit]", "[UpdateMode]", $"An Error occured Updating Form Mode", lblStatus);
            }

        }

        // Set Edit Mode --------------------------------------------------------------------------------------------------------------------------------
        private void SetEditMode()
        {
            txbConsign.Text = "";
            txbConsign.Enabled = false;
            txbConsign.BackColor = Color.DarkGray;

            txbPlate.Text = "";
            txbPlate.Enabled = false;
            txbPlate.BackColor = Color.DarkGray;

            cbLocation.Text = "";
            cbLocation.Enabled = false;
            cbLocation.BackColor = Color.White;


            btnFun.Text = "Delete";
            if (CheckMisInject() > 0)
            {
                btnMisInject.Visible = true;
            }
            else
            {
                btnMisInject.Visible = false;
            }

            formMode = 0; // Set Form to Edit mode

            Text = $"{Environment.UserName.ToUpper()} - Bespoke Project II Edit Mode";

            SessionMaintenance.LogBook("", "[InputEdit]", "[SetEditMode]", "Edit Mode Set", lblStatus);

        }

        // Set Input Mode --------------------------------------------------------------------------------------------------------------------------------
        private void SetInputMode()
        {
            txbConsign.Text = "";
            txbConsign.Enabled = true;
            txbConsign.BackColor = Color.White;

            txbPlate.Text = "";
            txbPlate.Enabled = true;
            txbPlate.BackColor = Color.White;

            cbLocation.Text = "";
            cbLocation.Enabled = true;
            cbLocation.BackColor = Color.White;

            btnFun.Text = "Insert";
            btnMisInject.Visible = false;

            formMode = 1; // Set Form to Input mode

            Text = $"{Environment.UserName.ToUpper()} - Bespoke Project II Input Mode";

            SessionMaintenance.LogBook("", "[InputEdit]", "[SetInputMode]", "Input Mode Set", lblStatus);

        }

        // Insert Details --------------------------------------------------------------------------------------------------------------------------------
        private void InsertDetails(string consignment, string licensePlate, string location)
        {
            string query = "EXECUTE [BespokeProject_LP_Insert_Details] @License_Plate, @Consignment, @Location, @User, @Session_Id";

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
                        cmd.Parameters.AddWithValue("@Consignment", consignment);
                        cmd.Parameters.AddWithValue("@Location", location);
                        cmd.Parameters.AddWithValue("@User", userName);
                        cmd.Parameters.AddWithValue("@Session_Id", sessionId);

                        // Execute Query
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close(); // Close SQL Connection

                }

                SessionMaintenance.LogBook("", "[InputEdit]", "[InsertDetails]", $"Record Inserted: {consignment},{licensePlate},{userName}", lblStatus);

            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("120", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[InputEdit]", "[InsertDetails]", $"FAILED (  {ex.Message}  )", lblStatus);

            }

        }
        // Check License Plate  Carrier Prefix --------------------------------------------------------------------------------------------------------------------------------
        private bool CheckPlateCarr(string licensePlate)
        {
            bool plate = false;

            if (licensePlate.Length < 4)
            {
                return false;
            }

            string prefix = licensePlate.Substring(0, 4);
            int result = 0;

            string query = "SELECT COUNT(*) as Result FROM BespokeProject_LP_Carriers WHERE RTRIM(Prefix) + '-' = @Prefix";

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
                                result = (int)reader["Result"];
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
                messageBox.ShowDefError("214", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[InputEdit]", "[CheckPlateCarr]", $"FAILED (  {ex.Message}  )", lblStatus);
            }

            // Determine if the plate is valid based on the SQL result
            plate = result == 1;

            return plate;
        }

        // Check License Plate Status --------------------------------------------------------------------------------------------------------------------------------
        private bool CheckPlateStatus(string licensePlate)
        {
            bool plate = false;
            int result = 0;

            string query = "SELECT COUNT(*) as Result FROM BespokeProject_LP_Headers WHERE License_Plate = @License_Plate AND Status IN (200, 220)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@License_Plate", licensePlate);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = (int)reader["Result"];
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
                messageBox.ShowDefError("213", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[InputEdit]", "[CheckPlateStatus]", $"FAILED (  {ex.Message}  )", lblStatus);
            }

            // Determine if the plate is valid based on the SQL result
            plate = result == 1;

            return plate;
        }

        // Check Consignment --------------------------------------------------------------------------------------------------------------------------------
        private bool CheckConsign(string consign, string carrier)
        {
            var regexPatterns = new Dictionary<string, string>
            {
                { "RMT", @"^[A-Z]{2}\d{9}GB$" },    // Royal Mail starts with 2 letters, ends with 'GB' and has 9 digits in the middle
                { "DPD", @"^%.*1550.*$" },          // DPD: Starts with '%' & contains '1550'
                { "PRO", @"^[A-Z]{2}\d{11}$" }        // Pro Carrier: Starts with 2 letters, followed by 11 digits
            };

            bool isMatch = false;
            string format = "";

            if (regexPatterns.TryGetValue(carrier, out format))
            {
                isMatch = Regex.IsMatch(consign, format);
            }
            else
            {
                isMatch = true; // Default for unknown carriers
            }

            SessionMaintenance.LogBook($"", "[InputEdit]", "[CheckConsign]", $"Checking {consign} matches format {format} for carrier {carrier}", lblStatus);

            return isMatch;
        }


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
                        cmd.Parameters.AddWithValue("@Mode", "1");
                        cmd.Parameters.AddWithValue("@Session_Id", sessionId);
                        cmd.Parameters.AddWithValue("@Search", "");
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
            // Catch Errors
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("115", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[InputEdit]", "[GetResults]", $"FAILED (  {ex.Message}  )", lblStatus);
            }
        }

        // Populate History Table --------------------------------------------------------------------------------------------------------------------------------
        private void PopulateDataGrid()
        {
            string query = "SELECT License_Plate, Consignment, DT_Created FROM BespokeProject_LP_Input_Results WHERE Session_Id = @Session_Id ORDER BY DT_Created DESC";

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

                SessionMaintenance.LogBook("", "[InputEdit]", "[PopulateDataGrid]", $"DataGrid Populated", lblStatus);
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("117", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[InputEdit]", "[PopulateDataGrid]", $"FAILED (  {ex.Message}  )", lblStatus);
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
                SessionMaintenance.LogBook($"ERROR", "[InputEdit]", "[ClearResults]", $"FAILED (  {ex.Message}  )", lblStatus);
            }
        }

        // Insert Function --------------------------------------------------------------------------------------------------------------------------------
        private void DeleteDetails(string licensePlate, string consignment)
        {
            string query = "EXECUTE [BespokeProject_LP_Delete_Details] @License_Plate, @Consignment, @User";

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
                        cmd.Parameters.AddWithValue("@Consignment", consignment);
                        cmd.Parameters.AddWithValue("@User", userName);

                        // Execute Query
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close(); // Close SQL Connection

                }

                SessionMaintenance.LogBook("", "[InputEdit]", "[DeleteDetails]", $"Record Deleted: {consignment},{licensePlate},{userName}", lblStatus);
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("211", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[InputEdit]", "[DeleteDetails]", $"FAILED (  {ex.Message}  )", lblStatus);
            }
        }

        // Insert Function --------------------------------------------------------------------------------------------------------------------------------
        private void InsertFunction()
        {
            string consignment = txbConsign.Text;
            string licensePlate = txbPlate.Text;
            string location = "";
            string carrier = "";
            if (cbLocation.SelectedItem != null)
            {
                location = cbLocation.SelectedItem.ToString();
            }

            if (string.IsNullOrEmpty(licensePlate))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("210", $"");
                SessionMaintenance.LogBook("", "[InputEdit]", "[InsertFunction]", "Error Triggered: 210", lblStatus);
                UpdateInstructions(3);
                return;
            }
            else
            {
                carrier = licensePlate.Substring(0, 3);
            }

            if (!CheckConsign(consignment, carrier))
            {
                misInject = true;
                UpdateInstructions(0);
            }

            if (string.IsNullOrEmpty(location))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("208", $"");
                SessionMaintenance.LogBook("", "[InputEdit]", "[InsertFunction]", "Error Triggered: 208", lblStatus);
                UpdateInstructions(1);
                return;
            }
            else if (string.IsNullOrEmpty(consignment))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("209", $"");
                SessionMaintenance.LogBook("", "[InputEdit]", "[InsertFunction]", "Error Triggered: 209", lblStatus);
                UpdateInstructions(2);
                return;
            }
            else
            {
                if (!CheckPlateStatus(licensePlate))
                {
                    if (CheckPlateCarr(licensePlate))
                    {
                        InsertDetails(consignment, licensePlate, location);
                        GetResults();
                        PopulateDataGrid();
                        txbPlate.Text = "";
                        txbConsign.Text = "";
                        txbConsign.Focus();
                    }
                    else
                    {
                        CustomMessageBox messageBox = new CustomMessageBox();
                        messageBox.ShowDefError("206", $"");
                        SessionMaintenance.LogBook("", "[InputEdit]", "[InsertFunction]", "Error Triggered: 206", lblStatus);
                        txbPlate.Focus();
                        txbPlate.SelectAll();
                        return;
                    }
                }
                else
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowDefError("207", $"");
                    SessionMaintenance.LogBook("", "[InputEdit]", "[InsertFunction]", "Error Triggered: 207", lblStatus);
                    txbPlate.Focus();
                    txbPlate.SelectAll();
                    UpdateInstructions(4);
                    return;
                }
            }
        }

        // Delete Function --------------------------------------------------------------------------------------------------------------------------------
        private void DeleteFunction()
        {
            if (dgHistory.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgHistory.SelectedRows[0];

                string licensePlate = selectedRow.Cells[0].Value.ToString();
                string consignment = selectedRow.Cells[1].Value.ToString();

                CustomMessageBox messageBox = new CustomMessageBox();
                bool result = messageBox.ShowRUSure();
                if (result == true)
                {
                    DeleteDetails(licensePlate, consignment);

                    messageBox.ShowWarning($"Record Deleted! \n{licensePlate} - {consignment}");

                    GetResults();
                    PopulateDataGrid();
                }
                else
                {
                    return;
                }
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("205", $"");
                SessionMaintenance.LogBook("", "[InputEdit]", "[InsertFunction]", "Error Triggered: 205", lblStatus);
                return;
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
                SessionMaintenance.LogBook($"ERROR", "[InputEdit]", "[GetColour]", $"FAILED (  {ex.Message}  )", lblStatus);
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

        // Update Instructions Label 1/7 --------------------------------------------------------------------------------------------------------------------------------
        private void UpdateLabel(string text, Color color, Image image)
        {
            lblInstructions.Text = text;
            lblInstructions.ForeColor = color;
            pbLogo.Image = image;
            lblInstructions.Visible = true;
        }

        // Update Instructions Label 2/7 --------------------------------------------------------------------------------------------------------------------------------
        private void UpdateInstructions(int trigger)
        {
            string location = cbLocation.SelectedItem?.ToString() ?? string.Empty;
            string consignment = txbConsign.Text;
            string licensePlate = txbPlate.Text;

            if (formMode == 1)
            {
                SetDefaultLabelAppearance();

                if (trigger != 0)
                {
                    HandleTriggerCases(trigger, licensePlate);
                }
                else
                {
                    HandleValidationCases(location, consignment, licensePlate);
                }
            }
            else
            {
                ResetLabel();
            }

            if (misInject)
            {
                ShowMisInjectionWarning();
                SessionMaintenance.LogBook($"ERROR", "[InputEdit]", "[UpdateInstructions]", $"***Potential Mis-Injection!***", lblStatus);
            }
        }

        // Update Instructions Label 3/7 --------------------------------------------------------------------------------------------------------------------------------
        private void SetDefaultLabelAppearance()
        {
            lblInstructions.Width = 418;
            lblInstructions.Height = 24;
            lblInstructions.BringToFront();
            timerMain.Stop();
            cntMain.BackColor = Color.White;
            cntMain.BackColor = Color.White;
            lblConsign.BackColor = Color.White;
            lblTitle.BackColor = Color.White;
            lblPlate.BackColor = Color.White;
            lblMode.BackColor = Color.White;
            lblLocation.BackColor = Color.White;
            rbtnEdit.BackColor = Color.White;
            rbtnInput.BackColor = Color.White;
            lblStatus.BackColor = Color.White;
            lblInstructions.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
        }

        // Update Instructions Label 4/7 --------------------------------------------------------------------------------------------------------------------------------
        private void HandleTriggerCases(int trigger, string licensePlate)
        {
            switch (trigger)
            {
                case 1:
                    UpdateLabel(InstructionMessages.ChooseLocation, Color.Red, BespokeProject_2.Properties.Resources.BespokeProject_2_Logo_Speech_Angry);
                    break;
                case 2:
                    UpdateLabel(InstructionMessages.EnterConsignment, Color.Red, BespokeProject_2.Properties.Resources.BespokeProject_2_Logo_Speech_Angry);
                    break;
                case 3:
                    UpdateLabel(InstructionMessages.EnterLicensePlate, Color.Red, BespokeProject_2.Properties.Resources.BespokeProject_2_Logo_Speech_Angry);
                    break;
                case 4:
                    UpdateLabel(string.Format(InstructionMessages.LicensePlateNotOpen, licensePlate), Color.Yellow, BespokeProject_2.Properties.Resources.BespokeProject_2_Logo_Speech);
                    break;
                case 5:
                    UpdateLabel(InstructionMessages.MismatchConsignment, Color.Red, BespokeProject_2.Properties.Resources.BespokeProject_2_Logo_Speech_Angry);
                    break;
            }
        }

        // Update Instructions Label 5/7 --------------------------------------------------------------------------------------------------------------------------------
        private void HandleValidationCases(string location, string consignment, string licensePlate)
        {
            if (string.IsNullOrEmpty(location))
            {
                UpdateLabel("Please choose a Location.", Color.Yellow, BespokeProject_2.Properties.Resources.BespokeProject_2_Logo_Speech);
            }
            else if (string.IsNullOrEmpty(consignment))
            {
                UpdateLabel("Please enter a consignment number.", Color.Yellow, BespokeProject_2.Properties.Resources.BespokeProject_2_Logo_Speech);
            }
            else if (string.IsNullOrEmpty(licensePlate))
            {
                UpdateLabel("Please enter a License Plate Number.", Color.Yellow, BespokeProject_2.Properties.Resources.BespokeProject_2_Logo_Speech);
            }
            else
            {
                ResetLabel();
            }
        }

        // Update Instructions Label 6/7 --------------------------------------------------------------------------------------------------------------------------------
        private void ShowMisInjectionWarning()
        {
            lblInstructions.Visible = true;
            lblInstructions.Width = 418;
            lblInstructions.Height = 210;
            lblInstructions.Font = new Font("Arial Rounded MT Bold", 20F, FontStyle.Regular, GraphicsUnit.Point);

            // Start the flashing effect
            cntMain.BackColor = Color.Red;
            lblConsign.BackColor = Color.Red;
            lblTitle.BackColor = Color.Red;
            lblPlate.BackColor = Color.Red;
            lblMode.BackColor = Color.Red;
            lblLocation.BackColor = Color.Red;
            rbtnEdit.BackColor = Color.Red;
            rbtnInput.BackColor = Color.Red;
            lblStatus.BackColor = Color.Red;
            isRed = true; // Ensure initial state is red
            timerMain.Start();

            UpdateLabel(InstructionMessages.MisInjection, Color.Red, BespokeProject_2.Properties.Resources.BespokeProject_2_Logo_Speech_Angry);
        }

        // Update Instructions Label 7/7 --------------------------------------------------------------------------------------------------------------------------------
        private void ResetLabel()
        {
            lblInstructions.Visible = false;
            timerMain.Stop();
            cntMain.BackColor = Color.White;
            lblConsign.BackColor = Color.White;
            lblTitle.BackColor = Color.White;
            lblPlate.BackColor = Color.White;
            lblMode.BackColor = Color.White;
            lblLocation.BackColor = Color.White;
            rbtnEdit.BackColor = Color.White;
            rbtnInput.BackColor = Color.White;
            lblStatus.BackColor = Color.White;
            pbLogo.Image = BespokeProject_2.Properties.Resources.BespokeProject_2_Logo;
        }

        // Timer Tick --------------------------------------------------------------------------------------------------------------------------------
        private void timerMain_Tick(object sender, EventArgs e)
        {
            Color newColor = isRed ? Color.White : Color.Red;

            cntMain.BackColor = newColor;
            lblConsign.BackColor = newColor;
            lblTitle.BackColor = newColor;
            lblPlate.BackColor = newColor;
            lblMode.BackColor = newColor;
            lblLocation.BackColor = newColor;
            rbtnEdit.BackColor = newColor;
            rbtnInput.BackColor = newColor;
            lblStatus.BackColor = newColor;

            isRed = !isRed; // Toggle the color flag
        }

        // Run Reports -------------------------------------------------------------------------------------------------------------------------
        private void RunReport(string ID)
        {
            string url = "";
            string query = $"SELECT String_1 FROM BespokeProject_Parameters WHERE ID = '{ID}'";

            // Get URL
            try
            {
                // Execute SQL
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
                                url = reader["String_1"].ToString();
                            }
                        }
                    }

                    conn.Close(); // Close SQL Connection

                }
            }
            catch (Exception ex)  // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("119", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[MainForm]", "[RunReport]", $"FAILED (  {ex.Message}  )", lblStatus);
            }

            // Open URL
            try
            {
                // Open the URL in the default web browser
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };

                Process.Start(processStartInfo);

                SessionMaintenance.LogBook($"", "[InputEdit]", "[RunReport]", $"Process Executed with parameter: {ID}", lblStatus);
            }
            catch (Exception ex)  // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("121", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[InputEdit]", "[RunReport]", $"FAILED (  {ex.Message}  )", lblStatus);
            }
        }

        // Check Mis-Injection --------------------------------------------------------------------------------------------------------------------------------
        private int CheckMisInject()
        {
            string query = "SELECT COUNT(*) FROM BespokeProject_LP_MisInject";
            int misInject = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
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
                SessionMaintenance.LogBook($"ERROR", "[InputEdit]", "[CheckMisInject]", $"FAILED: Code 217 (  {ex.Message}  )", lblStatus);
            }

            return misInject;
        }

        //=============================================================================================================================================================================================
        //-- Enviroment Events --//
        //=============================================================================================================================================================================================

        // Radio Buttons Checked --------------------------------------------------------------------------------------------------------------------------------
        private void rbtnEdit_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMode();
            GetResults();
            PopulateDataGrid();
            UpdateInstructions(0);
        }

        private void rbtnInput_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMode();
            GetResults();
            PopulateDataGrid();
            UpdateInstructions(0);
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

        // Function Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnFun_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnFun);
        }

        private void btnFun_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnFun);
        }

        // Mis-Injection Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnMisInject_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnMisInject);
        }

        private void btnMisInject_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnMisInject);
        }

        // Textboxes --------------------------------------------------------------------------------------------------------------------------------
        private void txbConsign_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[InputEdit]", "[txbConsign_Enter]", "Field Entered", lblStatus);
            SessionMaintenance.ControlEnter(txbConsign);
        }

        private void txbConsign_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[InputEdit]", "[txbConsign_Leave]", "Field Left", lblStatus);
            SessionMaintenance.ControlLeave(txbConsign);
            UpdateInstructions(0);
        }

        private void txbPlate_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(txbPlate);
        }

        private void txbPlate_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(txbPlate);
            UpdateInstructions(0);
        }

        // ComboBox --------------------------------------------------------------------------------------------------------------------------------
        private void cbLocation_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(cbLocation);
        }

        private void cbLocation_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(cbLocation);
            UpdateInstructions(0);
        }

        // Radio Buttons --------------------------------------------------------------------------------------------------------------------------------
        private void rbtnInput_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(rbtnInput);
        }

        private void rbtnInput_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(rbtnInput);
        }

        private void rbtnEdit_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(rbtnEdit);
        }

        private void rbtnEdit_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(rbtnEdit);
        }

        // Status Box ---------------------------------------------------------------------------------------------------------------------------------------
        private void lblStatus_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(lblStatus);
        }

        private void lblStatus_MouseLeave(object sender, EventArgs e)
        {
            lblStatus.BackColor = Color.White;
            lblStatus.ForeColor = Color.Silver;
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

        // Bee --------------------------------------------------------------------------------------------------------------------------------
        private void pbLogo_MouseEnter(object sender, EventArgs e)
        {
            pbLogo.Image = BespokeProject_2.Properties.Resources.BespokeProject_2_Logo_Speech_Angry;
            lblInstructions.Visible = true;
            lblInstructions.Text = "DON'T TOUCH ME!";
            lblInstructions.ForeColor = Color.Red;
        }

        private void pbLogo_MouseLeave(object sender, EventArgs e)
        {
            UpdateInstructions(0);
        }

        //=============================================================================================================================================================================================
        //-- Button Click Events --//
        //=============================================================================================================================================================================================

        // Input Button --------------------------------------------------------------------------------------------------------------------------------
        private void rbtnInput_Click(object sender, EventArgs e)
        {
            rbtnInput.Checked = true;
            rbtnEdit.Checked = false;
        }

        // Edit Button --------------------------------------------------------------------------------------------------------------------------------
        private void rbtnEdit_Click(object sender, EventArgs e)
        {
            rbtnInput.Checked = false;
            rbtnEdit.Checked = true;
        }

        // Close Button Click --------------------------------------------------------------------------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            ClearResults("1");
            ClearResults("2");
            ClearResults("3");
            try
            {
                this.Close();
            }
            catch (Exception ex)  // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("Error Closing Module");
                SessionMaintenance.LogBook($"ERROR", "[InputEdit]", "[btnClose_Click]", $"FAILED (  {ex.Message}  )", lblStatus);
                Application.Exit();
            }
        }

        // Function Button Click --------------------------------------------------------------------------------------------------------------------------------
        private void btnFun_Click(object sender, EventArgs e)
        {
            if (formMode == 1)
            {
                InsertFunction();
                txbConsign.Focus();
            }
            else if (formMode == 0)
            {
                DeleteFunction();
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("203", $"");
                SessionMaintenance.LogBook("", "[InputEdit]", "[btnFun_Click]", "Error Triggered: 202", lblStatus);
            }
            txbConsign.Focus();
        }

        // MisInjection Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnMisInject_Click(object sender, EventArgs e)
        {
            MisInject misInject = new MisInject();
            misInject.sessionId = sessionId;
            misInject.userName = userName;
            misInject.Show();
        }

        // Don't Touch the Bee --------------------------------------------------------------------------------------------------------------------------------
        private void pbLogo_Click(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[InputEdit]", "[pbLogo_Click]", "The bee has been touched!", lblStatus);
            CustomMessageBox messageBox = new CustomMessageBox();
            messageBox.ShowDontTouch("DON'T TOUCH ME!");
            lblInstructions.Visible = true;
            lblInstructions.Text = "DON'T TOUCH ME!";
            lblInstructions.ForeColor = Color.Red;
            pbLogo.Image = BespokeProject_2.Properties.Resources.BespokeProject_2_Logo_Speech_Angry;
        }

        // Menu Strip //
        // Edit/Edit Mode --------------------------------------------------------------------------------------------------------------------------------
        private void editModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formMode == 1)
            {
                rbtnEdit.Focus();
                rbtnEdit_Click(sender, e);

            }
            else if (formMode == 0)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("202", $"");
                SessionMaintenance.LogBook("", "[InputEdit]", "[editModeToolStripMenuItem_Click]", "Error Triggered: 202", lblStatus);
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("203", $"");
                SessionMaintenance.LogBook("", "[InputEdit]", "[editModeToolStripMenuItem_Click]", "Error Triggered: 203", lblStatus);
            }
        }

        // Edit/Manifests --------------------------------------------------------------------------------------------------------------------------------
        private void manifestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manifest manifestForm = new Manifest();
            manifestForm.sessionId = sessionId;
            manifestForm.userName = userName;
            manifestForm.licesnePlate = "";
            manifestForm.Show();
        }

        // Edit/Carrier Management --------------------------------------------------------------------------------------------------------------------------------
        private void carrierManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarrierManagement carrierManagementForm = new CarrierManagement();
            carrierManagementForm.sessionId = sessionId;
            carrierManagementForm.userName = userName;
            carrierManagementForm.Show();
        }

        // Edit/Location Management --------------------------------------------------------------------------------------------------------------------------------
        private void locationManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocationManager locationManager = new LocationManager(this);
            locationManager.sessionId = sessionId;
            locationManager.userName = userName;
            locationManager.Show();
        }

        // File/Close --------------------------------------------------------------------------------------------------------------------------------
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnClose_Click(sender, e);
        }

        // File/Search/Open License Plates --------------------------------------------------------------------------------------------------------------------------------
        private void openLicensePlatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPlate openPlate = new OpenPlate();
            openPlate.sessionId = sessionId;
            openPlate.userName = userName;
            openPlate.formMode = 0;
            openPlate.Show();
        }

        // File/Search/Consignments --------------------------------------------------------------------------------------------------------------------------------
        private void consignmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search lpSearchForm = new Search();
            lpSearchForm.userName = userName;
            lpSearchForm.sessionId = sessionId;
            lpSearchForm.Show();
        }

        // File/Search/Mis-Injections --------------------------------------------------------------------------------------------------------------------------------
        private void misInjectionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MisInject misInject = new MisInject();
            misInject.sessionId = sessionId;
            misInject.userName = userName;
            misInject.Show();
        }

        // File/Reports/License Plate Generation --------------------------------------------------------------------------------------------------------------------------------
        private void licensePlateGenerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunReport("005");
        }

        // File/Reports/License Plate Detail --------------------------------------------------------------------------------------------------------------------------------
        private void licensePlateDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunReport("006");
        }

        // File/Reports/Mis-Injections --------------------------------------------------------------------------------------------------------------------------------
        private void misInjectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunReport("007");
        }

        // File/Reports/Dashboard --------------------------------------------------------------------------------------------------------------------------------
        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userName == "AIDENB" || userName == "JOSEPH" || userName == "JAMEST")
            {
                DashboardForm dashboardForm = new DashboardForm();
                dashboardForm.Show();
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("You do not have permission to access this form!");
            }
        }

        //=============================================================================================================================================================================================
        //-- Key Down Events --//
        //=============================================================================================================================================================================================

        // Tab Key - License plate field --------------------------------------------------------------------------------------------------------------------------------
        private void txbPlate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (formMode == 1)
            {
                // Check if Tab is pressed without Shift to trigger the insert function
                if (e.KeyCode == Keys.Tab && !ModifierKeys.HasFlag(Keys.Shift))
                {
                    btnFun_Click(sender, e);  // Call the Insert function
                    e.IsInputKey = true;      // Indicate this is an input key to avoid default tab behavior
                }
            }
        }

        // Override Key Commands ----------------------------------------------------------------------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (txbPlate != null && !txbPlate.IsDisposed)
            {
                // Check if Tab is pressed on txbPlate without Shift, and set focus to txbConsign
                if (keyData == Keys.Tab && txbPlate.Focused && !ModifierKeys.HasFlag(Keys.Shift))
                {
                    txbConsign.Focus();
                    return true; // Prevent default Tab navigation
                }
                // Handle Shift + Tab to allow backward navigation focus to txbConsign from txbPlate
                else if (keyData == (Keys.Tab | Keys.Shift) && txbConsign.Focused)
                {
                    txbPlate.Focus();
                    return true; // Prevent default Shift + Tab navigation
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        // Keyboard Shortcuts --------------------------------------------------------------------------------------------------------------------------------
        private void InputEdit_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                if (formMode == 1)
                {
                    txbPlate.Text = "";
                    txbConsign.Text = "";
                    txbConsign.Focus();
                }
            }

            // ctrl + M
            if (e.Control && e.KeyCode == Keys.M)
            {
                manifestsToolStripMenuItem_Click(sender, e);
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, e);
            }
        }


    }
}
