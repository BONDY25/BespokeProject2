using BespokeProject_2;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace BespokeProject
{
    public partial class MainForm : Form
    {
        //=============================================================================================================================================================================================
        //-- Initialization --//
        //=============================================================================================================================================================================================

        // SQL Server Connection String
        private const string connectionString = SessionMaintenance.connectionString;

        // Pull User Name From Login Form
        public string userName { get; set; }

        public string client { get; set; }

        public string sessionId { get; set; }

        public int currentCount = 0;


        public MainForm()
        {
            InitializeComponent();
            this.KeyDown += MainFrom_KeyDown;
            this.KeyPreview = true;

            this.MaximizeBox = false;

            txbBatchNo.KeyPress += txbBatchNo_KeyPress;
            txbRefNo.KeyPress += txbRefNo_KeyPress;
            txbBoxID.KeyPress += txbBoxID_KeyPress;
            txbBatchNo.KeyDown += txbBatchNo_KeyDown;
            txbRefNo.KeyDown += txbRefNo_KeyDown;
            txbBoxID.KeyDown += txbBoxID_KeyDown;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //CheckLicense();
            LoadUIElements(client);
            lblUserName.Text = userName.ToUpper(); // Display User Name
            lblLastScan.Text = ""; // Clear Last Date
            UserCounter(); // Populate User Counter
            SessionMaintenance.LogBook("", "[MainForm]", "[FormLoad]", "Form Started", lblStatus);
            //CheckForSarah();

            sessionTimer.Start();
        }

        private void CheckForSarah()
        {
            if (Environment.UserName == "SARAH.RUSSELL")
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowInfo($"Oh no... Not you again!");
            }
            else if (Environment.UserName == "PACKINGSTATION54" || userName == "SARAH")
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                bool result = messageBox.ShowQuestion("Really?", $"Did you think just because you log in through the packing station you were safe?", "Happy");
                if (result == true)
                {
                    bool result2 = messageBox.ShowQuestion("Really?", $"Really?", "Happy");
                    while (result2 == true)
                    {
                        result2 = messageBox.ShowQuestion("Really?", $"Really?", "Happy");
                    }

                    // This will execute if the loop ends (result2 becomes false)
                    messageBox.ShowInfo($"That's what I thought!");
                }
                else
                {
                    messageBox.ShowInfo($"Nice try, but maybe you should stay in your lane.");
                }
            }
        }


        // Prevent Special Characters (txbBatchNo)
        private void txbBatchNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"Character: '{e.KeyChar}' Not Accepted Here");
                e.Handled = true;
            }
        }

        // Prevent Special Characters (txbRefNo)
        private void txbRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"Character: '{e.KeyChar}' Not Accepted Here");
                e.Handled = true;
            }
        }

        // Prevent Special Characters (txbBoxID)
        private void txbBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"Character: '{e.KeyChar}' Not Accepted Here");
                e.Handled = true;
            }
        }

        // Override Key Commands
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab && txbRefNo.Focused && !ModifierKeys.HasFlag(Keys.Shift))
            {
                return true; // Prevent the default Tab navigation
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void LoadUIElements(string client)
        {
            lblTitle.Text = $"Home - {client}";
            Text = $"Bespoke Project - Home - {client}";

            string clientID = ClientID();

            if (clientID == "040" || clientID == "054")
            {
                lblBatchNo.Text = "1. Order Number";
                lblBagID.Text = "2. Box ID";
                lblRefNo.Text = "3. Barcode/SKU";
            }
        }

        // Check License
        private void CheckLicense()
        {
            string dateTimeNow = DateTime.Now.ToString("yyyy-MM-dd");

            if (dateTimeNow == "2024-06-01")//2024-06-01
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("Your license has expired! \n Please contact your application administrator. \n The application will now close!");
                Application.Exit();
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
        //-- Operation Methods --//
        //=============================================================================================================================================================================================

        // Get Random Praise Message ----------------------------------------------------------------------------------------------------------
        public string RandomPraise()
        {
            string currentMessage = lblPraise.Text;
            string newMessage = null;
            string newMessageQuery = "[BespokeProject_PraisePhrase] @CurrenMessage";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmdPraise = new SqlCommand(newMessageQuery, conn))
                    {
                        cmdPraise.Parameters.AddWithValue("@CurrenMessage", currentMessage);
                        // Execute Data Reader
                        using (SqlDataReader reader = cmdPraise.ExecuteReader())
                        {
                            // Populate variables from reader
                            while (reader.Read())
                            {
                                newMessage = reader["RandomPraise"].ToString();
                            }
                        }

                    }

                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An Error occured Getting Random Praise: \n {ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[MainForm]", "[RandomPraise]", $"FAILED (  {ex.Message}  )", lblStatus);
            }

            return newMessage;
        }

        // Update Counter For How Many The User Has Scanned ----------------------------------------------------------------------------------------------------------
        public void UserCounter()
        {

            string counterQuery = "SELECT ISNULL(COUNT(ref_no), 0) FROM BespokeProject_Details WHERE Client_ID = @Client_ID AND User_Created = @UserName AND CAST(DT_Created as date) = CAST(GETDATE() as date)";


            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(counterQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client_ID", ClientID());
                        cmd.Parameters.AddWithValue("@UserName", userName);

                        int count = (int)cmd.ExecuteScalar();
                        string countString = count.ToString();

                        if (currentCount >= 100)
                        {
                            lblPraise.Visible = true;
                            lblPraise.Text = RandomPraise();
                            pbLogo.Image = BespokeProject_2.Properties.Resources.BespokeProject_2_Logo_Speech;
                            currentCount = 0;
                        }
                        else if (count <= 99)
                        {
                            lblPraise.Visible = false;
                            pbLogo.Image = BespokeProject_2.Properties.Resources.BespokeProject_2_Logo;
                        }

                        lblCount.Text = $"User Count: {countString}";

                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An Error occured Updating User Counter: \n {ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[MainForm]", "[UserCounter]", $"FAILED (  {ex.Message}  )", lblStatus);
            }

        }

        // Update Counter For How Many Is In The Current Batch ----------------------------------------------------------------------------------------------------------
        public void BatchCounter()
        {
            string batchNo = txbBatchNo.Text;
            string counterQuery = "SELECT ISNULL(COUNT(ref_no), 0) FROM BespokeProject_Details WHERE Client_ID = @Client_ID AND Batch_No = @BatchNo";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();


                    using (SqlCommand cmd = new SqlCommand(counterQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client_ID", ClientID());
                        cmd.Parameters.AddWithValue("@BatchNo", batchNo);

                        int count = (int)cmd.ExecuteScalar();
                        string countString = count.ToString();
                        lblBatchCounter.Text = $"Batch Count: {countString}";

                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An Error occured Updating Batch Counter: \n {ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[MainForm]", "[BatchCounter]", $"FAILED (  {ex.Message}  )", lblStatus);
            }
        }

        // Update Counter For How Many Is In The Current Box ----------------------------------------------------------------------------------------------------------
        public void BoxCounter()
        {
            string boxID = txbBoxID.Text;
            string batchNo = txbBatchNo.Text;
            string counterQuery = "SELECT ISNULL(COUNT(ref_no), 0) FROM BespokeProject_Details WHERE Client_ID = @Client_ID AND Batch_No = @BatchNo AND BoxID = @BoxID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(counterQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client_ID", ClientID());
                        cmd.Parameters.AddWithValue("@BatchNo", batchNo);
                        cmd.Parameters.AddWithValue("@BoxID", boxID);

                        int count = (int)cmd.ExecuteScalar();
                        string countString = count.ToString();
                        lblBoxCount.Text = $"Bag Count: {countString}";

                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An Error occured Updating Box Counter: \n {ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[MainForm]", "[BoxCounter]", $"FAILED (  {ex.Message}  )", lblStatus);
            }

        }

        // Get Results to Populate Table ----------------------------------------------------------------------------------------------------------
        public void GetResults(string batchNo, string refNo, string BoxID)
        {
            DataTable dataTable = new DataTable(); // Create New datatable to Store Results

            string selectQuery = "Execute [BespokeProject_Get_Details] @Client_ID, @Batch_No, @Ref_No, @BoxID, 'MAIN'";

            // Revent to Default Batch Number Value where required
            if (batchNo == "DEFAULT")
            {
                batchNo = txbBatchNo.Text;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client_ID", ClientID());
                        cmd.Parameters.AddWithValue("@Batch_No", batchNo);
                        cmd.Parameters.AddWithValue("@Ref_No", refNo);
                        cmd.Parameters.AddWithValue("@BoxID", BoxID);
                        SqlDataReader reader = cmd.ExecuteReader();
                        dataTable.Load(reader);

                    }
                    conn.Close();

                    resultsTable.DataSource = dataTable; // Populate Table With The Results
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An Error occured Getting Results: \n {ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[MainForm]", "[GetResults]", $"FAILED (  {ex.Message}  )", lblStatus);
            }

        }

        private void CheckExceptions()
        {
            string query = "EXECUTE [BespokeProject_Get_Exceptions] @Batch_No, @Box_ID, @Client";
            string BoxID = txbBoxID.Text;
            string batchNo = txbBatchNo.Text;
            string refNo = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Batch_No", batchNo);
                        cmd.Parameters.AddWithValue("@Box_ID", BoxID);
                        cmd.Parameters.AddWithValue("@Client", ClientID());

                        // Execute Data Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Populate variables from reader
                            while (reader.Read())
                            {
                                refNo = reader["Ref_No"].ToString();
                            }
                        }
                    }
                    conn.Close();
                }

                if (refNo != "NO RESULTS")
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowError($"This BagID/BoxID has Exceptions which need to be retrieved. Please retrieve: \n {refNo}");
                    return;
                }

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An Error occured Checking Excpetions: \n {ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[MainForm]", "[CheckExceptions]", $"FAILED (  {ex.Message}  )", lblStatus);
            }


        }

        // Execute Stored Proc to Insert Data ----------------------------------------------------------------------------------------------------------
        private void InsertData(string batchNo, string refNo, string BoxID)
        {

            string insertQuery = "EXECUTE [BespokeProject_Insert_Details] @Client_ID, @Batch_No, @BoxID, @Ref_No, @User";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client_ID", ClientID());
                        cmd.Parameters.AddWithValue("@Batch_No", batchNo);
                        cmd.Parameters.AddWithValue("@BoxID", BoxID);
                        cmd.Parameters.AddWithValue("@Ref_No", refNo);
                        cmd.Parameters.AddWithValue("@User", userName);
                        cmd.ExecuteNonQuery();

                    }
                    conn.Close();

                    currentCount++;

                    SessionMaintenance.LogBook("", "[MainForm]", "[InsertData]", $"Record Inserted:{client}, {batchNo}, {BoxID}, {refNo}", lblStatus);
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An Error occured Inserting Data: \n {ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[MainForm]", "[InsertData]", $"FAILED (  {ex.Message}  )", lblStatus);
            }

        }

        // Check for Duplicate References ----------------------------------------------------------------------------------------------------------
        private void DupeChecker(string refNo)
        {
            if (ClientID() == "045")
            {
                string dupeCheck = $"SELECT COUNT(*) FROM BespokeProject_Details WHERE Client_ID = @Client_ID AND Ref_No = @Ref_No";

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(dupeCheck, conn))
                        {
                            // Count Number of References the same as Parameter
                            cmd.Parameters.AddWithValue("@Client_ID", ClientID());
                            cmd.Parameters.AddWithValue("@Ref_No", refNo);
                            int count = (int)cmd.ExecuteScalar();
                            if (count > 0)
                            {
                                Duplicate(refNo);
                            }
                            else
                            {
                                lblDupe.Visible = false;
                                lblDupe.Text = "";
                            }
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowError($"An Error occured checking for duplicates: \n {ex.Message}");
                    SessionMaintenance.LogBook($"ERROR", "[MainForm]", "[DupeChecker]", $"FAILED (  {ex.Message}  )", lblStatus);
                }
            }
        }

        // Show Duplicate References ----------------------------------------------------------------------------------------------------------
        private void Duplicate(string refNo)
        {
            lblDupe.Visible = true;
            lblDupe.Text = $"Warning! Reference '{refNo}' already exists!";
            lblDupe.ForeColor = Color.Red;
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
                messageBox.ShowError($"An error occurred getting report URL: {ex.Message}");
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

                SessionMaintenance.LogBook($"", "[MainForm]", "[RunReport]", $"Process Executed with parameter: {ID}", lblStatus);
            }
            catch (Exception ex)  // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred opening URL: {ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[MainForm]", "[RunReport]", $"FAILED (  {ex.Message}  )", lblStatus);
            }
        }

        // Run Reports -------------------------------------------------------------------------------------------------------------------------
        private void CheckTimer()
        {
            string query = "SELECT TOP 1 DT_Created FROM BespokeProject_LogBook WHERE Session_Id = @Session_Id ORDER BY DT_Created DESC";
            DateTime? lastUpdated = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Session_Id", sessionId);
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            lastUpdated = (DateTime)result;
                        }
                    }

                    conn.Close();
                }

                if (lastUpdated.HasValue && DateTime.Now - lastUpdated.Value >= TimeSpan.FromHours(2.5))
                {
                    // Show popup to indicate session will expire in 30 minutes
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowWarning($"Session will expire in <30 minutes due to inactivity! \n{DateTime.Now}");
                }
            }
            catch (Exception ex) // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred checking session timeout: \n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[MainForm]", "[CheckTimer]", $"FAILED ( {ex.Message} )", lblStatus);
            }
        }


        //=============================================================================================================================================================================================
        //-- Enviroment Events --//
        //=============================================================================================================================================================================================

        private void btnInsert_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnInsert);
        }

        private void btnInsert_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnInsert);
        }

        private void btnMaintenance_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnMaintenance);
        }

        private void btnMaintenance_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnMaintenance);
        }

        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnSearch);
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnSearch);
        }

        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnClear);
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnClear);
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnExit);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnExit);
        }

        // Check Length of String
        private void txbBoxID_TextChanged(object sender, EventArgs e)
        {
            string boxIdString = txbBoxID.Text;
            int boxIdLength = boxIdString.Length;

            //Check if the BoxID is more than 6 Characters
            if (boxIdLength > 6)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("Field 2 is too long.");

                txbBoxID.Text = boxIdString.Substring(0, Math.Min(boxIdString.Length, 6));
                txbBoxID.SelectAll();
                return;
            }
            else
            {
                BoxCounter();
            }
            UserCounter();
        }

        // Check Length of String
        private void txbRefNo_TextChanged(object sender, EventArgs e)
        {
            string RefNoString = txbRefNo.Text;
            int RefNoLength = RefNoString.Length;

            //Check if the Reference is more than 100 Characters
            if (RefNoLength > 100)
            {

                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("Field 3 is too long.");
                txbRefNo.Text = RefNoString.Substring(0, Math.Min(RefNoString.Length, 100));
                txbRefNo.SelectAll();
                return;
            }
            UserCounter();
        }

        // Populate Results Table & Check Length of String
        private void txbBatchNo_TextChanged(object sender, EventArgs e)
        {


            string batchNo = txbBatchNo.Text.ToUpper();
            string refNo = txbRefNo.Text.ToUpper();
            string BoxID = txbBoxID.Text.ToUpper();
            int batchNoLength = batchNo.Length;

            //Check if the Batch Number is more than 24 Characters
            if (batchNoLength > 24)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("Field 1 is too long.");
                txbBatchNo.Text = batchNo.Substring(0, Math.Min(batchNo.Length, 24));
                txbBatchNo.SelectAll();
                return;
            }
            else
            {
                GetResults(batchNo, refNo, BoxID);
                BatchCounter();
            }
            UserCounter();
        }

        // Status Box
        private void lblStatus_MouseEnter(object sender, EventArgs e)
        {
            lblStatus.BackColor = Color.Gray;
            lblStatus.ForeColor = Color.Black;
        }

        private void lblStatus_MouseLeave(object sender, EventArgs e)
        {
            lblStatus.BackColor = Color.White;
            lblStatus.ForeColor = Color.Silver;
        }

        // Change Texbox Colour When Focused
        private void txbBatchNo_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(txbBatchNo);
            txbBatchNo.SelectAll();
        }

        // Change Texbox Colour When Not Focused
        private void txbBatchNo_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(txbBatchNo);
        }

        // Change Texbox Colour When Focused
        private void txbBoxID_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(txbBoxID);
            txbBoxID.SelectAll();
        }

        // Change Texbox Colour When Not Focused
        private void txbBoxID_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(txbBoxID);
        }

        // Change Texbox Colour When Focused
        private void txbRefNo_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(txbRefNo);
        }

        // Change Texbox Colour When Not Focused
        private void txbRefNo_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(txbRefNo);

            CheckExceptions();
        }

        private void resultsTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == resultsTable.Columns["Reference"].Index && e.Value != null)
            {
                string refNo = e.Value.ToString();
                string query = "SELECT COUNT(*) FROM BespokeProjects_Exceptions WHERE Ref_No = @Ref_No AND Client_ID = @Client_ID";

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Ref_No", refNo);
                            cmd.Parameters.AddWithValue("@Client_ID", ClientID());

                            int count = (int)cmd.ExecuteScalar();

                            if (count == 1)
                            {
                                e.CellStyle.BackColor = Color.Red;
                                e.CellStyle.ForeColor = Color.White;
                            }
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowError($"An Error Formatting DataGrid Cells: {ex.Message}");
                    SessionMaintenance.LogBook($"ERROR", "[MainForm]", "[CellFormatting]", $"FAILED (  {ex.Message}  )", lblStatus);
                }
            }
        }

        //=============================================================================================================================================================================================
        //-- Button Click Events --//
        //=============================================================================================================================================================================================

        // Exit Application Event
        private void btnExit_Click(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[MainForm]", "[FormClose]", "Form Closed", lblStatus);
            this.Hide();
        }

        // Open Search Form Event
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchFrom searchFrom = new SearchFrom();
            searchFrom.userName = userName;
            searchFrom.sessionId = sessionId;
            searchFrom.clientID = ClientID();
            searchFrom.Show();
            UserCounter();
        }

        // Open Maintenance Form Event
        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            MaintenanceFrom maintenanceForm = new MaintenanceFrom(this);
            maintenanceForm.userName = userName;
            maintenanceForm.sessionId = sessionId;
            maintenanceForm.clientID = ClientID();
            maintenanceForm.Show();
            UserCounter();
        }

        // Insert Button Event
        private void btnInsert_Click(object sender, EventArgs e)
        {
            // Decalre Variables
            string batchNo = txbBatchNo.Text.ToUpper();
            string refNo = txbRefNo.Text.ToUpper();
            string BoxID = txbBoxID.Text.ToUpper();

            // Reset Duplicate Warning Message
            lblDupe.Visible = false;
            lblDupe.Text = "Duplicate";

            // Error Check Values
            if (string.IsNullOrEmpty(batchNo) || string.IsNullOrEmpty(refNo) || string.IsNullOrEmpty(BoxID))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("Fields are missing or invalid. Please complete all fields.");

                return;
            }

            // Do SQL Stuff
            else
            {
                Cursor.Current = Cursors.WaitCursor; // Set Cursor to Eggtimer

                try
                {
                    // Check if Duplicate Reference
                    DupeChecker(refNo);

                    // Execute Insert Stored Proc
                    InsertData(batchNo, refNo, BoxID);

                    // Execute Select Stored Proc
                    GetResults(batchNo, "", "");

                    // Update Counters
                    UserCounter();
                    BatchCounter();
                    BoxCounter();

                    txbRefNo.Text = ""; // Clear Text Box
                    txbRefNo.Focus(); // Focus Text Box
                    lblLastScan.Text = $"Last Input: {refNo} @ {DateTime.Now} "; // Populate Last Input
                }

                // Catch Any Errors
                catch (Exception ex)
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowError($"An error occurred: {ex.Message}");
                }

                // Set Cursor to Default
                finally
                {
                    Cursor.Current = Cursors.Default;

                }
            }

        }

        // Clear Button Event
        private void btnClear_Click(object sender, EventArgs e)
        {
            txbBatchNo.Text = "";
            txbBoxID.Text = "";
            txbRefNo.Text = "";
            resultsTable.DataSource = "";
            txbBatchNo.Focus();
            lblDupe.Text = "";
            lblDupe.Visible = false;
            lblBatchCounter.Text = "Batch Count: 0";
            lblBoxCount.Text = "Bag Count: 0";
            lblLastScan.Text = "";
            UserCounter();
        }

        // Menu Strip Buttons //

        //Exceptions Form
        private void exceptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exceptions exceptions = new Exceptions();
            exceptions.userName = userName;
            exceptions.sessionId = sessionId;
            exceptions.client = client;
            exceptions.Show();
        }

        // Close Menu Option
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnExit_Click(sender, e);
        }
        // Insert Menu Option
        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnInsert_Click(sender, e);
        }
        // Clear Menu Option
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnClear_Click(sender, e);
        }
        // Export Report
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunReport("001");
        }
        // Breakdown Report
        private void breakdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunReport("002");
        }
        // Generate Label Report
        private void labelGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunReport("003");
        }
        // More Reports
        private void moreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunReport("004");
        }
        // Search Menu Option
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }
        // Maintenance Menu Option
        private void maintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnMaintenance_Click(sender, e);
        }

        //=============================================================================================================================================================================================
        //-- Key Down Events --//
        //=============================================================================================================================================================================================

        // Tab Key Event
        private void txbRefNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // Trigger the Insert Button Event When Tab Key Is Pressed
            if (e.KeyCode == Keys.Tab && !ModifierKeys.HasFlag(Keys.Shift))
            {
                btnInsert_Click(sender, e);
                txbRefNo.Focus();
            }
        }

        // Keyboard Shortcuts
        private void MainFrom_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {

                btnClear_Click(sender, e);
            }

            // ctrl + S
            if (e.Control && e.KeyCode == Keys.S)
            {

                btnSearch_Click(sender, e);
            }

            // ctrl + M
            if (e.Control && e.KeyCode == Keys.M)
            {

                btnMaintenance_Click(sender, e);
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {

                btnExit_Click(sender, e);
            }
        }

        // ctrl + V Event (txbBatchNo)
        private void txbBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the text from the clipboard
                string clipboardText = Clipboard.GetText();

                // Filter out invalid characters and set the filtered text to the TextBox
                txbBatchNo.Text = new string(clipboardText.Where(c => char.IsLetterOrDigit(c) || c == '-' || char.IsControl(c)).ToArray());

                // Cancel the paste operation
                e.SuppressKeyPress = true;


            }
        }

        // ctrl + V Event (txbRefNo)
        private void txbRefNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the text from the clipboard
                string clipboardText = Clipboard.GetText();

                // Filter out invalid characters and set the filtered text to the TextBox
                txbRefNo.Text = new string(clipboardText.Where(c => char.IsLetterOrDigit(c) || c == '-' || char.IsControl(c)).ToArray());

                // Cancel the paste operation
                e.SuppressKeyPress = true;


            }
        }

        // ctrl + V Event (txbBoxID)
        private void txbBoxID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the text from the clipboard
                string clipboardText = Clipboard.GetText();

                // Filter out invalid characters and set the filtered text to the TextBox
                txbBoxID.Text = new string(clipboardText.Where(c => char.IsLetterOrDigit(c) || c == '-' || char.IsControl(c)).ToArray());

                // Cancel the paste operation
                e.SuppressKeyPress = true;

            }
        }

        private void sessionTimer_Tick(object sender, EventArgs e)
        {
            CheckTimer();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
    }
}