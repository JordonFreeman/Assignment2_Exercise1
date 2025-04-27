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
    public partial class OrderForm : Form
    {
        private readonly OrderManager _orderManager;
        private readonly AgentManager _agentManager;
        private readonly ItemManager _itemManager;

        private Order _currentOrder;
        private readonly List<OrderDetail> _orderDetails;
        private int _nextDetailId = 1;

        public OrderForm()
        {
            InitializeComponent();
            _orderManager = new OrderManager();
            _agentManager = new AgentManager();
            _itemManager = new ItemManager();
            _orderDetails = new List<OrderDetail>();
            _currentOrder = new Order { OrderDate = DateTime.Now };
        }

        private void InitializeComponent()
        {
            this.groupBoxOrderInfo = new System.Windows.Forms.GroupBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lblAgent = new System.Windows.Forms.Label();
            this.cboAgent = new System.Windows.Forms.ComboBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.groupBoxOrderItems = new System.Windows.Forms.GroupBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.btnSaveOrder = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnPrintOrder = new System.Windows.Forms.Button();
            this.groupBoxOrderInfo.SuspendLayout();
            this.groupBoxOrderItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxOrderInfo
            // 
            this.groupBoxOrderInfo.Controls.Add(this.lblOrderDate);
            this.groupBoxOrderInfo.Controls.Add(this.dtpOrderDate);
            this.groupBoxOrderInfo.Controls.Add(this.lblAgent);
            this.groupBoxOrderInfo.Controls.Add(this.cboAgent);
            this.groupBoxOrderInfo.Controls.Add(this.lblTotalAmount);
            this.groupBoxOrderInfo.Controls.Add(this.txtTotalAmount);
            this.groupBoxOrderInfo.Location = new System.Drawing.Point(20, 20);
            this.groupBoxOrderInfo.Name = "groupBoxOrderInfo";
            this.groupBoxOrderInfo.Size = new System.Drawing.Size(400, 120);
            this.groupBoxOrderInfo.TabIndex = 0;
            this.groupBoxOrderInfo.TabStop = false;
            this.groupBoxOrderInfo.Text = "Order Information";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(20, 30);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(62, 13);
            this.lblOrderDate.TabIndex = 0;
            this.lblOrderDate.Text = "Order Date:";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(100, 30);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(120, 20);
            this.dtpOrderDate.TabIndex = 1;
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Location = new System.Drawing.Point(20, 60);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(38, 13);
            this.lblAgent.TabIndex = 2;
            this.lblAgent.Text = "Agent:";
            // 
            // cboAgent
            // 
            this.cboAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgent.FormattingEnabled = true;
            this.cboAgent.Location = new System.Drawing.Point(100, 60);
            this.cboAgent.Name = "cboAgent";
            this.cboAgent.Size = new System.Drawing.Size(250, 21);
            this.cboAgent.TabIndex = 3;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 90);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(76, 13);
            this.lblTotalAmount.TabIndex = 4;
            this.lblTotalAmount.Text = "Total Amount:";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(100, 90);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(120, 20);
            this.txtTotalAmount.TabIndex = 5;
            this.txtTotalAmount.Text = "0.00";
            // 
            // groupBoxOrderItems
            // 
            this.groupBoxOrderItems.Controls.Add(this.lblItem);
            this.groupBoxOrderItems.Controls.Add(this.cboItem);
            this.groupBoxOrderItems.Controls.Add(this.lblQuantity);
            this.groupBoxOrderItems.Controls.Add(this.numQuantity);
            this.groupBoxOrderItems.Controls.Add(this.lblUnitPrice);
            this.groupBoxOrderItems.Controls.Add(this.txtUnitPrice);
            this.groupBoxOrderItems.Controls.Add(this.btnAddItem);
            this.groupBoxOrderItems.Controls.Add(this.btnRemoveItem);
            this.groupBoxOrderItems.Location = new System.Drawing.Point(20, 150);
            this.groupBoxOrderItems.Name = "groupBoxOrderItems";
            this.groupBoxOrderItems.Size = new System.Drawing.Size(400, 140);
            this.groupBoxOrderItems.TabIndex = 1;
            this.groupBoxOrderItems.TabStop = false;
            this.groupBoxOrderItems.Text = "Order Items";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(20, 30);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(30, 13);
            this.lblItem.TabIndex = 0;
            this.lblItem.Text = "Item:";
            // 
            // cboItem
            // 
            this.cboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Location = new System.Drawing.Point(100, 30);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(250, 21);
            this.cboItem.TabIndex = 1;
            this.cboItem.SelectedIndexChanged += new System.EventHandler(this.cboItem_SelectedIndexChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(20, 60);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.Text = "Quantity:";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(100, 60);
            this.numQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(80, 20);
            this.numQuantity.TabIndex = 3;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(20, 90);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(56, 13);
            this.lblUnitPrice.TabIndex = 4;
            this.lblUnitPrice.Text = "Unit Price:";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(100, 90);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.ReadOnly = true;
            this.txtUnitPrice.Size = new System.Drawing.Size(80, 20);
            this.txtUnitPrice.TabIndex = 5;
            this.txtUnitPrice.Text = "0.00";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(200, 90);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 6;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(290, 90);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(90, 23);
            this.btnRemoveItem.TabIndex = 7;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.AllowUserToDeleteRows = false;
            this.dgvOrderItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new System.Drawing.Point(20, 300);
            this.dgvOrderItems.MultiSelect = false;
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderItems.Size = new System.Drawing.Size(760, 150);
            this.dgvOrderItems.TabIndex = 2;
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.Location = new System.Drawing.Point(440, 150);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(100, 30);
            this.btnSaveOrder.TabIndex = 3;
            this.btnSaveOrder.Text = "Save Order";
            this.btnSaveOrder.UseVisualStyleBackColor = true;
            this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Location = new System.Drawing.Point(440, 200);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(100, 30);
            this.btnCancelOrder.TabIndex = 4;
            this.btnCancelOrder.Text = "Cancel Order";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Location = new System.Drawing.Point(440, 50);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(100, 30);
            this.btnNewOrder.TabIndex = 5;
            this.btnNewOrder.Text = "New Order";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(20, 460);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(760, 128);
            this.dgvOrders.TabIndex = 6;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            // 
            // btnPrintOrder
            // 
            this.btnPrintOrder.Location = new System.Drawing.Point(440, 250);
            this.btnPrintOrder.Name = "btnPrintOrder";
            this.btnPrintOrder.Size = new System.Drawing.Size(100, 30);
            this.btnPrintOrder.TabIndex = 7;
            this.btnPrintOrder.Text = "Print Order";
            this.btnPrintOrder.UseVisualStyleBackColor = true;
            this.btnPrintOrder.Click += new System.EventHandler(this.btnPrintOrder_Click);
            // 
            // OrderForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnPrintOrder);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.btnNewOrder);
            this.Controls.Add(this.btnCancelOrder);
            this.Controls.Add(this.btnSaveOrder);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.groupBoxOrderItems);
            this.Controls.Add(this.groupBoxOrderInfo);
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Order Management";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.groupBoxOrderInfo.ResumeLayout(false);
            this.groupBoxOrderInfo.PerformLayout();
            this.groupBoxOrderItems.ResumeLayout(false);
            this.groupBoxOrderItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupBoxOrderInfo;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label lblAgent;
        private System.Windows.Forms.ComboBox cboAgent;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.GroupBox groupBoxOrderItems;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Button btnSaveOrder;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnPrintOrder;

        private void OrderForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Load agents
                List<Agent> agents = _agentManager.GetAllAgents();
                cboAgent.DataSource = agents;
                cboAgent.DisplayMember = "AgentName";
                cboAgent.ValueMember = "AgentID";

                // Load items
                List<Item> items = _itemManager.GetAllItems();
                cboItem.DataSource = items;
                cboItem.DisplayMember = "ItemName";
                cboItem.ValueMember = "ItemID";

                // Load existing orders
                LoadOrders();

                // Initialize a new order
                InitializeNewOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrders()
        {
            try
            {
                List<Order> orders = _orderManager.GetAllOrders();
                dgvOrders.DataSource = orders;

                // Format date column
                if (dgvOrders.Columns["OrderDate"] != null)
                    dgvOrders.Columns["OrderDate"].DefaultCellStyle.Format = "yyyy-MM-dd";

                // Format decimal columns
                if (dgvOrders.Columns["TotalAmount"] != null)
                    dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "N2";

                // Hide unnecessary columns
                if (dgvOrders.Columns["OrderDetails"] != null)
                    dgvOrders.Columns["OrderDetails"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeNewOrder()
        {
            _currentOrder = new Order
            {
                OrderDate = DateTime.Now,
                Status = "Pending"
            };

            dtpOrderDate.Value = _currentOrder.OrderDate;

            if (cboAgent.Items.Count > 0)
                cboAgent.SelectedIndex = 0;

            _orderDetails.Clear();
            _nextDetailId = 1;
            UpdateOrderItemsGrid();
            CalculateTotalAmount();
        }

        private void UpdateOrderItemsGrid()
        {
            // Create a datatable to display the order items
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("ItemID", typeof(int));
            dt.Columns.Add("ItemName", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("UnitAmount", typeof(decimal));
            dt.Columns.Add("TotalAmount", typeof(decimal));

            foreach (var detail in _orderDetails)
            {
                dt.Rows.Add(
                    detail.ID,
                    detail.ItemID,
                    detail.Item?.ItemName,
                    detail.Quantity,
                    detail.UnitAmount,
                    detail.TotalAmount
                );
            }

            dgvOrderItems.DataSource = dt;

            // Format decimal columns
            if (dgvOrderItems.Columns["UnitAmount"] != null)
                dgvOrderItems.Columns["UnitAmount"].DefaultCellStyle.Format = "N2";

            if (dgvOrderItems.Columns["TotalAmount"] != null)
                dgvOrderItems.Columns["TotalAmount"].DefaultCellStyle.Format = "N2";

            // Hide ItemID column
            if (dgvOrderItems.Columns["ItemID"] != null)
                dgvOrderItems.Columns["ItemID"].Visible = false;
        }

        private void CalculateTotalAmount()
        {
            decimal totalAmount = _orderDetails.Sum(d => d.TotalAmount);
            _currentOrder.TotalAmount = totalAmount;
            txtTotalAmount.Text = totalAmount.ToString("N2");
        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboItem.SelectedItem != null && cboItem.SelectedItem is Item selectedItem)
            {
                txtUnitPrice.Text = selectedItem.UnitPrice.ToString("N2");
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboItem.SelectedItem == null)
                {
                    MessageBox.Show("Please select an item", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Item selectedItem = (Item)cboItem.SelectedItem;
                int quantity = (int)numQuantity.Value;
                decimal unitAmount = selectedItem.UnitPrice;
                decimal totalAmount = unitAmount * quantity;

                // Check if item already exists in the order
                var existingItem = _orderDetails.FirstOrDefault(d => d.ItemID == selectedItem.ItemID);
                if (existingItem != null)
                {
                    // Update quantity
                    existingItem.Quantity += quantity;
                    existingItem.TotalAmount = existingItem.Quantity * existingItem.UnitAmount;
                }
                else
                {
                    // Add new item
                    OrderDetail detail = new OrderDetail
                    {
                        ID = _nextDetailId++,
                        ItemID = selectedItem.ItemID,
                        Quantity = quantity,
                        UnitAmount = unitAmount,
                        TotalAmount = totalAmount,
                        Item = selectedItem
                    };

                    _orderDetails.Add(detail);
                }

                UpdateOrderItemsGrid();
                CalculateTotalAmount();

                // Reset fields
                if (cboItem.Items.Count > 0)
                    cboItem.SelectedIndex = 0;

                numQuantity.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding item: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrderItems.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an item to remove", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int id = Convert.ToInt32(dgvOrderItems.SelectedRows[0].Cells["ID"].Value);
                var itemToRemove = _orderDetails.FirstOrDefault(d => d.ID == id);

                if (itemToRemove != null)
                {
                    _orderDetails.Remove(itemToRemove);
                    UpdateOrderItemsGrid();
                    CalculateTotalAmount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing item: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            InitializeNewOrder();
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboAgent.SelectedItem == null)
                {
                    MessageBox.Show("Please select an agent", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_orderDetails.Count == 0)
                {
                    MessageBox.Show("Please add at least one item to the order", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _currentOrder.OrderDate = dtpOrderDate.Value;
                _currentOrder.AgentID = (int)cboAgent.SelectedValue;
                _currentOrder.OrderDetails = new List<OrderDetail>(_orderDetails);

                int orderId = _orderManager.CreateOrder(_currentOrder);

                MessageBox.Show($"Order #{orderId} saved successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh order list
                LoadOrders();

                // Initialize a new order
                InitializeNewOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving order: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            InitializeNewOrder();
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int orderId = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["OrderID"].Value);
                    Order order = _orderManager.GetOrderById(orderId);

                    if (order != null)
                    {
                        _currentOrder = order;
                        dtpOrderDate.Value = order.OrderDate;

                        // Set agent
                        foreach (Agent agent in cboAgent.Items)
                        {
                            if (agent.AgentID == order.AgentID)
                            {
                                cboAgent.SelectedItem = agent;
                                break;
                            }
                        }

                        // Load order details
                        _orderDetails.Clear();
                        _nextDetailId = 1;

                        foreach (var detail in order.OrderDetails)
                        {
                            detail.ID = _nextDetailId++;
                            _orderDetails.Add(detail);
                        }

                        UpdateOrderItemsGrid();
                        CalculateTotalAmount();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading order: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            if (_currentOrder.OrderID == 0)
            {
                MessageBox.Show("Please select or save an order first", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Open the report form for the current order
            ReportForm reportForm = new ReportForm(ReportType.OrderDetails, _currentOrder.OrderID);
            reportForm.ShowDialog();
        }
    }
}