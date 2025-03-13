namespace WareHouseProject
{
    partial class SupplyOrderUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            AddSupplyOrder = new Button();
            EditSupplyOrder = new Button();
            panel1 = new Panel();
            BackBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(126, 16);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(580, 188);
            dataGridView1.TabIndex = 0;
            // 
            // AddSupplyOrder
            // 
            AddSupplyOrder.Location = new Point(204, 234);
            AddSupplyOrder.Name = "AddSupplyOrder";
            AddSupplyOrder.Size = new Size(160, 44);
            AddSupplyOrder.TabIndex = 1;
            AddSupplyOrder.Text = "Add Supply Order";
            AddSupplyOrder.UseVisualStyleBackColor = true;
            AddSupplyOrder.Click += AddSupplyOrder_Click;
            // 
            // EditSupplyOrder
            // 
            EditSupplyOrder.Location = new Point(494, 234);
            EditSupplyOrder.Name = "EditSupplyOrder";
            EditSupplyOrder.Size = new Size(196, 44);
            EditSupplyOrder.TabIndex = 2;
            EditSupplyOrder.Text = "Edit Supply Order";
            EditSupplyOrder.UseVisualStyleBackColor = true;
            EditSupplyOrder.Click += EditSupplyOrder_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1087, 588);
            panel1.TabIndex = 3;
            // 
            // BackBtn
            // 
            BackBtn.Location = new Point(989, 16);
            BackBtn.Name = "BackBtn";
            BackBtn.Size = new Size(79, 55);
            BackBtn.TabIndex = 4;
            BackBtn.Text = "Back";
            BackBtn.UseVisualStyleBackColor = true;
            BackBtn.Click += BackBtn_Click;
            // 
            // SupplyOrderUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BackBtn);
            Controls.Add(panel1);
            Controls.Add(EditSupplyOrder);
            Controls.Add(AddSupplyOrder);
            Controls.Add(dataGridView1);
            Name = "SupplyOrderUserControl";
            Size = new Size(1102, 607);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button AddSupplyOrder;
        private Button EditSupplyOrder;
        private Panel panel1;
        private Button BackBtn;
    }
}
