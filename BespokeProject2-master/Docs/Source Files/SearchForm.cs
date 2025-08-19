using Microsoft.Data.SqlClient;
using System.Data;

namespace BespokeProject
{
    public partial class SearchFrom : Form
    {
        //-- Initialization --//

        // SQL Server Connection String
        private const string connectionString = "Server=SQL-E9VARIOUS;Database=eluciddb_abbot;Integrated Security=True;Encrypt=False;";

        // Pull User Name From Login Form
        public string userName { get; set; }

        public bool Logging { get; set; }
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
            LogBook("Initialization [SearchFrom_Load] - Started");
            LogBook($"Initialization [SearchFrom_Load] - User Logged In: {userName}");
            lblUserName.Text = userName.ToUpper();
            txbSearch.KeyPress += txbSearch_KeyPress;
            txbSearch.KeyDown += txbSearch_KeyDown;
            LogBook("Initialization [SearchFrom_Load] - Completed");
        }

        private void LogBook(string logStep)
        {
            string filePath = $"C:\\BespokeProjectLog\\Log\\BespokeProject_LogBook_{userName}.txt";
            string logStepString = $"{DateTime.Now} - [SearchFrom] - {logStep}";

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
        }

        // Prevent Special Characters (txbBatchNo)
        private void txbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show($"Character: '{e.KeyChar}' Not Accepted Here", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogBook($"Initialization [txbSearch_KeyPress] - Unsupported Character Entered: [{e.KeyChar}]");
                e.Handled = true;
            }
        }

        //-- Operation Methods --//

        private void GetResults(string field, string search)
        {
            LogBook("Operation Method [GetResults] - Started");
            // Declare Variables
            DataTable dataTable = new DataTable();
            LogBook("Operation Method [GetResults] - DataTable Created");
            string selectQuery = "Execute [BespokeProject_Get_Details] @Batch_No, @Ref_No, @BoxID, 'SEARCH'";

            // Execute SQL
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); // Open Connection To SQL Server
                LogBook("Operation Method [GetResults] - SQL Connection Open");

                if (field == "Box ID")
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Batch_No", "");
                        cmd.Parameters.AddWithValue("@Ref_No", "");
                        cmd.Parameters.AddWithValue("@BoxID", search);
                        SqlDataReader reader = cmd.ExecuteReader();
                        dataTable.Load(reader);
                        LogBook("Operation Method [GetResults] - SQL Command Executed");
                    }
                }
                else if (field == "Reference")
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Batch_No", "");
                        cmd.Parameters.AddWithValue("@Ref_No", search);
                        cmd.Parameters.AddWithValue("@BoxID", "");
                        SqlDataReader reader = cmd.ExecuteReader();
                        dataTable.Load(reader);
                        LogBook("Operation Method [GetResults] - SQL Command Executed");
                    }
                }
                else if (field == "Batch Number")
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Batch_No", search);
                        cmd.Parameters.AddWithValue("@Ref_No", "");
                        cmd.Parameters.AddWithValue("@BoxID", "");
                        SqlDataReader reader = cmd.ExecuteReader();
                        dataTable.Load(reader);
                        LogBook("Operation Method [GetResults] - SQL Command Executed");
                    }
                }

                conn.Close(); // Close Connection to SQL Server
                LogBook("Operation Method [GetResults] - SQL Connection Closed");

                resultsTable.DataSource = dataTable; // Populate Results Table
                LogBook($"Operation Method [GetResults] - DataTable Populated With Parameters [{field}], [{search}]");
            }
            LogBook("Operation Method [GetResults] - Completed");
        }

        //-- Text Box Events --//

        private void cbField_Enter(object sender, EventArgs e)
        {
            cbField.BackColor = Color.Yellow;
        }

        private void cbField_Leave(object sender, EventArgs e)
        {
            cbField.BackColor = Color.White;
        }

        private void txbSearch_Enter(object sender, EventArgs e)
        {
            txbSearch.BackColor = Color.Yellow;
        }

        private void txbSearch_Leave(object sender, EventArgs e)
        {
            txbSearch.BackColor = Color.White;
        }

        //-- Button Click Events --//

        // Search Button Event
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LogBook("Button Click Event [btnSearch_Click] - Started");

            string field = cbField.SelectedItem as string;
            string search = txbSearch.Text.ToUpper();

            //Error Check Values
            if (string.IsNullOrEmpty(field) || string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Fields are missing or invalid. Please complete all fields.");
                return;
            }
            if (field.Length > 24)
            {
                MessageBox.Show("Search field is too long.");
                return;
            }
            if (search.Length > 24)
            {
                MessageBox.Show("Search term is too long.");
                return;
            }
            LogBook("Button Click Event [btnSearch_Click] - Values Checked");

            GetResults(field, search);

            LogBook("Button Click Event [btnSearch_Click] - Completed");
        }

        // Close Search Form Event
        private void btnBack_Click(object sender, EventArgs e)
        {
            LogBook("Button Click Event [btnBack_Click] - Started");

            this.Close();

            LogBook("Button Click Event [btnBack_Click] - Completed");
        }

        // Clear Results Table
        private void btnClear_Click(object sender, EventArgs e)
        {
            LogBook("Button Click Event [btnClear_Click] - Started");
            resultsTable.DataSource = null;
            txbSearch.Text = "";
            cbField.Text = "";
            LogBook("Button Click Event [btnClear_Click] - Completed");
        }

        //-- Key Down Events --//

        // ctrl + V Event (txbSearch)
        private void txbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the text from the clipboard
                string clipboardText = Clipboard.GetText();

                // Filter out invalid characters and set the filtered text to the TextBox
                txbSearch.Text = new string(clipboardText.Where(c => char.IsLetterOrDigit(c) || char.IsControl(c)).ToArray());

                // Cancel the paste operation
                e.SuppressKeyPress = true;

                LogBook("Key Down Event [txbSearch_KeyDown (ctrl + V)] - Triggered");
            }
        }

        // Keyboard Shortcuts
        private void SearchFrom_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                LogBook("Key Down Event [SearchFrom_KeyDown (ctrl + G)] - Triggered");
                btnClear_Click(sender, e);
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                LogBook("Key Down Event [SearchFrom_KeyDown (Esc)] - Triggered");
                btnBack_Click(sender, e);
            }
        }
    }
}
