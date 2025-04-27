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

namespace OrderManagement.UI.Forms
{
    public partial class MainForm : Form
    {
        private readonly User _currentUser;

        public MainForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestSellingItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsByAgentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.manageToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1110, 38);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(62, 34);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(196, 40);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(196, 40);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemsToolStripMenuItem,
            this.agentsToolStripMenuItem,
            this.ordersToolStripMenuItem});
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(107, 34);
            this.manageToolStripMenuItem.Text = "Manage";
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(196, 40);
            this.itemsToolStripMenuItem.Text = "Items";
            this.itemsToolStripMenuItem.Click += new System.EventHandler(this.itemsToolStripMenuItem_Click);
            // 
            // agentsToolStripMenuItem
            // 
            this.agentsToolStripMenuItem.Name = "agentsToolStripMenuItem";
            this.agentsToolStripMenuItem.Size = new System.Drawing.Size(196, 40);
            this.agentsToolStripMenuItem.Text = "Agents";
            this.agentsToolStripMenuItem.Click += new System.EventHandler(this.agentsToolStripMenuItem_Click);
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(196, 40);
            this.ordersToolStripMenuItem.Text = "Orders";
            this.ordersToolStripMenuItem.Click += new System.EventHandler(this.ordersToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bestSellingItemsToolStripMenuItem,
            this.itemsByAgentToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(101, 34);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // bestSellingItemsToolStripMenuItem
            // 
            this.bestSellingItemsToolStripMenuItem.Name = "bestSellingItemsToolStripMenuItem";
            this.bestSellingItemsToolStripMenuItem.Size = new System.Drawing.Size(294, 40);
            this.bestSellingItemsToolStripMenuItem.Text = "Best Selling Items";
            this.bestSellingItemsToolStripMenuItem.Click += new System.EventHandler(this.bestSellingItemsToolStripMenuItem_Click);
            // 
            // itemsByAgentToolStripMenuItem
            // 
            this.itemsByAgentToolStripMenuItem.Name = "itemsByAgentToolStripMenuItem";
            this.itemsByAgentToolStripMenuItem.Size = new System.Drawing.Size(294, 40);
            this.itemsByAgentToolStripMenuItem.Text = "Items by Agent";
            this.itemsByAgentToolStripMenuItem.Click += new System.EventHandler(this.itemsByAgentToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 508);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1110, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1110, 530);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bestSellingItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsByAgentToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblStatus.Text = $"Welcome, {_currentUser.UserName} | Role: {_currentUser.Role} | Last Login: {_currentUser.LastLogin.ToString("yyyy-MM-dd HH:mm:ss")}";
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if form is already open
            foreach (Form form in this.MdiChildren)
            {
                if (form is ItemForm)
                {
                    form.Activate();
                    return;
                }
            }

            ItemForm itemForm = new ItemForm();
            itemForm.MdiParent = this;
            itemForm.Show();
        }

        private void agentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if form is already open
            foreach (Form form in this.MdiChildren)
            {
                if (form is AgentForm)
                {
                    form.Activate();
                    return;
                }
            }

            AgentForm agentForm = new AgentForm();
            agentForm.MdiParent = this;
            agentForm.Show();
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if form is already open
            foreach (Form form in this.MdiChildren)
            {
                if (form is OrderForm)
                {
                    form.Activate();
                    return;
                }
            }

            OrderForm orderForm = new OrderForm();
            orderForm.MdiParent = this;
            orderForm.Show();
        }

        private void bestSellingItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Implement report for best selling items
            ReportForm reportForm = new ReportForm(ReportType.BestSellingItems);
            reportForm.MdiParent = this;
            reportForm.Show();
        }

        private void itemsByAgentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Implement report for items purchased by an agent
            ReportForm reportForm = new ReportForm(ReportType.ItemsByAgent);
            reportForm.MdiParent = this;
            reportForm.Show();
        }
    }

    // Define report types
    public enum ReportType
    {
        BestSellingItems,
        ItemsByAgent,
        AgentsByItem,
        OrderDetails
    }
}