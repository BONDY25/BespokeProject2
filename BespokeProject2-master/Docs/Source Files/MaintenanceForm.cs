using Microsoft.Data.SqlClient;
using System.Data;

namespace BespokeProject
{
    public partial class MaintenanceFrom : Form
    {
        //-- Initialization --//

        // SQL Server Connection String
        private const string connectionString = "Server=SQL-E9VARIOUS;Database=eluciddb_abbot;Integrated Security=True;Encrypt=False;";

        private MainForm mainFormInstance;

        // Pull User Name From Login Form
        public string userName { get; set; }

        public bool Logging { get; set; }

        public MaintenanceFrom(MainForm mainForm)
        {
            InitializeComponent();
            DataGridViewCheckBoxColumn selectColumn = new DataGridViewCheckBoxColumn();
            selectColumn.Name = "Select";
            selectColumn.HeaderText = "Select";
            selectColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            selectColumn.ReadOnly = false; // Make sure it's not read-only
            resultsTable.Columns.Add(selectColumn);
            this.ControlBox = false;
            mainFormInstance = mainForm;
            this.KeyPreview = true;
            this.KeyDown += MaintenanceFrom_KeyDown;
        }

        // Display User Name
        private void MaintenanceFrom_Load(object sender, EventArgs e)
        {
            LogBook("Initialization [MaintenanceFrom_Load] - Started");
            LogBook($"Initialization [MaintenanceFrom_Load] - User Logged In: {userName}");
            lblUserName.Text = userName.ToUpper();
            txbBatchNo.KeyPress += txbBatchNo_KeyPress;
            txbBatchNo.KeyDown += txbBatchNo_KeyDown;
            txbNewData.KeyPress += txbNewData_KeyPress;
            txbNewData.KeyDown += txbNewData_KeyDown;
            LogBook("Initialization [MaintenanceFrom_Load] - Completed");
        }

        private void LogBook(string logStep)
        {
            string filePath = $"C:\\BespokeProjectLog\\Log\\BespokeProject_LogBook_{userName}.txt";
            string logStepString = $"{DateTime.Now} - [MaintenanceFrom] - {logStep}";

            string newLogBook = $"{DateTime.Now} - NEW LOGBOOK CREATED: {filePath};";

            if (Logging == true)
            {
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

        // Prevent Special Characters (txbBatchNo)
        private void txbNewData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show($"Character: '{e.KeyChar}' Not Accepted Here", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogBook($"Initialization [txbSearch_KeyPress] - Unsupported Character Entered: [{e.KeyChar}]");
                e.Handled = true;
            }
        }

        //-- Operation Methods --//

        private void GetResults(string batchNo)
        {
            LogBook("Operation Method [GetResults] - Started");

            DataTable dataTable = new DataTable();
            LogBook("Operation Method [GetResults] - DataTable Created");

            string selectQuery = "Execute [BespokeProject_Get_Details] @Batch_No, @Ref_No, @BoxID, 'SEARCH'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                LogBook("Operation Method [GetResults] - SQL Connection Open");

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Batch_No", batchNo);
                    cmd.Parameters.AddWithValue("@Ref_No", "");
                    cmd.Parameters.AddWithValue("@BoxID", "");
                    SqlDataReader reader = cmd.ExecuteReader();
                    dataTable.Load(reader);
                    LogBook("Operation Method [GetResults] - SQL Command Executed");
                }
                conn.Close();
                LogBook("Operation Method [GetResults] - SQL Connection Closed");

                resultsTable.DataSource = dataTable;
                LogBook($"Operation Method [GetResults] - DataTable Populated With Parameters [{batchNo}]");
            }
            LogBook("Operation Method [GetResults] - Completed");
        }

        private void ClearCheckBoxes()
        {
            LogBook("Operation Method [ClearCheckBoxes] - Started");
            // Uncheck the checkboxes after the update
            foreach (DataGridViewRow row in resultsTable.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["Select"] as DataGridViewCheckBoxCell;
                if (checkBoxCell != null)
                {
                    checkBoxCell.Value = false;
                }
            }
            LogBook("Operation Method [ClearCheckBoxes] - Completed");
        }

        //-- Enviroment Events --//

        private void txbBatchNo_Enter(object sender, EventArgs e)
        {
            txbBatchNo.BackColor = Color.Yellow;
        }

        private void txbBatchNo_Leave(object sender, EventArgs e)
        {
            txbBatchNo.BackColor = Color.White;
        }

        private void txbNewData_Enter(object sender, EventArgs e)
        {
            txbNewData.BackColor = Color.Yellow;
        }

        private void txbNewData_Leave(object sender, EventArgs e)
        {
            txbNewData.BackColor = Color.White;
        }

        private void cbField_Enter(object sender, EventArgs e)
        {
            cbField.BackColor = Color.Yellow;
        }

        private void cbField_Leave(object sender, EventArgs e)
        {
            cbField.BackColor = Color.White;
        }

        //Populate Results Table
        private void txbBatchNo_TextChanged(object sender, EventArgs e)
        {
            LogBook("Enviroment Event [txbBatchNo_TextChanged] - Triggered");
            string batchNo = txbBatchNo.Text.ToUpper();

            GetResults(batchNo);
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

        //-- Button Click Events --//

        // Clear Button Event
        private void btnClear_Click(object sender, EventArgs e)
        {
            LogBook("Button Click Event [btnClear_Click] - Started");
            txbBatchNo.Text = "";
            txbNewData.Text = "";
            cbField.Text = "";
            resultsTable.DataSource = "";
            LogBook("Button Click Event [btnClear_Click] - Completed");
        }

        // Close Maintenance Form Event
        private void btnBack_Click(object sender, EventArgs e)
        {
            LogBook("Button Click Event [btnBack_Click] - Started");
            this.Close();
            mainFormInstance.UserCounter();
            LogBook("Button Click Event [btnBack_Click] - Completed");
        }

        // Update Button Event
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LogBook("Button Click Event [btnUpdate_Click] - Started");

            // Declare Variables
            string batchNo = txbBatchNo.Text.ToUpper();
            string newData = txbNewData.Text.ToUpper();
            string field = cbField.SelectedItem as string;
            DataTable dataTable = new DataTable();
            LogBook("Button Click Event [btnUpdate_Click] - DataTable Created");

            // Create a list to store the selected "Ref_No" values
            List<string> selectedRecords = new List<string>();

            // Iterate through all rows in the DataGridView
            foreach (DataGridViewRow row in resultsTable.Rows)
            {
                // Check if the Checkbox is the Select Column is Checked
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["Select"] as DataGridViewCheckBoxCell;

                if (checkBoxCell != null && Convert.ToBoolean(checkBoxCell.Value))
                {
                    string refNo = row.Cells["Reference"].Value?.ToString();

                    if (!string.IsNullOrEmpty(refNo))
                    {
                        selectedRecords.Add(refNo);
                    }
                    LogBook($"Button Click Event [btnUpdate_Click] - CheckBox Selected For: {refNo}");
                }
            }

            // Error Check input Values
            if (string.IsNullOrEmpty(batchNo) || string.IsNullOrEmpty(newData) || string.IsNullOrEmpty(field))
            {
                LogBook("Button Click Event [btnUpdate_Click] - FAILED - Fields are missing or invalid. Please complete all fields.");
                MessageBox.Show("Fields are missing or invalid. Please complete all fields.");
                return;
            }
            if (batchNo.Length > 24)
            {
                LogBook("Button Click Event [btnUpdate_Click] - FAILED - Batch Number is too long.");
                MessageBox.Show("Batch Number is too long.");
                return;
            }
            if (newData.Length > 24)
            {
                LogBook("Button Click Event [btnUpdate_Click] - FAILED - New Data is too long.");
                MessageBox.Show("New Data is too long.");
                return;
            }
            if (field.Length > 24)
            {
                LogBook("Button Click Event [btnUpdate_Click] - FAILED - Update field is too long.");
                MessageBox.Show("Update field is too long.");
                return;
            }
            LogBook("Button Click Event [btnUpdate_Click] - Check Values");

            // Execute Stored Proc
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); // Open Connection to SQL Server
                LogBook("Button Click Event [btnUpdate_Click] - SQL Connection Opened");

                string updateQuery = "EXECUTE [BespokeProject_Update_Details] @Batch_No, @Field, @New_Data, @Selected_Records, @User";
                string selectedRecordsString = string.Join(", ", selectedRecords.Select(s => $"'{s}'"));

                // Check if any rows are selected
                if (string.IsNullOrEmpty(selectedRecordsString))
                {
                    LogBook("Button Click Event [btnUpdate_Click] - FAILED - Error: Please select at least one record to update.");
                    MessageBox.Show("Please select at least one record to update.");
                    return;
                }

                Cursor.Current = Cursors.WaitCursor; // Set Cursor to Eggtimer

                try
                {

                    // Execute SQL Command
                    if (!string.IsNullOrEmpty(updateQuery))
                    {
                        // Update Query
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Batch_No", batchNo);
                            cmd.Parameters.AddWithValue("@Field", field);
                            cmd.Parameters.AddWithValue("@New_Data", newData);
                            cmd.Parameters.AddWithValue("@Selected_Records", $"({selectedRecordsString})");
                            cmd.Parameters.AddWithValue("@User", userName);
                            cmd.ExecuteNonQuery();
                            LogBook($"Button Click Event [btnUpdate_Click] - SQL Command Executed With Parameters [{batchNo}], [{field}], [{newData}], [{selectedRecordsString}]");
                        }

                        // Get data to refresh table
                        GetResults(batchNo);
                    }

                    // Uncheck the checkboxes after the update
                    ClearCheckBoxes();

                    Cursor.Current = Cursors.Default; // Set Cursor to Default

                    MessageBox.Show("Data Updated"); // Inform user of update
                }
                catch (Exception ex)
                {
                    LogBook($"Button Click Event [btnUpdate_Click] - FAILED - Error: {ex.Message}");
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
                // Set Cursor to Default
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
                conn.Close(); // Close Connection to SQL Server
                LogBook("Button Click Event [btnUpdate_Click] - SQL Connection Closed");

                txbNewData.Text = ""; // Clear Text Boxes

                mainFormInstance.UserCounter(); // Update User Counter 
                mainFormInstance.BatchCounter(); // Update User Counter 
                mainFormInstance.BoxCounter();  // Update User Counter 
                mainFormInstance.GetResults("DEFAULT", "", "");
            }
            LogBook("Button Click Event [btnUpdate_Click] - Completed");
        }

        // Delete Button Event
        private void btnDelete_Click(object sender, EventArgs e)
        {
            LogBook("Button Click Event [btnDelete_Click] - Started");
            // Declare Variables
            string batchNo = txbBatchNo.Text.ToUpper();
            DataTable dataTable = new DataTable();
            LogBook("Button Click Event [btnDelete_Click] - DataTable Created");

            // Create a list to store the selected "Ref_No" values
            List<string> selectedRecords = new List<string>();

            // Iterate through all rows in the DataGridView
            foreach (DataGridViewRow row in resultsTable.Rows)
            {
                // Check if the Checkbox is the Select Column is Checked
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["Select"] as DataGridViewCheckBoxCell;

                if (checkBoxCell != null && Convert.ToBoolean(checkBoxCell.Value))
                {
                    string refNo = row.Cells["Reference"].Value?.ToString();

                    if (!string.IsNullOrEmpty(refNo))
                    {
                        selectedRecords.Add(refNo);
                    }
                    LogBook($"Button Click Event [btnDelete_Click] - CheckBox Selected For: {refNo}");
                }
            }

            // Error Check Values
            if (string.IsNullOrEmpty(batchNo))
            {
                LogBook("Button Click Event [btnDelete_Click] - FAILED - Please make sure a Batch Number is entered and records are selected.");
                MessageBox.Show("Please make sure a Batch Number is entered and records are selected.");
                return;
            }
            if (batchNo.Length > 24)
            {
                LogBook("Button Click Event [btnDelete_Click] - FAILED - Batch Number is too long.");
                MessageBox.Show("Batch Number is too long.");
                return;
            }
            LogBook("Button Click Event [btnDelete_Click] - Values Checked");

            // Ask User if they are sure they want to delete
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record(s)?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string selectedRecordsString = string.Join(", ", selectedRecords.Select(s => $"'{s}'"));
                // Check if any rows are selected
                if (string.IsNullOrEmpty(selectedRecordsString))
                {
                    LogBook("Button Click Event [btnDelete_Click] - FAILED - Error: Please select at least one record to Delete.");
                    MessageBox.Show("Please select at least one record to Delete.");
                    return;
                }

                Cursor.Current = Cursors.WaitCursor; // Set Cursor to Eggtimer

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open(); // Open Connection to SQL Server
                        LogBook("Button Click Event [btnDelete_Click] - SQL Connection Opened");

                        string deleteQuery = "EXECUTE [BespokeProject_Delete_Details] @Batch_No, @Selected_Records";

                        // Execute SQL Command
                        if (!string.IsNullOrEmpty(deleteQuery))
                        {
                            using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@Batch_No", batchNo);
                                cmd.Parameters.AddWithValue("@Selected_Records", $"({selectedRecordsString})");
                                cmd.ExecuteNonQuery();
                                LogBook($"Button Click Event [btnDelete_Click] - SQL Command Executed With Parameters [{batchNo}], [{selectedRecordsString}]");
                            }

                            // Get data to refresh table
                            GetResults(batchNo);
                        }

                        // Uncheck the checkboxes after the update
                        //ClearCheckBoxes();

                        conn.Close(); // Close Connection to SQL Server
                        LogBook("Button Click Event [btnDelete_Click] - SQL Connection Closed");

                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Record(s) Deleted"); // Message Box to confirm Deletion
                    }

                }
                catch (Exception ex)
                {
                    LogBook($"Button Click Event [btnDelete_Click] - FAILED - Error: {ex.Message}");
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
                // Set Cursor to Default
                finally
                {
                    Cursor.Current = Cursors.Default;
                }

                txbNewData.Text = ""; // Clear Text Boxes

                mainFormInstance.UserCounter(); // Update User Counter 
                mainFormInstance.BatchCounter(); // Update User Counter 
                mainFormInstance.BoxCounter();  // Update User Counter
                mainFormInstance.GetResults("DEFAULT", "", "");

                LogBook("Button Click Event [btnDelete_Click] - Completed");
            }
        }

        //-- Key Down Events --//

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

        // ctrl + V Event (txbNewData)
        private void txbNewData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the text from the clipboard
                string clipboardText = Clipboard.GetText();

                // Filter out invalid characters and set the filtered text to the TextBox
                txbNewData.Text = new string(clipboardText.Where(c => char.IsLetterOrDigit(c) || char.IsControl(c)).ToArray());

                // Cancel the paste operation
                e.SuppressKeyPress = true;

                LogBook("Key Down Event [txbNewData_KeyDown (ctrl + V)] - Triggered");
            }
        }

        private void MaintenanceFrom_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                LogBook("Key Down Event [MaintenanceFrom_KeyDown (ctrl + G)] - Triggered");
                btnClear_Click(sender, e);
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                LogBook("Key Down Event [MaintenanceFrom_KeyDown (Esc)] - Triggered");
                btnBack_Click(sender, e);
            }
        }


    }
}
