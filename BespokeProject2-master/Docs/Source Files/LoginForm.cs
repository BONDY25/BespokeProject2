using Microsoft.Data.SqlClient;

namespace BespokeProject
{
    public partial class LoginFrom : Form
    {
        //-- Initialization --//

        // SQL Server Connection String
        private const string connectionString = "Server=SQL-E9VARIOUS;Database=eluciddb_abbot;Integrated Security=True;Encrypt=False;";

        public LoginFrom()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
            this.MaximizeBox = false;
            this.KeyPreview = true;
            this.KeyDown += LoginForm_KeyDown;
            txbUsername.KeyPress += txbUsername_KeyPress;
            txbUsername.KeyDown += txbUsername_KeyDown;
        }

        // Exit Application Method
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
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
        }

        // Prevent Special Characters (txbBatchNo)
        private void txbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show($"Character: '{e.KeyChar}' Not Accepted Here", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                e.Handled = true;
            }
        }

        //-- Enviroment Box Events --//

        // Change Textbox Colours When Focused
        private void txbUsername_Enter(object sender, EventArgs e)
        {
            txbUsername.BackColor = Color.Yellow;
        }

        private void txbUsername_Leave(object sender, EventArgs e)
        {
            txbUsername.BackColor = Color.White;
        }

        //-- Button Click Events --//

        // Exit button Event
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Login Button Event
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUsername.Text.ToUpper();

            // Make sure the user has entered a username
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); // Open Connection to SQL Server
                string loginQuery = "SELECT COUNT(*) FROM empl WHERE employee = @Username";
                using (SqlCommand command = new SqlCommand(loginQuery, conn))
                {
                    // Execute SQL Query
                    command.Parameters.AddWithValue("@Username", userName);
                    int count = (int)command.ExecuteScalar();

                    // Check If User Exists
                    if (count > 0)
                    {
                        Cursor.Current = Cursors.WaitCursor; // Set Cursor to Eggtimer

                        try
                        {
                            MainForm MainForm = new MainForm();
                            MainForm.userName = userName;
                            MainForm.Show();
                            this.Hide();
                        }
                        catch (Exception ex) // Catch Any Errors
                        {
                            MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            Cursor.Current = Cursors.Default; // Set Cursor to Default
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid User."); // Show error message for invalid user
                    }
                }
                conn.Close(); // Close Connection to SQL Server
            }
        }

        //-- Key Down Events --//

        // ctrl + V Event (txbBoxID)
        private void txbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the text from the clipboard
                string clipboardText = Clipboard.GetText();

                // Filter out invalid characters and set the filtered text to the TextBox
                txbUsername.Text = new string(clipboardText.Where(c => char.IsLetterOrDigit(c) || char.IsControl(c)).ToArray());

                // Cancel the paste operation
                e.SuppressKeyPress = true;
            }
        }

        // Keyboard Shortcuts
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                txbUsername.Text = "";
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnExit_Click(sender, e);
            }
        }
    }
}