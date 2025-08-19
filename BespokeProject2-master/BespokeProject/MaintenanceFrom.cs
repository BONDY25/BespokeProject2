using BespokeProject_2;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BespokeProject
{
    public partial class MaintenanceFrom : Form
    {
        //=============================================================================================================================================================================================
        //-- Initialization --//
        //=============================================================================================================================================================================================


        // SQL Server Connection String
        private const string connectionString = SessionMaintenance.connectionString;

        private MainForm mainFormInstance;

        // Pull User Name From Login Form
        public string userName { get; set; }
        public string clientID { get; set; }
        public string client { get; set; }

        public string sessionId { get; set; }



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
            SessionMaintenance.LogBook("", "[MaintenanceForm]", "[FormLoad]", "Form Started");
            PopulateKey();
            lblField1.Text = fieldOne(clientID);
            lblUserName.Text = userName.ToUpper();
            txbBatchNo.KeyDown += txbBatchNo_KeyDown;
            txbNewData.KeyDown += txbNewData_KeyDown;

        }        

        //=============================================================================================================================================================================================
        //-- Operational Methods --//
        //=============================================================================================================================================================================================

        // Populate Key Label
        private void PopulateKey()
        {
            string client045 = "Key: \n1. Reference \n2. Batch Number \n3. Bag ID"; // Abbott Lyon
            string client054 = "Key: \n1. Barcode/Sku \n2. Order Number \n3. Box ID"; // Korres
            string client040 = "Key: \n1. Barcode/Sku \n2. Order Number \n3. Box ID"; // Jack1t

            if (clientID == "045")
            {
                lblKey.Text = client045;
            }
            //else if (clientID == "054")
            //{
            //    lblKey.Text = client054;
            //}
            else if (clientID == "040")
            {
                lblKey.Text = client040;
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("Sorry, This client is not set up for the Maintenance function.");
                this.Close();
            }
        }

        // Populate Field variable based on client ID
        private string fieldOne(string clientID)
        {
            string fieldOne = null;

            if (clientID == "045")
            {
                fieldOne = "Batch Number";
            }
            else if (clientID == "054")
            {
                fieldOne = "Order Number";
            }
            else if (clientID == "40")
            {
                fieldOne = "Order Number";
            }
            else
            {
                fieldOne = "Field 1.";
            }
            return fieldOne;
        }

        private void GetResults(string batchNo)
        {
            // Declare Variables
            DataTable dataTable = new DataTable();

            string selectQuery = "Execute [BespokeProject_Get_Details] @Client_ID, @Batch_No, @Ref_No, @BoxID, 'SEARCH'";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();


                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client_ID", clientID);
                        cmd.Parameters.AddWithValue("@Batch_No", batchNo);
                        cmd.Parameters.AddWithValue("@Ref_No", "");
                        cmd.Parameters.AddWithValue("@BoxID", "");
                        SqlDataReader reader = cmd.ExecuteReader();
                        dataTable.Load(reader);
                    }
                    conn.Close();

                    resultsTable.DataSource = dataTable;

                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred getting results: {ex.Message}");
            }

        }

        private void ClearCheckBoxes()
        {
            // Uncheck the checkboxes after the update
            foreach (DataGridViewRow row in resultsTable.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["Select"] as DataGridViewCheckBoxCell;
                if (checkBoxCell != null)
                {
                    checkBoxCell.Value = false;
                }
            }
        }

        private void UpdateDetails()
        {

            // Declare Variables
            string batchNo = txbBatchNo.Text.ToUpper();
            string newData = txbNewData.Text.ToUpper();
            string field = cbField.SelectedItem as string;
            DataTable dataTable = new DataTable();

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

                }
            }

            // Execute Stored Proc
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); // Open Connection to SQL Server


                string updateQuery = "EXECUTE [BespokeProject_Update_Details] @Client_ID, @Batch_No, @Field, @New_Data, @Selected_Records, @User";
                string selectedRecordsString = string.Join(", ", selectedRecords.Select(s => $"'{s}'"));

                // Check if any rows are selected
                if (string.IsNullOrEmpty(selectedRecordsString))
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowError("Please select at least one record to update.");
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
                            cmd.Parameters.AddWithValue("@Client_ID", clientID);
                            cmd.Parameters.AddWithValue("@Batch_No", batchNo);
                            cmd.Parameters.AddWithValue("@Field", field);
                            cmd.Parameters.AddWithValue("@New_Data", newData);
                            cmd.Parameters.AddWithValue("@Selected_Records", $"({selectedRecordsString})");
                            cmd.Parameters.AddWithValue("@User", userName);
                            cmd.ExecuteNonQuery();

                        }

                        // Get data to refresh table
                        GetResults(batchNo);
                    }

                    // Uncheck the checkboxes after the update
                    ClearCheckBoxes();

                    Cursor.Current = Cursors.Default; // Set Cursor to Default

                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowInfo("Record(s) Updated!"); // Inform user of update

                    SessionMaintenance.LogBook("", "[MaintenanceForm]", "[UpdateDetails]", $"Record(s) Updated: [{selectedRecordsString}]");
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowError($"An error occurred updating details: {ex.Message}");
                    SessionMaintenance.LogBook("ERROR", "[MaintenanceForm]", "[UpdateDetails]", $"An error occurred updating details: {ex.Message}");
                }
                // Set Cursor to Default
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
                conn.Close(); // Close Connection to SQL Server


                txbNewData.Text = ""; // Clear Text Boxes

                mainFormInstance.UserCounter(); // Update User Counter 
                mainFormInstance.BatchCounter(); // Update User Counter 
                mainFormInstance.BoxCounter();  // Update User Counter 
                mainFormInstance.GetResults("DEFAULT", "", "");
            }
        }

        private void DeleteDetails()
        {
            // Declare Variables
            string batchNo = txbBatchNo.Text.ToUpper();
            DataTable dataTable = new DataTable();

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
                }
            }

            // Ask User if they are sure they want to delete
            CustomMessageBox messageBox = new CustomMessageBox();
            bool result = messageBox.ShowRUSure();
            if (result == true)
            {
                string selectedRecordsString = string.Join(", ", selectedRecords.Select(s => $"'{s}'"));
                // Check if any rows are selected
                if (string.IsNullOrEmpty(selectedRecordsString))
                {
                    CustomMessageBox messageBox2 = new CustomMessageBox();
                    messageBox2.ShowError("Please select at least one record to Delete.");
                    return;
                }

                Cursor.Current = Cursors.WaitCursor; // Set Cursor to Eggtimer

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open(); // Open Connection to SQL Server


                        string deleteQuery = "EXECUTE [BespokeProject_Delete_Details] @Client_ID, @Batch_No, @Selected_Records";

                        // Execute SQL Command
                        if (!string.IsNullOrEmpty(deleteQuery))
                        {
                            using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@Client_ID", clientID);
                                cmd.Parameters.AddWithValue("@Batch_No", batchNo);
                                cmd.Parameters.AddWithValue("@Selected_Records", $"({selectedRecordsString})");
                                cmd.ExecuteNonQuery();

                            }

                            // Get data to refresh table
                            GetResults(batchNo);
                        }

                        // Uncheck the checkboxes after the update
                        //ClearCheckBoxes();

                        conn.Close(); // Close Connection to SQL Server


                        Cursor.Current = Cursors.Default;
                        CustomMessageBox messageBox2 = new CustomMessageBox();
                        messageBox.ShowInfo("Record(s) Deleted"); // Message Box to confirm Deletion

                        SessionMaintenance.LogBook("", "[MaintenanceForm]", "[DeleteDetails]", $"Record(s) Deleted: [{selectedRecordsString}]");
                    }
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    CustomMessageBox messageBox2 = new CustomMessageBox();
                    messageBox.ShowError($"An error occurred updating details: {ex.Message}");
                    SessionMaintenance.LogBook("ERROR", "[MaintenanceForm]", "[DeleteDetails]", $"An error occurred deleting details: {ex.Message}");
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
            }
            else
            {
                return;
            }
        }

        //=============================================================================================================================================================================================
        //-- Enviroment Events --//
        //=============================================================================================================================================================================================

        private void txbBatchNo_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(txbBatchNo);
        }

        private void txbBatchNo_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(txbBatchNo);
        }

        private void txbNewData_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(txbNewData);
        }

        private void txbNewData_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(txbNewData);
        }

        private void cbField_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(cbField);
        }

        private void cbField_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(cbField);
        }

        //Populate Results Table
        private void txbBatchNo_TextChanged(object sender, EventArgs e)
        {

            string batchNo = txbBatchNo.Text.ToUpper();

            GetResults(batchNo);
        }

        // Change Button Colours
        private void btnBack_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnBack);
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnBack);
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnDelete);
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnDelete);
        }

        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnClear);
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnClear);
        }

        private void btnUpdate_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnUpdate);
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnUpdate);
        }

        //=============================================================================================================================================================================================
        //-- Button Click Events --//
        //=============================================================================================================================================================================================


        // Clear Button Event
        private void btnClear_Click(object sender, EventArgs e)
        {
            txbBatchNo.Text = "";
            txbNewData.Text = "";
            cbField.Text = "";
            resultsTable.DataSource = "";
        }

        // Close Maintenance Form Event
        private void btnBack_Click(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[MaintenanceForm]", "[FormClose]", "Form Closed");
            this.Close();
            mainFormInstance.UserCounter();
        }

        // Update Button Event
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Declare Variables
            string batchNo = txbBatchNo.Text.ToUpper();
            string newData = txbNewData.Text.ToUpper();
            string field = cbField.SelectedItem as string;

            // Error Check input Values
            if (string.IsNullOrEmpty(batchNo) || string.IsNullOrEmpty(newData) || string.IsNullOrEmpty(field))
            {

                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("Fields are missing or invalid. Please complete all fields.");
                return;
            }
            if (batchNo.Length > 24)
            {

                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"{fieldOne(clientID)} is too Long");
                return;
            }
            if (newData.Length > 24)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("New Data is too Long");
                return;
            }
            else
            {
                UpdateDetails(); // Invoke Update Method
            }
        }

        // Delete Button Event
        private void btnDelete_Click(object sender, EventArgs e)
        {

            // Declare Variables
            string batchNo = txbBatchNo.Text.ToUpper();

            // Error Check Values
            if (string.IsNullOrEmpty(batchNo))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"Please make sure a {fieldOne(clientID)} is entered and records are selected.");
                return;
            }
            if (batchNo.Length > 24)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"{fieldOne(clientID)} is too Long");
                return;
            }
            else
            {
                DeleteDetails(); // Invoke Delete Method
            }
        }

        //=============================================================================================================================================================================================
        //-- Key Down Events --//
        //=============================================================================================================================================================================================


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

        // ctrl + V Event (txbNewData)
        private void txbNewData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the text from the clipboard
                string clipboardText = Clipboard.GetText();

                // Filter out invalid characters and set the filtered text to the TextBox
                txbNewData.Text = new string(clipboardText.Where(c => char.IsLetterOrDigit(c) || c == '-' || char.IsControl(c)).ToArray());

                // Cancel the paste operation
                e.SuppressKeyPress = true;
            }
        }

        private void MaintenanceFrom_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                btnClear_Click(sender, e);
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnBack_Click(sender, e);
            }
        }
    }
}
