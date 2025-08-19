using Microsoft.Data.SqlClient;
using System.Data;

namespace BespokeProject
{
    public partial class MainForm : Form
    {
        //-- Initialization --//

        // SQL Server Connection String
        private const string connectionString = "Server=SQL-E9VARIOUS;Database=eluciddb_abbot;Integrated Security=True;Encrypt=False;";

        // Pull User Name From Login Form
        public string userName { get; set; }

        public bool Logging = true; // Set Logging Status

        public MainForm()
        {
            InitializeComponent();
            this.KeyDown += MainFrom_KeyDown;
            this.KeyPreview = true;
            this.FormClosing += MainForm_FormClosing;
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
            LogBook($"New Login");
            LogBook("Initialization [MainForm_Load] - Started");
            LogBook($"Initialization [MainForm_Load] - User Logged In: {userName}");
            lblUserName.Text = userName.ToUpper(); // Display User Name
            lblLastScan.Text = ""; // Clear Last Date
            UserCounter(); // Populate User Counter
            LogBook("Initialization [MainForm_Load] - Completed");
        }

        private void LogBook(string logStep)
        {
            string filePath = $"C:\\BespokeProjectLog\\Log\\BespokeProject_LogBook_{userName}.txt";
            string logStepString = $"{DateTime.Now} - [MainForm] - {logStep}";
            string newLogBook = $"{DateTime.Now} - NEW LOGBOOK CREATED: {filePath};";

            if (Logging == true)
            {
                if (logStep == "New Login")
                {
                    logStepString = "//-------------------------------------------------------------------------------------------------------------------//";
                }

                try
                {
                    if (File.Exists(filePath))
                    {
                        File.AppendAllText(filePath, Environment.NewLine + logStepString + ";");
                    }
                    else
                    {
                        File.WriteAllText(filePath, newLogBook);
                        File.AppendAllText(filePath, Environment.NewLine + logStepString + ";");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving Logbook: " + ex.Message);
                    Application.Exit();
                }
            }
            lblStatus.Text = $"Status: {logStepString}";
        }

        // Prevent Special Characters (txbBatchNo)
        private void txbBatchNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show($"Character: '{e.KeyChar}' Not Accepted Here", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogBook($"Initialization [txbSearch_KeyPress] - Unsupported Character Entered: [{e.KeyChar}]");
                e.Handled = true;
            }
        }

        // Prevent Special Characters (txbRefNo)
        private void txbRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show($"Character: '{e.KeyChar}' Not Accepted Here", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogBook($"Initialization [txbSearch_KeyPress] - Unsupported Character Entered: [{e.KeyChar}]");
                e.Handled = true;
            }
        }

        // Prevent Special Characters (txbBoxID)
        private void txbBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show($"Character: '{e.KeyChar}' Not Accepted Here", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogBook($"Initialization [txbSearch_KeyPress] - Unsupported Character Entered: [{e.KeyChar}]");
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

        //-- Operation Methods --//

        // Exit Application Method
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogBook("Operation Method [MainForm_FormClosing] - Started");
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to Exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            LogBook("Operation Method [MainForm_FormClosing] - Completed");
        }

        // Update Counter For How Many The User Has Scanned
        public void UserCounter()
        {
            LogBook("Operation Method [UserCounter] - Started");

            string counterQuery = "SELECT ISNULL(COUNT(ref_no), 0) FROM BespokeProject_Details WHERE User_Created = @UserName AND CAST(DT_Created as date) = CAST(GETDATE() as date)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                LogBook("Operation Method [UserCounter] - SQL Connection Opened");
                using (SqlCommand cmd = new SqlCommand(counterQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    int count = (int)cmd.ExecuteScalar();
                    string countString = count.ToString();
                    lblCount.Text = $"User Count: {countString}";
                    LogBook("Operation Method [UserCounter] - SQL Command Executed");
                }
                conn.Close();
                LogBook("Operation Method [UserCounter] - SQL Connection Closed");
            }
            LogBook("Operation Method [UserCounter] - Completed");
        }

        // Update Counter For How Many Is In The Current Batch
        public void BatchCounter()
        {
            LogBook("Operation Method [BatchCounter] - Started");

            string batchNo = txbBatchNo.Text;
            string counterQuery = "SELECT ISNULL(COUNT(ref_no), 0) FROM BespokeProject_Details WHERE Batch_No = @BatchNo";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                LogBook("Operation Method [BatchCounter] - SQL Connection Opened");

                using (SqlCommand cmd = new SqlCommand(counterQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@BatchNo", batchNo);
                    int count = (int)cmd.ExecuteScalar();
                    string countString = count.ToString();
                    lblBatchCounter.Text = $"Batch Count: {countString}";
                    LogBook("Operation Method [BatchCounter] - SQL Command Executed");
                }
                conn.Close();
                LogBook("Operation Method [BatchCounter] - SQL Connection Closed");
            }
            LogBook("Operation Method [BatchCounter] - Completed");
        }

        // Update Counter For How Many Is In The Current Box
        public void BoxCounter()
        {
            LogBook("Operation Method [BoxCounter] - Started");
            string boxID = txbBoxID.Text;
            string batchNo = txbBatchNo.Text;
            string counterQuery = "SELECT ISNULL(COUNT(ref_no), 0) FROM BespokeProject_Details WHERE Batch_No = @BatchNo AND BoxID = @BoxID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                LogBook("Operation Method [BoxCounter] - SQL Connection Opened");
                using (SqlCommand cmd = new SqlCommand(counterQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@BatchNo", batchNo);
                    cmd.Parameters.AddWithValue("@BoxID", boxID);
                    int count = (int)cmd.ExecuteScalar();
                    string countString = count.ToString();
                    lblBoxCount.Text = $"Bag Count: {countString}";
                    LogBook("Operation Method [BoxCounter] - SQL Command Execute");
                }
                conn.Close();
                LogBook("Operation Method [BoxCounter] - SQL Connection Closed");
            }
            LogBook("Operation Method [BoxCounter] - Completed");
        }

        // Get Results to Populate Table
        public void GetResults(string batchNo, string refNo, string BoxID)
        {
            LogBook("Operation Method [GetResults] - Started");

            DataTable dataTable = new DataTable(); // Create New datatable to Store Results
            LogBook("Operation Method [GetResults] - DataTable Created");

            string selectQuery = "Execute [BespokeProject_Get_Details] @Batch_No, @Ref_No, @BoxID, 'MAIN'";

            // Revent to Default Batch Number Value where required
            if (batchNo == "DEFAULT")
            {
                batchNo = txbBatchNo.Text;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                LogBook("Operation Method [GetResults] - SQl Connection Opened");

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Batch_No", batchNo);
                    cmd.Parameters.AddWithValue("@Ref_No", refNo);
                    cmd.Parameters.AddWithValue("@BoxID", BoxID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    dataTable.Load(reader);
                    LogBook("Operation Method [GetResults] - SQL Command Executed");
                }
                conn.Close();
                LogBook("Operation Method [GetResults] - SQL Connection Closed");

                resultsTable.DataSource = dataTable; // Populate Table With The Results
                LogBook($"Operation Method [GetResults] - DataTable Populated With Parameters [{batchNo}], [{BoxID}], [{refNo}]");
            }
            LogBook("Operation Method [GetResults] - Completed");
        }

        // Execute Stored Proc to Insert Data
        private void InsertData(string batchNo, string refNo, string BoxID)
        {
            LogBook("Operation Method [InsertData] - Started");

            string insertQuery = "EXECUTE [BespokeProject_Insert_Details] @Batch_No, @BoxID, @Ref_No, @User";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                LogBook("Operation Method [InsertData] - SQL Connection Opened");

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Batch_No", batchNo);
                    cmd.Parameters.AddWithValue("@BoxID", BoxID);
                    cmd.Parameters.AddWithValue("@Ref_No", refNo);
                    cmd.Parameters.AddWithValue("@User", userName);
                    cmd.ExecuteNonQuery();
                    LogBook("Operation Method [InsertData] - SQL Command Executed");
                }
                conn.Close();
                LogBook("Operation Method [InsertData] - SQL Connection Closed");
            }
            LogBook($"Operation Method [InsertData] - Data Inseterted: ([{batchNo}], [{BoxID}], [{refNo}], [{userName}])");
            LogBook("Operation Method [InsertData] - Completed");
        }

        // Check for Duplicate References
        private void DupeChecker(string refNo)
        {
            LogBook("Operation Method [DupeChecker] - Started");

            string dupeCheck = $"SELECT COUNT(*) FROM BespokeProject_Details WHERE Ref_No = @Ref_No";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                LogBook("Operation Method [DupeChecker] - SQL Connection Opened");

                using (SqlCommand cmd = new SqlCommand(dupeCheck, conn))
                {
                    // Count Number of References the same as Parameter
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
                    LogBook("Operation Method [DupeChecker] - SQL Command Executed");
                }
                conn.Close();
                LogBook("Operation Method [DupeChecker] - SQL Connection Closed");
            }
            LogBook("Operation Method [DupeChecker] - Completed");
        }

        // Show Duplicate References
        private void Duplicate(string refNo)
        {
            LogBook("Operation Method [Duplicate] - Started");

            lblDupe.Visible = true;
            lblDupe.Text = $"Warning! Reference '{refNo}' already exists!";
            lblDupe.ForeColor = Color.Red;
            LogBook($"Operation Method [Duplicate] - Duplicate Found: ({refNo})");
            LogBook("Operation Method [Duplicate] - Completed");
        }

        //-- Enviroment Events --//

        // Check Length of String
        private void txbBoxID_TextChanged(object sender, EventArgs e)
        {
            LogBook("Enviroment Event [txbBoxID_TextChanged] - Triggered");

            string batchNo = txbBatchNo.Text;
            string boxIdString = txbBoxID.Text;
            int boxIdLength = boxIdString.Length;

            //Check if the BoxID is more than 6 Characters
            if (boxIdLength > 6)
            {
                LogBook("Enviroment Event [txbBoxID_TextChanged] - FAILED - Error: Bag ID is too long.");
                MessageBox.Show("Bag ID is too long.");
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
            LogBook("Enviroment Event [txbRefNo_TextChanged] - Triggered");

            string RefNoString = txbRefNo.Text;
            int RefNoLength = RefNoString.Length;

            //Check if the Reference is more than 24 Characters
            if (RefNoLength > 24)
            {
                LogBook("Enviroment Event [txbRefNo_TextChanged] - FAILED - Error: Reference Number is too long.");
                MessageBox.Show("Reference Number is too long.");
                txbRefNo.Text = RefNoString.Substring(0, Math.Min(RefNoString.Length, 24));
                txbRefNo.SelectAll();
                return;
            }
            UserCounter();
        }

        // Populate Results Table & Check Length of String
        private void txbBatchNo_TextChanged(object sender, EventArgs e)
        {
            LogBook("Enviroment Event [txbBatchNo_TextChanged] - Triggered");

            string batchNo = txbBatchNo.Text.ToUpper();
            string refNo = txbRefNo.Text.ToUpper();
            string BoxID = txbBoxID.Text.ToUpper();
            int batchNoLength = batchNo.Length;

            //Check if the Batch Number is more than 24 Characters
            if (batchNoLength > 24)
            {
                LogBook("Enviroment Event [txbBatchNo_TextChanged] - FAILED - Error: Batch Number is too long.");
                MessageBox.Show("Batch Number is too long.");
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
            txbBatchNo.BackColor = Color.Yellow;
            txbBatchNo.SelectAll();
        }

        // Change Texbox Colour When Not Focused
        private void txbBatchNo_Leave(object sender, EventArgs e)
        {
            txbBatchNo.BackColor = Color.White;
        }

        // Change Texbox Colour When Focused
        private void txbBoxID_Enter(object sender, EventArgs e)
        {
            txbBoxID.BackColor = Color.Yellow;
            txbBoxID.SelectAll();
        }

        // Change Texbox Colour When Not Focused
        private void txbBoxID_Leave(object sender, EventArgs e)
        {
            txbBoxID.BackColor = Color.White;
        }

        // Change Texbox Colour When Focused
        private void txbRefNo_Enter(object sender, EventArgs e)
        {
            txbRefNo.BackColor = Color.Yellow;
        }

        // Change Texbox Colour When Not Focused
        private void txbRefNo_Leave(object sender, EventArgs e)
        {
            txbRefNo.BackColor = Color.White;
        }

        //-- Button Click Events --//

        // Exit Application Event
        private void btnExit_Click(object sender, EventArgs e)
        {
            LogBook("Button Click Event [btnExit_Click] - Started");

            DialogResult result = MessageBox.Show("Are you sure you want to Exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

            LogBook("Button Click Event [btnExit_Click] - Completed");
        }

        // Open Search Form Event
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LogBook("Button Click Event [btnSearch_Click] - Started");

            SearchFrom searchFrom = new SearchFrom();
            searchFrom.userName = userName;
            searchFrom.Logging = Logging;
            searchFrom.Show();
            UserCounter();

            LogBook("Button Click Event [btnSearch_Click] - Completed");
        }

        // Open Maintenance Form Event
        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            LogBook("Button Click Event [btnMaintenance_Click] - Started");

            MaintenanceFrom maintenanceForm = new MaintenanceFrom(this);
            maintenanceForm.userName = userName;
            maintenanceForm.Logging = Logging;
            maintenanceForm.Show();
            UserCounter();

            LogBook("Button Click Event [btnMaintenance_Click] - Completed");
        }

        // Insert Button Event
        private void btnInsert_Click(object sender, EventArgs e)
        {
            LogBook("Button Click Event [btnInsert_Click] - Started");

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
                LogBook("Button Click Event [btnInsert_Click] - FAILED - Error: Fields are missing or invalid. Please complete all fields.");
                MessageBox.Show("Fields are missing or invalid. Please complete all fields.");
                return;
            }

            // Do SQL Stuff
            else
            {
                LogBook("Button Click Event [btnInsert_Click] - Check Values Executed");

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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                    LogBook($"Button Click Event [btnInsert_Click] - FAILED - Error: {ex.Message}");
                }

                // Set Cursor to Default
                finally
                {
                    Cursor.Current = Cursors.Default;
                    LogBook("Button Click Event [btnInsert_Click] - SQL Step Executed");
                }
            }
            LogBook("Button Click Event [btnInsert_Click] - Completed");
        }

        // Clear Button Event
        private void btnClear_Click(object sender, EventArgs e)
        {
            LogBook("Button Click Event [btnClear_Click] - Started");

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

            LogBook("Button Click Event [btnClear_Click] - Completed");
        }

        //-- Key Down Events --//

        // Tab Key Event
        private void txbRefNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // Trigger the Insert Button Event When Tab Key Is Pressed
            if (e.KeyCode == Keys.Tab && !ModifierKeys.HasFlag(Keys.Shift))
            {
                LogBook("Key Down Event [txbRefNo_PreviewKeyDown] - Triggered");
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
                LogBook("Key Down Event [MainFrom_KeyDown (ctrl + G)] - Triggered");
                btnClear_Click(sender, e);
            }

            // ctrl + S
            if (e.Control && e.KeyCode == Keys.S)
            {
                LogBook("Key Down Event [MainFrom_KeyDown (ctrl + S)] - Triggered");
                btnSearch_Click(sender, e);
            }

            // ctrl + M
            if (e.Control && e.KeyCode == Keys.M)
            {
                LogBook("Key Down Event [MainFrom_KeyDown (ctrl + M)] - Triggered");
                btnMaintenance_Click(sender, e);
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                LogBook("Key Down Event [MainFrom_KeyDown (Esc)] - Triggered");
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
                txbBatchNo.Text = new string(clipboardText.Where(c => char.IsLetterOrDigit(c) || char.IsControl(c)).ToArray());

                // Cancel the paste operation
                e.SuppressKeyPress = true;

                LogBook("Key Down Event [txbBatchNo_KeyDown (ctrl + V)] - Triggered");
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
                txbRefNo.Text = new string(clipboardText.Where(c => char.IsLetterOrDigit(c) || char.IsControl(c)).ToArray());

                // Cancel the paste operation
                e.SuppressKeyPress = true;

                LogBook("Key Down Event [txbrefNo_KeyDown (ctrl + V)] - Triggered");
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
                txbBoxID.Text = new string(clipboardText.Where(c => char.IsLetterOrDigit(c) || char.IsControl(c)).ToArray());

                // Cancel the paste operation
                e.SuppressKeyPress = true;

                LogBook("Key Down Event [txbBoxID_KeyDown (ctrl + V)] - Triggered");
            }
        }


    }
}