// OrderManagement.UI/Forms/ReportForm.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.ApplicationInsights.AspNetCore;
using OrderManagement.BLL;
using OrderManagement.Models;
using OrderManagement.UI.Properties;

namespace OrderManagement.UI.Forms
{
    public partial class ReportForm : Form
    {
        private readonly ReportManager _reportManager;
        private readonly ItemManager _itemManager;
        private readonly AgentManager _agentManager;
        private readonly OrderManager _orderManager;

        private ReportType _reportType;
        private int _orderId;

        public ReportForm(ReportType reportType, int orderId = 0)
        {
            InitializeComponent();
            _reportManager = new ReportManager();
            _itemManager = new ItemManager();
            _agentManager = new AgentManager();
            _orderManager = new OrderManager();

            _reportType = reportType;
            _orderId = orderId;
        }

        private void InitializeComponent()
        {
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.dgvReportData = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportData)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.lblFilter);
            this.panelFilter.Controls.Add(this.cboFilter);
            this.panelFilter.Controls.Add(this.btnApplyFilter);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 0);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(800, 60);
            this.panelFilter.TabIndex = 0;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(20, 20);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(32, 13);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter:";
            // 
            // cboFilter
            // 
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Location = new System.Drawing.Point(100, 20);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(300, 21);
            this.cboFilter.TabIndex = 1;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(420, 20);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(100, 23);
            this.btnApplyFilter.TabIndex = 2;
            this.btnApplyFilter.Text = "Apply Filter";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // dgvReportData
            // 
            this.dgvReportData.AllowUserToAddRows = false;
            this.dgvReportData.AllowUserToDeleteRows = false;
            this.dgvReportData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReportData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportData.Location = new System.Drawing.Point(0, 60);
            this.dgvReportData.Name = "dgvReportData";
            this.dgvReportData.ReadOnly = true;
            this.dgvReportData.Size = new System.Drawing.Size(800, 340);
            this.dgvReportData.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(680, 410);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 30);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print Report";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            // Replace the problematic line with the following:
            this.printPreviewDialog.Icon = SystemIcons.Application;
            this.printPreviewDialog.Icon = Properties.Resources.printPreviewDialog_Icon;
            this.printPreviewDialog.Visible = false;
            // 
            // ReportForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvReportData);
            this.Controls.Add(this.panelFilter);
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportData)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.DataGridView dgvReportData;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;

        private void ReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Configure form based on report type
                ConfigureReportForm();

                // Load initial data
                LoadReportData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureReportForm()
        {
            switch (_reportType)
            {
                case ReportType.BestSellingItems:
                    this.Text = "Best Selling Items Report";
                    panelFilter.Visible = false;  // No filter needed
                    break;

                case ReportType.ItemsByAgent:
                    this.Text = "Items Purchased by Agent Report";
                    lblFilter.Text = "Select Agent:";

                    // Load agents for filter
                    List<Agent> agents = _agentManager.GetAllAgents();
                    cboFilter.DataSource = agents;
                    cboFilter.DisplayMember = "AgentName";
                    cboFilter.ValueMember = "AgentID";

                    break;

                case ReportType.AgentsByItem:
                    this.Text = "Agents Purchasing Item Report";
                    lblFilter.Text = "Select Item:";

                    // Load items for filter
                    List<Item> items = _itemManager.GetAllItems();
                    cboFilter.DataSource = items;
                    cboFilter.DisplayMember = "ItemName";
                    cboFilter.ValueMember = "ItemID";

                    break;

                case ReportType.OrderDetails:
                    this.Text = $"Order Details Report - Order #{_orderId}";
                    panelFilter.Visible = false;  // No filter needed

                    if (_orderId == 0)
                    {
                        MessageBox.Show("No order selected", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }

                    break;
            }
        }

        private void LoadReportData()
        {
            switch (_reportType)
            {
                case ReportType.BestSellingItems:
                    LoadBestSellingItems();
                    break;

                case ReportType.ItemsByAgent:
                    if (cboFilter.SelectedValue != null)
                    {
                        int agentId = (int)cboFilter.SelectedValue;
                        LoadItemsByAgent(agentId);
                    }
                    break;

                case ReportType.AgentsByItem:
                    // This would be implemented if needed
                    break;

                case ReportType.OrderDetails:
                    LoadOrderDetails(_orderId);
                    break;
            }
        }

        private void LoadBestSellingItems()
        {
            List<Item> items = _reportManager.GetBestSellingItems();
            dgvReportData.DataSource = items;

            // Format columns
            if (dgvReportData.Columns["UnitPrice"] != null)
                dgvReportData.Columns["UnitPrice"].DefaultCellStyle.Format = "N2";

            // Hide unnecessary columns
            if (dgvReportData.Columns["Description"] != null)
                dgvReportData.Columns["Description"].Visible = false;
        }

        private void LoadItemsByAgent(int agentId)
        {
            List<Item> items = _reportManager.GetItemsPurchasedByAgent(agentId);
            dgvReportData.DataSource = items;

            // Format columns
            if (dgvReportData.Columns["UnitPrice"] != null)
                dgvReportData.Columns["UnitPrice"].DefaultCellStyle.Format = "N2";

            // Hide unnecessary columns
            if (dgvReportData.Columns["Description"] != null)
                dgvReportData.Columns["Description"].Visible = false;
        }

        private void LoadOrderDetails(int orderId)
        {
            Order order = _reportManager.GenerateOrderReport(orderId);

            if (order != null && order.OrderDetails != null)
            {
                // Create a datatable to display the order items
                DataTable dt = new DataTable();
                dt.Columns.Add("ItemID", typeof(int));
                dt.Columns.Add("ItemName", typeof(string));
                dt.Columns.Add("Quantity", typeof(int));
                dt.Columns.Add("UnitAmount", typeof(decimal));
                dt.Columns.Add("TotalAmount", typeof(decimal));

                foreach (var detail in order.OrderDetails)
                {
                    dt.Rows.Add(
                        detail.ItemID,
                        detail.Item?.ItemName,
                        detail.Quantity,
                        detail.UnitAmount,
                        detail.TotalAmount
                    );
                }

                dgvReportData.DataSource = dt;

                // Format decimal columns
                if (dgvReportData.Columns["UnitAmount"] != null)
                    dgvReportData.Columns["UnitAmount"].DefaultCellStyle.Format = "N2";

                if (dgvReportData.Columns["TotalAmount"] != null)
                    dgvReportData.Columns["TotalAmount"].DefaultCellStyle.Format = "N2";

                // Hide ItemID column
                if (dgvReportData.Columns["ItemID"] != null)
                    dgvReportData.Columns["ItemID"].Visible = false;
            }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReportData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying filter: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                // Set up printing
                Graphics g = e.Graphics;
                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                Font regularFont = new Font("Arial", 10);
                Brush brush = Brushes.Black;
                int yPos = 100;
                int leftMargin = 50;
                int topMargin = 50;

                // Print title
                string title = this.Text;
                g.DrawString(title, titleFont, brush, leftMargin, topMargin);
                yPos = topMargin + 50;

                // Print date
                string date = $"Date: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";
                g.DrawString(date, regularFont, brush, leftMargin, yPos);
                yPos += 30;

                // Print filter information if applicable
                if (panelFilter.Visible && cboFilter.SelectedItem != null)
                {
                    string filter = $"Filter: {lblFilter.Text.Replace("Select", "").Trim()} {cboFilter.Text}";
                    g.DrawString(filter, regularFont, brush, leftMargin, yPos);
                    yPos += 30;
                }

                // Print order information if applicable
                if (_reportType == ReportType.OrderDetails)
                {
                    Order order = _orderManager.GetOrderById(_orderId);
                    if (order != null)
                    {
                        Agent agent = _agentManager.GetAgentById(order.AgentID);
                        g.DrawString($"Order #: {order.OrderID}", regularFont, brush, leftMargin, yPos);
                        yPos += 20;
                        g.DrawString($"Order Date: {order.OrderDate.ToString("yyyy-MM-dd")}", regularFont, brush, leftMargin, yPos);
                        yPos += 20;
                        g.DrawString($"Agent: {agent?.AgentName}", regularFont, brush, leftMargin, yPos);
                        yPos += 20;
                        g.DrawString($"Status: {order.Status}", regularFont, brush, leftMargin, yPos);
                        yPos += 30;
                    }
                }

                // Print column headers
                if (dgvReportData.Rows.Count > 0)
                {
                    int[] columnWidths = new int[dgvReportData.Columns.Count];
                    int xPos = leftMargin;

                    // Calculate column widths
                    for (int i = 0; i < dgvReportData.Columns.Count; i++)
                    {
                        if (!dgvReportData.Columns[i].Visible)
                            continue;

                        columnWidths[i] = 150;  // Default width
                        xPos += columnWidths[i];
                    }

                    // Print column headers
                    xPos = leftMargin;
                    for (int i = 0; i < dgvReportData.Columns.Count; i++)
                    {
                        if (!dgvReportData.Columns[i].Visible)
                            continue;

                        g.DrawString(dgvReportData.Columns[i].HeaderText, headerFont, brush, xPos, yPos);
                        xPos += columnWidths[i];
                    }
                    yPos += 25;

                    // Print data rows
                    for (int rowIndex = 0; rowIndex < dgvReportData.Rows.Count; rowIndex++)
                    {
                        xPos = leftMargin;
                        for (int colIndex = 0; colIndex < dgvReportData.Columns.Count; colIndex++)
                        {
                            if (!dgvReportData.Columns[colIndex].Visible)
                                continue;

                            if (dgvReportData.Rows[rowIndex].Cells[colIndex].Value != null)
                            {
                                string cellValue = dgvReportData.Rows[rowIndex].Cells[colIndex].Value.ToString();

                                // Format numeric values
                                if (dgvReportData.Columns[colIndex].ValueType == typeof(decimal))
                                {
                                    decimal value = Convert.ToDecimal(dgvReportData.Rows[rowIndex].Cells[colIndex].Value);
                                    cellValue = value.ToString("N2");
                                }

                                g.DrawString(cellValue, regularFont, brush, xPos, yPos);
                            }

                            xPos += columnWidths[colIndex];
                        }
                        yPos += 20;

                        // Check if we need a new page
                        if (yPos > e.MarginBounds.Bottom - 50)
                        {
                            e.HasMorePages = true;
                            return;
                        }
                    }

                    // Print total if it's an order report
                    if (_reportType == ReportType.OrderDetails)
                    {
                        Order order = _orderManager.GetOrderById(_orderId);
                        if (order != null)
                        {
                            yPos += 20;
                            g.DrawString($"Total Amount: {order.TotalAmount.ToString("N2")}", headerFont, brush, leftMargin, yPos);
                        }
                    }
                }
                else
                {
                    g.DrawString("No data to display", regularFont, brush, leftMargin, yPos);
                }

                // No more pages
                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing page: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}