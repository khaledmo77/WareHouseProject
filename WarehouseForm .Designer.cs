namespace WareHouseProject
{
    partial class WarehouseForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            AddWareHouse = new Button();
            DeleteWareHouse = new Button();
            panelContainer = new Panel();
            Edit = new Button();
            showSuppliers = new Button();
            showCustomers = new Button();
            ShowSupplyOrder = new Button();
            ShowWithdrawOrder = new Button();
            ShowTransferOrder = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(625, 229);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // AddWareHouse
            // 
            AddWareHouse.Location = new Point(24, 247);
            AddWareHouse.Name = "AddWareHouse";
            AddWareHouse.Size = new Size(173, 53);
            AddWareHouse.TabIndex = 1;
            AddWareHouse.Text = "ADD WareHouse";
            AddWareHouse.UseVisualStyleBackColor = true;
            AddWareHouse.Click += AddWareHouse_Click_1;
            // 
            // DeleteWareHouse
            // 
            DeleteWareHouse.Location = new Point(434, 247);
            DeleteWareHouse.Name = "DeleteWareHouse";
            DeleteWareHouse.Size = new Size(166, 53);
            DeleteWareHouse.TabIndex = 2;
            DeleteWareHouse.Text = "Delete WareHouse";
            DeleteWareHouse.UseVisualStyleBackColor = true;
            DeleteWareHouse.Click += DeleteWareHouse_Click;
            // 
            // panelContainer
            // 
            panelContainer.Location = new Point(12, 2);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1105, 539);
            panelContainer.TabIndex = 3;
            // 
            // Edit
            // 
            Edit.Location = new Point(227, 247);
            Edit.Name = "Edit";
            Edit.Size = new Size(166, 53);
            Edit.TabIndex = 4;
            Edit.Text = "Edit";
            Edit.UseVisualStyleBackColor = true;
            Edit.Click += Edit_Click;
            // 
            // showSuppliers
            // 
            showSuppliers.Location = new Point(660, 23);
            showSuppliers.Name = "showSuppliers";
            showSuppliers.Size = new Size(120, 52);
            showSuppliers.TabIndex = 5;
            showSuppliers.Text = "Suppliers";
            showSuppliers.UseVisualStyleBackColor = true;
            showSuppliers.Click += showSuppliers_Click;
            // 
            // showCustomers
            // 
            showCustomers.Location = new Point(802, 23);
            showCustomers.Name = "showCustomers";
            showCustomers.Size = new Size(110, 52);
            showCustomers.TabIndex = 6;
            showCustomers.Text = "Customers";
            showCustomers.UseVisualStyleBackColor = true;
            showCustomers.Click += showCustomers_Click;
            // 
            // ShowSupplyOrder
            // 
            ShowSupplyOrder.Location = new Point(660, 91);
            ShowSupplyOrder.Name = "ShowSupplyOrder";
            ShowSupplyOrder.Size = new Size(252, 51);
            ShowSupplyOrder.TabIndex = 7;
            ShowSupplyOrder.Text = "Show Supply Order";
            ShowSupplyOrder.UseVisualStyleBackColor = true;
            ShowSupplyOrder.Click += AddSupplyOrder_Click;
            // 
            // ShowWithdrawOrder
            // 
            ShowWithdrawOrder.Location = new Point(660, 172);
            ShowWithdrawOrder.Name = "ShowWithdrawOrder";
            ShowWithdrawOrder.Size = new Size(252, 51);
            ShowWithdrawOrder.TabIndex = 8;
            ShowWithdrawOrder.Text = "Show Withdraw Order";
            ShowWithdrawOrder.UseVisualStyleBackColor = true;
            // 
            // ShowTransferOrder
            // 
            ShowTransferOrder.Location = new Point(660, 247);
            ShowTransferOrder.Name = "ShowTransferOrder";
            ShowTransferOrder.Size = new Size(252, 51);
            ShowTransferOrder.TabIndex = 9;
            ShowTransferOrder.Text = "Show Transfer Order";
            ShowTransferOrder.UseVisualStyleBackColor = true;
            // 
            // WarehouseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1129, 563);
            Controls.Add(ShowTransferOrder);
            Controls.Add(ShowWithdrawOrder);
            Controls.Add(ShowSupplyOrder);
            Controls.Add(showCustomers);
            Controls.Add(showSuppliers);
            Controls.Add(Edit);
            Controls.Add(panelContainer);
            Controls.Add(DeleteWareHouse);
            Controls.Add(AddWareHouse);
            Controls.Add(dataGridView1);
            Name = "WarehouseForm";
            Text = "WareHouse";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button AddWareHouse;
        private Button DeleteWareHouse;
        private Panel panelContainer;
        private Button Edit;
        private Button showSuppliers;
        private Button showCustomers;
        private Button ShowSupplyOrder;
        private Button ShowWithdrawOrder;
        private Button ShowTransferOrder;
    }
}
