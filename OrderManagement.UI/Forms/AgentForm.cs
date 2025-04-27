using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManagement.BLL;
using OrderManagement.Models;

public partial class AgentForm : Form
{
    private readonly AgentManager _agentManager;
    private Agent _selectedAgent;

    public AgentForm()
    {
        InitializeComponent();
        _agentManager = new AgentManager();
    }

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
        this.lblAgentName.Size = new System.Drawing.Size(71, 13);
        this.lblAgentName.TabIndex = 0;
        this.lblAgentName.Text = "Agent Name:";
        // 
        // txtAgentName
        // 
        this.txtAgentName.Location = new System.Drawing.Point(120, 20);
        this.txtAgentName.Name = "txtAgentName";
        this.txtAgentName.Size = new System.Drawing.Size(200, 20);
        this.txtAgentName.TabIndex = 1;
        // 
        // lblAddress
        // 
        this.lblAddress.AutoSize = true;
        this.lblAddress.Location = new System.Drawing.Point(20, 50);
        this.lblAddress.Name = "lblAddress";
        this.lblAddress.Size = new System.Drawing.Size(48, 13);
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
        this.lblContactNumber.Size = new System.Drawing.Size(87, 13);
        this.lblContactNumber.TabIndex = 4;
        this.lblContactNumber.Text = "Contact Number:";
        // 
        // txtContactNumber
        // 
        this.txtContactNumber.Location = new System.Drawing.Point(120, 120);
        this.txtContactNumber.Name = "txtContactNumber";
        this.txtContactNumber.Size = new System.Drawing.Size(150, 20);
        this.txtContactNumber.TabIndex = 5;
        // 
        // lblEmail
        // 
        this.lblEmail.AutoSize = true;
        this.lblEmail.Location = new System.Drawing.Point(20, 150);
        this.lblEmail.Name = "lblEmail";
        this.lblEmail.Size = new System.Drawing.Size(35, 13);
        this.lblEmail.TabIndex = 6;
        this.lblEmail.Text = "Email:";
        // 
        // txtEmail
        // 
        this.txtEmail.Location = new System.Drawing.Point(120, 150);
        this.txtEmail.Name = "txtEmail";
        this.txtEmail.Size = new System.Drawing.Size(200, 20);
        this.txtEmail.TabIndex = 7;
        // 
        // btnSave
        // 
        this.btnSave.Location = new System.Drawing.Point(120, 190);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(75, 23);
        this.btnSave.TabIndex = 8;
        this.btnSave.Text = "Save";
        this.btnSave.UseVisualStyleBackColor = true;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.Location = new System.Drawing.Point(220, 190);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(75, 23);
        this.btnCancel.TabIndex = 9;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // btnDelete
        // 
        this.btnDelete.Location = new System.Drawing.Point(320, 190);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(75, 23);
        this.btnDelete.TabIndex = 10;
        this.btnDelete.Text = "Delete";
        this.btnDelete.UseVisualStyleBackColor = true;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        // 
        // btnNew
        // 
        this.btnNew.Location = new System.Drawing.Point(20, 190);
        this.btnNew.Name = "btnNew";
        this.btnNew.Size = new System.Drawing.Size(75, 23);
        this.btnNew.TabIndex = 11;
        this.btnNew.Text = "New";
        this.btnNew.UseVisualStyleBackColor = true;
        this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
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
        this.dgvAgents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvAgents.Size = new System.Drawing.Size(760, 208);
        this.dgvAgents.TabIndex = 12;
        this.dgvAgents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAgents_CellClick);
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
        this.Load += new System.EventHandler(this.AgentForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvAgents)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Label lblAgentName;
    private System.Windows.Forms.TextBox txtAgentName;
    private System.Windows.Forms.Label lblAddress;
    private System.Windows.Forms.TextBox txtAddress;
    private System.Windows.Forms.Label lblContactNumber;
    private System.Windows.Forms.TextBox txtContactNumber;
    private System.Windows.Forms.Label lblEmail;
    private System.Windows.Forms.TextBox txtEmail;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnNew;
    private System.Windows.Forms.DataGridView dgvAgents;

    private void AgentForm_Load(object sender, EventArgs e)
    {
        LoadAgents();
        ClearForm();
    }

    private void LoadAgents()
    {
        try
        {
            List<Agent> agents = _agentManager.GetAllAgents();
            dgvAgents.DataSource = agents;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading agents: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ClearForm()
    {
        txtAgentName.Text = string.Empty;
        txtAddress.Text = string.Empty;
        txtContactNumber.Text = string.Empty;
        txtEmail.Text = string.Empty;

        _selectedAgent = null;
        btnDelete.Enabled = false;
    }

    private void PopulateForm(Agent agent)
    {
        if (agent == null)
            return;

        txtAgentName.Text = agent.AgentName;
        txtAddress.Text = agent.Address;
        txtContactNumber.Text = agent.ContactNumber;
        txtEmail.Text = agent.Email;

        _selectedAgent = agent;
        btnDelete.Enabled = true;
    }

    private Agent GetAgentFromForm()
    {
        Agent agent = new Agent
        {
            AgentName = txtAgentName.Text.Trim(),
            Address = txtAddress.Text.Trim(),
            ContactNumber = txtContactNumber.Text.Trim(),
            Email = txtEmail.Text.Trim()
        };

        if (_selectedAgent != null)
            agent.AgentID = _selectedAgent.AgentID;

        return agent;
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
        ClearForm();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Agent agent = GetAgentFromForm();

            if (string.IsNullOrWhiteSpace(agent.AgentName))
            {
                MessageBox.Show("Agent name is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(agent.Address))
            {
                MessageBox.Show("Address is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_selectedAgent == null)
            {
                // Add new agent
                _agentManager.AddAgent(agent);
                MessageBox.Show("Agent added successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Update existing agent
                _agentManager.UpdateAgent(agent);
                MessageBox.Show("Agent updated successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadAgents();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving agent: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        ClearForm();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (_selectedAgent == null)
            return;

        try
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this agent?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _agentManager.DeleteAgent(_selectedAgent.AgentID);
                MessageBox.Show("Agent deleted successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAgents();
                ClearForm();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting agent: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvAgents_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            int agentId = Convert.ToInt32(dgvAgents.Rows[e.RowIndex].Cells["AgentID"].Value);
            Agent agent = _agentManager.GetAgentById(agentId);
            PopulateForm(agent);
        }
    }
}

