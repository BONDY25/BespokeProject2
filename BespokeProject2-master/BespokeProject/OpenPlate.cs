using Microsoft.Data.SqlClient;
using System.Data;

namespace BespokeProject_2
{
    public partial class OpenPlate : Form
    {
        //=============================================================================================================================================================================================
        //-- Initialization --//
        //=============================================================================================================================================================================================

        private const string connectionString = SessionMaintenance.connectionString;
        public string userName { get; set; }

        public string sessionId { get; set; }

        public int formMode = 0; // 1 = From Manifest Form, 0 = From MenuStrip.
        public OpenPlate()
        {
            InitializeComponent();
        }

        // LogBook Method --------------------------------------------------------------------------------------------------------------------------------
        private void OpenPlate_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[OpenPlate]", "[FormLoad]", $"Form Started - Mode: {formMode}");
            Text = $"{Environment.UserName.ToUpper()} - Bespoke Project II Open License Plates";
            GetResults();
            PopulateDataGrid();
        }

        private void OpenPlate_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionMaintenance.LogBook("", "[OpenPlate]", "[FormClosing]", "Form Closed");
        }

        //=============================================================================================================================================================================================
        //-- Operation Methods --//
        //=============================================================================================================================================================================================

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
                messageBox.ShowDefError("117", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[OpenPlate]", "[GetResults]", $"FAILED: Code 117 (  {ex.Message}  )");
            }
        }

        // Populate History Table --------------------------------------------------------------------------------------------------------------------------------
        private void PopulateDataGrid()
        {
            string query = "SELECT License_Plate, COUNT(Consignment) as [Consignments], MAX(DT_Created) as [Date] FROM BespokeProject_LP_Input_Results WHERE Session_Id = @Session_Id GROUP BY License_Plate ORDER BY [Date] DESC";

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

                SessionMaintenance.LogBook("", "[InputEdit]", "[PopulateDataGrid]", $"DataGrid Populated");
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("117", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[OpenPlate]", "[PopulateDataGrid]", $"FAILED: Code 117 (  {ex.Message}  )");
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
                SessionMaintenance.LogBook($"ERROR", "[OpenPlate]", "[GetColour]", $"FAILED: Code 204 (  {ex.Message}  )");
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
                SessionMaintenance.LogBook($"ERROR", "[OpenPlate]", "[ClearResults]", $"FAILED: Code 212 (  {ex.Message}  )");
            }
        }


        //=============================================================================================================================================================================================
        //-- Enviroment Events --//
        //=============================================================================================================================================================================================


        // Close Button --------------------------------------------------------------------------------------------------------------------------------
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonEnter(btnClose);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            SessionMaintenance.ButtonLeave(btnClose);
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

        //=============================================================================================================================================================================================
        //-- Button Click Events --//
        //=============================================================================================================================================================================================


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
                SessionMaintenance.LogBook($"ERROR", "[OpenPlate]", "[btnClose_Click]", $"FAILED (  {ex.Message}  )");
                Application.Exit();
            }
        }

        // Cell Click --------------------------------------------------------------------------------------------------------------------------------
        private void dgHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (formMode == 1)
            {
                // Open Manifest form 
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string licensePlate = dgHistory.Rows[e.RowIndex].Cells[0].Value.ToString();

                    Manifest manifestForm = new Manifest();
                    manifestForm.sessionId = sessionId;
                    manifestForm.userName = userName;
                    manifestForm.licesnePlate = licensePlate;
                    manifestForm.Show();
                    this.Close();
                }
            }
        }


    }
}
