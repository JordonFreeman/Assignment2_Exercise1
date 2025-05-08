using System;
using System.Data;
using System.Windows.Forms;

namespace OrderManagement.UI.Forms
{
    partial class AgentForm : Form
    {
        private Label lblAgentName, lblAddress, lblContactNumber, lblEmail;
        private TextBox txtAgentName, txtAddress, txtContactNumber, txtEmail;
        private Button btnSave, btnCancel, btnDelete, btnNew;
        private DataGridView dgvAgents;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Agent ID for tracking the currently selected agent
        private int selectedAgentId = 0;

        // Constructor
        public AgentForm()
        {
            InitializeComponent();
            // Wire up event handlers
            this.Load += new EventHandler(this.AgentForm_Load);
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            this.btnNew.Click += new EventHandler(this.btnNew_Click);
            this.dgvAgents.CellClick += new DataGridViewCellEventHandler(this.dgvAgents_CellClick);
        }

        public MainForm MdiParent { get; internal set; }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Override the Show method to make it work properly
        public new void Show()
        {
            base.Show();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAgentName = new System.Windows.Forms.Label();
            this.txtAgentName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblContactNumber = new System.Windows.Forms.Label();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvAgents = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgents)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAgentName
            // 
            this.lblAgentName.AutoSize = true;
            this.lblAgentName.Location = new System.Drawing.Point(20, 20);
            this.lblAgentName.Name = "lblAgentName";
            this.lblAgentName.Size = new System.Drawing.Size(127, 25);
            this.lblAgentName.TabIndex = 0;
            this.lblAgentName.Text = "Agent Name:";
            // 
            // txtAgentName
            // 
            this.txtAgentName.Location = new System.Drawing.Point(120, 20);
            this.txtAgentName.Name = "txtAgentName";
            this.txtAgentName.Size = new System.Drawing.Size(200, 29);
            this.txtAgentName.TabIndex = 1;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(20, 50);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(91, 25);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(120, 50);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(300, 60);
            this.txtAddress.TabIndex = 3;
            // 
            // lblContactNumber
            // 
            this.lblContactNumber.AutoSize = true;
            this.lblContactNumber.Location = new System.Drawing.Point(20, 120);
            this.lblContactNumber.Name = "lblContactNumber";
            this.lblContactNumber.Size = new System.Drawing.Size(160, 25);
            this.lblContactNumber.TabIndex = 4;
            this.lblContactNumber.Text = "Contact Number:";
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Location = new System.Drawing.Point(120, 120);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(150, 29);
            this.txtContactNumber.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 150);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(66, 25);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 150);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 29);
            this.txtEmail.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(120, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 34);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(220, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 34);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(320, 190);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 34);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(20, 190);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(91, 34);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // dgvAgents
            // 
            this.dgvAgents.AllowUserToAddRows = false;
            this.dgvAgents.AllowUserToDeleteRows = false;
            this.dgvAgents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAgents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgents.Location = new System.Drawing.Point(20, 230);
            this.dgvAgents.MultiSelect = false;
            this.dgvAgents.Name = "dgvAgents";
            this.dgvAgents.ReadOnly = true;
            this.dgvAgents.RowHeadersWidth = 72;
            this.dgvAgents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAgents.Size = new System.Drawing.Size(760, 208);
            this.dgvAgents.TabIndex = 12;
            // 
            // AgentForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvAgents);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtContactNumber);
            this.Controls.Add(this.lblContactNumber);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAgentName);
            this.Controls.Add(this.lblAgentName);
            this.Name = "AgentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agent Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Event Handlers

        private void AgentForm_Load(object sender, EventArgs e)
        {
            // Load agents data when form loads
            LoadAgents();
            ClearInputs();
            SetControlState(false);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // Clear inputs and prepare for new agent
            ClearInputs();
            SetControlState(true);
            txtAgentName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtAgentName.Text))
            {
                MessageBox.Show("Agent name is required!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAgentName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
            {
                MessageBox.Show("Contact number is required!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactNumber.Focus();
                return;
            }

            try
            {
                // Implement your database logic here
                // For example:
                // if (selectedAgentId > 0)
                // {
                //     // Update existing agent
                //     UpdateAgent();
                // }
                // else
                // {
                //     // Add new agent
                //     AddNewAgent();
                // }

                // For demonstration, we'll just show a success message
                MessageBox.Show("Agent information saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload the agents and reset form
                LoadAgents();
                ClearInputs();
                SetControlState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving agent: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Cancel editing
            ClearInputs();
            SetControlState(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if an agent is selected
            if (selectedAgentId <= 0)
            {
                MessageBox.Show("Please select an agent to delete!", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this agent?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Implement your database logic here
                    // For example:
                    // DeleteAgent(selectedAgentId);

                    // For demonstration, we'll just show a success message
                    MessageBox.Show("Agent deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload the agents and reset form
                    LoadAgents();
                    ClearInputs();
                    SetControlState(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting agent: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvAgents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a valid row is clicked (not header)
            if (e.RowIndex >= 0)
            {
                // Get the selected agent
                selectedAgentId = Convert.ToInt32(dgvAgents.Rows[e.RowIndex].Cells["AgentId"].Value);

                // Load agent details to form
                txtAgentName.Text = dgvAgents.Rows[e.RowIndex].Cells["AgentName"].Value.ToString();
                txtAddress.Text = dgvAgents.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                txtContactNumber.Text = dgvAgents.Rows[e.RowIndex].Cells["ContactNumber"].Value.ToString();
                txtEmail.Text = dgvAgents.Rows[e.RowIndex].Cells["Email"].Value.ToString();

                // Enable form for editing
                SetControlState(true);
            }
        }

        #endregion

        #region Helper Methods

        private void LoadAgents()
        {
            try
            {
                // Implement your database logic here to load agents
                // For example:
                // DataTable dt = GetAgentsFromDatabase();
                // dgvAgents.DataSource = dt;

                // For demonstration, we'll create a sample DataTable
                DataTable dt = new DataTable();
                dt.Columns.Add("AgentId", typeof(int));
                dt.Columns.Add("AgentName", typeof(string));
                dt.Columns.Add("Address", typeof(string));
                dt.Columns.Add("ContactNumber", typeof(string));
                dt.Columns.Add("Email", typeof(string));

                // Add some sample data
                dt.Rows.Add(1, "John Doe", "123 Main St, City", "555-1234", "john@example.com");
                dt.Rows.Add(2, "Jane Smith", "456 Oak Ave, Town", "555-5678", "jane@example.com");

                dgvAgents.DataSource = dt;

                // Optionally, configure the grid appearance
                dgvAgents.Columns["AgentId"].Visible = false;
                dgvAgents.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading agents: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            // Reset form inputs
            selectedAgentId = 0;
            txtAgentName.Clear();
            txtAddress.Clear();
            txtContactNumber.Clear();
            txtEmail.Clear();
        }

        private void SetControlState(bool isEditing)
        {
            // Enable/disable controls based on editing state
            txtAgentName.Enabled = isEditing;
            txtAddress.Enabled = isEditing;
            txtContactNumber.Enabled = isEditing;
            txtEmail.Enabled = isEditing;

            btnSave.Enabled = isEditing;
            btnCancel.Enabled = isEditing;
            btnDelete.Enabled = selectedAgentId > 0;
            btnNew.Enabled = !isEditing;
            dgvAgents.Enabled = !isEditing;
        }
        #endregion
    }
}