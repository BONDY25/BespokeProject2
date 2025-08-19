using BespokeProject_2;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BespokeProject
{
    public partial class SearchFrom : Form
    {
        //=============================================================================================================================================================================================
        //-- Initialization --//
        //=============================================================================================================================================================================================


        // SQL Server Connection String
        private const string connectionString = SessionMaintenance.connectionString;

        // Pull User Name From Login Form
        public string userName { get; set; }
        public string clientID { get; set; }
        public string client { get; set; }

        public string sessionId { get; set; }

        public SearchFrom()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.KeyPreview = true;
            this.KeyDown += SearchFrom_KeyDown;
        }

        // Display User Name
        private void SearchFrom_Load(object sender, EventArgs e)
        {
            PopulateKey();
            SessionMaintenance.LogBook("", "[SearchForm]", "[FormLoad]", "Form Started");
            lblUserName.Text = userName.ToUpper();
            txbSearch.KeyPress += txbSearch_KeyPress;
            txbSearch.KeyDown += txbSearch_KeyDown;
        }

        // Prevent Special Characters (txbBatchNo)
        private void txbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"Character: '{e.KeyChar}' Not Accepted Here");
                e.Handled = true;
            }
        }

        //=============================================================================================================================================================================================
        //-- Operational Methods --//
        //=============================================================================================================================================================================================


        private void GetResults(string field, string search)
        {

            // Declare Variables
            DataTable dataTable = new DataTable();

            string selectQuery = "Execute [BespokeProject_Get_Details] @Client_ID, @Batch_No, @Ref_No, @BoxID, 'SEARCH'";

            try
            {
                // Execute SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Open Connection To SQL Server

                    if (field == "3")
                    {
                        using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Client_ID", clientID);
                            cmd.Parameters.AddWithValue("@Batch_No", "");
                            cmd.Parameters.AddWithValue("@Ref_No", "");
                            cmd.Parameters.AddWithValue("@BoxID", search);
                            SqlDataReader reader = cmd.ExecuteReader();
                            dataTable.Load(reader);

                        }
                    }
                    else if (field == "1")
                    {
                        using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Client_ID", clientID);
                            cmd.Parameters.AddWithValue("@Batch_No", "");
                            cmd.Parameters.AddWithValue("@Ref_No", search);
                            cmd.Parameters.AddWithValue("@BoxID", "");
                            SqlDataReader reader = cmd.ExecuteReader();
                            dataTable.Load(reader);

                        }
                    }
                    else if (field == "2")
                    {
                        using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Client_ID", clientID);
                            cmd.Parameters.AddWithValue("@Batch_No", search);
                            cmd.Parameters.AddWithValue("@Ref_No", "");
                            cmd.Parameters.AddWithValue("@BoxID", "");
                            SqlDataReader reader = cmd.ExecuteReader();
                            dataTable.Load(reader);

                        }
                    }

                    conn.Close(); // Close Connection to SQL Server


                    resultsTable.DataSource = dataTable; // Populate Results Table
                }
            }
            // Catch Errors
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred Getting Results: {ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[SearchForm]", "[GetResults]", $"An error occurred Getting Results: {ex.Message}");
            }

        }

        private void PopulateKey()
        {
            string client045 = "Key: \n1. Reference \n2. Batch Number \n3. Bag ID"; // Abbott Lyon
            string client054 = "Key: \n1. Barcode/Sku \n2. Order Number \n3. Box ID"; // Korres
            string client040 = "Key: \n1. Barcode/Sku \n2. Order Number \n3. Box ID"; // Jack1t

            if (clientID == "045")
            {
                lblKey.Text = client045;
            }
            else if (clientID == "054")
            {
                lblKey.Text = client054;
            }
            else if (clientID == "40")
            {
                lblKey.Text = client040;
            }

            else
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("Sorry, This client is not set up for the Search function");
                this.Close();
            }
        }


        //=============================================================================================================================================================================================
        //-- Enviroment Events --//
        //=============================================================================================================================================================================================


        private void cbField_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(cbField);
        }

        private void cbField_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(cbField);
        }

        private void txbSearch_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(txbSearch);
        }

        private void txbSearch_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(txbSearch);
        }

        private void btnBack_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnBack);
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnBack);
        }

        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnClear);
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnClear);
        }

        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnSearch);
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnSearch);
        }

        //=============================================================================================================================================================================================
        //-- Button Click Events --//
        //=============================================================================================================================================================================================


        // Search Button Event
        private void btnSearch_Click(object sender, EventArgs e)
        {


            string field = cbField.SelectedItem as string;
            string search = txbSearch.Text.ToUpper();

            //Error Check Values
            if (string.IsNullOrEmpty(field) || string.IsNullOrEmpty(search))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("Fields are missing or invalid. Please complete all fields.");
                return;
            }
            if (field.Length > 24)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("Search field is too long.");
                return;
            }
            if (search.Length > 24)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError("Search term is too long.");

                return;
            }

            GetResults(field, search);


        }

        // Close Search Form Event
        private void btnBack_Click(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[SearchForm]", "[FormClose]", "Form Closed");
            this.Close();
        }

        // Clear Results Table
        private void btnClear_Click(object sender, EventArgs e)
        {

            resultsTable.DataSource = null;
            txbSearch.Text = "";
            cbField.Text = "";

        }

        //=============================================================================================================================================================================================
        //-- Key Down Events --//
        //=============================================================================================================================================================================================


        // ctrl + V Event (txbSearch)
        private void txbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the text from the clipboard
                string clipboardText = Clipboard.GetText();

                // Filter out invalid characters and set the filtered text to the TextBox
                txbSearch.Text = new string(clipboardText.Where(c => char.IsLetterOrDigit(c) || c == '-' || char.IsControl(c)).ToArray());

                // Cancel the paste operation
                e.SuppressKeyPress = true;

            }
        }

        // Keyboard Shortcuts
        private void SearchFrom_KeyDown(object sender, KeyEventArgs e)
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
