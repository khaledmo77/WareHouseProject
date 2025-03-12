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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(52, 42);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(930, 229);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // AddWareHouse
            // 
            AddWareHouse.Location = new Point(108, 325);
            AddWareHouse.Name = "AddWareHouse";
            AddWareHouse.Size = new Size(173, 29);
            AddWareHouse.TabIndex = 1;
            AddWareHouse.Text = "ADD WareHouse";
            AddWareHouse.UseVisualStyleBackColor = true;
            AddWareHouse.Click += AddWareHouse_Click_1;
            // 
            // DeleteWareHouse
            // 
            DeleteWareHouse.Location = new Point(740, 325);
            DeleteWareHouse.Name = "DeleteWareHouse";
            DeleteWareHouse.Size = new Size(166, 29);
            DeleteWareHouse.TabIndex = 2;
            DeleteWareHouse.Text = "Delete WareHouse";
            DeleteWareHouse.UseVisualStyleBackColor = true;
            DeleteWareHouse.Click += DeleteWareHouse_Click;
            // 
            // panelContainer
            // 
            panelContainer.Location = new Point(12, 1);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1040, 451);
            panelContainer.TabIndex = 3;
            // 
            // Edit
            // 
            Edit.Location = new Point(426, 325);
            Edit.Name = "Edit";
            Edit.Size = new Size(166, 29);
            Edit.TabIndex = 4;
            Edit.Text = "Edit";
            Edit.UseVisualStyleBackColor = true;
            Edit.Click += Edit_Click;
            // 
            // WarehouseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 450);
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
    }
}
