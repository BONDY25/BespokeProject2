using Microsoft.Data.SqlClient;

namespace BespokeProject_2
{
    public partial class MenuForm : Form
    {
        //=============================================================================================================================================================================================
        //-- Initialization --//
        //=============================================================================================================================================================================================

        private const string connectionString = SessionMaintenance.connectionString;
        public string userName { get; set; }

        public string sessionId { get; set; }

        public MenuForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.MaximizeBox = false;
        }

        // Form Load --------------------------------------------------------------------------------------------------------------------------------
        private void MenuForm_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[MenuForm]", "[FormLoad]", "Form Started");
            Text = $"{Environment.UserName.ToUpper()} - Bespoke Project II Menu";
        }

        // Form Close --------------------------------------------------------------------------------------------------------------------------------
        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                bool result = messageBox.ShowExitDialog(); // Ask user if they want to exit
                if (result == true)
                {
                    SessionMaintenance.LogBook("", "[MenuForm]", "[FormClosing]", "Application Closed");
                    SessionMaintenance.ClearSessionID(sessionId);  
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                SessionMaintenance.LogBook("", "[MenuForm]", "[FormClosing]", "Application Closed");
                SessionMaintenance.ClearSessionID(sessionId);
                Application.Exit();
            }
        }       

        //=============================================================================================================================================================================================
        //-- Enviroment Events --//
        //=============================================================================================================================================================================================

        private void btnCustom_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnCustom);
        }

        private void btnCustom_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnCustom);
        }

        private void btnPlate_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnPlate);
        }

        private void btnPlate_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnPlate);
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

        // Custom Button Click --------------------------------------------------------------------------------------------------------------------------------
        private void btnCustom_Click(object sender, EventArgs e)
        {
            ClientSelectionForm clientSelectionForm = new ClientSelectionForm();
            clientSelectionForm.userName = userName;
            clientSelectionForm.sessionId = sessionId;
            clientSelectionForm.Show();
        }

        // Plate Button Click --------------------------------------------------------------------------------------------------------------------------------
        private void btnPlate_Click(object sender, EventArgs e)
        {
            InputEdit inputEdit = new InputEdit();
            inputEdit.userName = userName;
            inputEdit.sessionId = sessionId;
            inputEdit.Show();
        }

        // Exit Button Click --------------------------------------------------------------------------------------------------------------------------------
        private void btnExit_Click(object sender, EventArgs e)
        {
            CustomMessageBox messageBox = new CustomMessageBox();
            bool result = messageBox.ShowExitDialog(); // Ask user if they want to exit
            if (result == true)
            {
                Application.Exit();
            }
        }
    }
}
