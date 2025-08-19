using BespokeProject;
using Microsoft.Data.SqlClient;

namespace BespokeProject_2
{
    public partial class ClientSelectionForm : Form
    {

        //=============================================================================================================================================================================================
        //-- Initialization --//
        //=============================================================================================================================================================================================

        private const string connectionString = SessionMaintenance.connectionString;

        public string userName { get; set; }

        public string sessionId { get; set; }

        public ClientSelectionForm()
        {
            InitializeComponent();
            this.KeyDown += MainFrom_KeyDown;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            PopulateComboBox();
        }


        private void ClientSelectionForm_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[ClientSelectionForm]", "[FormLoad]", "Appliction Started");
        }

        private void ClientSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionMaintenance.LogBook("", "[ClientSelectionForm]", "[FormClosing]", "Form Closed");            
        }

        //=============================================================================================================================================================================================
        //-- Operational Methods --//
        //=============================================================================================================================================================================================

        private void PopulateComboBox()
        {
            string query = "SELECT [Description] FROM BespokeProject_Clients WHERE [Active] = 1 ORDER BY [ID]";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cbClient.Items.Clear();

                            while (reader.Read())
                            {
                                cbClient.Items.Add(reader["Description"].ToString());
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
                SessionMaintenance.LogBook($"ERROR", "[ClientSelectionForm]", "[PopulateComboBox]", $"FAILED: Code 112 (  {ex.Message}  )");
                Application.Exit();
            }
        }

        //=============================================================================================================================================================================================
        //-- Enviroment Box Events --//
        //=============================================================================================================================================================================================

        private void cbClient_Enter(object sender, EventArgs e)
        {
            SessionMaintenance.ControlEnter(cbClient);
        }

        private void cbClient_Leave(object sender, EventArgs e)
        {
            SessionMaintenance.ControlLeave(cbClient);
        }

        private void btnOpen_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnOpen);
        }

        private void btnOpen_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnOpen);
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnExit);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnExit);
        }

        //=============================================================================================================================================================================================
        //-- Button Click Events --//
        //=============================================================================================================================================================================================

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string client = null;

            if (cbClient.SelectedItem != null)
            {
                client = cbClient.SelectedItem.ToString();
            }


            if (string.IsNullOrEmpty(client))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("159", $"");
                return;
            }
            else
            {
                MainForm mainFrom = new MainForm();
                mainFrom.userName = userName;
                mainFrom.sessionId = sessionId;
                mainFrom.client = client;
                mainFrom.Show();
            }
        }

        //=============================================================================================================================================================================================
        //-- Key Down Events --//
        //=============================================================================================================================================================================================

        // Keyboard Shortcuts
        private void MainFrom_KeyDown(object sender, KeyEventArgs e)
        {
            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnExit_Click(sender, e);
            }
        }
    }
}
