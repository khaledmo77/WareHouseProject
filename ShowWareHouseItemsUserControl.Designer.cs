namespace WareHouseProject
{
    partial class ShowWareHouseItemsUserControl
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
            WareHouseItems = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            Back = new Button();
            AddNewItem = new Button();
            AddItemPanel = new Panel();
            EditItem = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // WareHouseItems
            // 
            WareHouseItems.AutoSize = true;
            WareHouseItems.Location = new Point(467, 22);
            WareHouseItems.Name = "WareHouseItems";
            WareHouseItems.Size = new Size(125, 20);
            WareHouseItems.TabIndex = 0;
            WareHouseItems.Text = "WareHouse Items";
            WareHouseItems.Click += WareHouseItems_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(192, 317);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 34);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 320);
            label1.Name = "label1";
            label1.Size = new Size(125, 20);
            label1.TabIndex = 2;
            label1.Text = "WareHouse Items";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(120, 58);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(849, 234);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Back
            // 
            Back.Location = new Point(23, 18);
            Back.Name = "Back";
            Back.Size = new Size(94, 29);
            Back.TabIndex = 4;
            Back.Text = "Back";
            Back.UseVisualStyleBackColor = true;
            Back.Click += Back_Click;
            // 
            // AddNewItem
            // 
            AddNewItem.Location = new Point(447, 317);
            AddNewItem.Name = "AddNewItem";
            AddNewItem.Size = new Size(181, 50);
            AddNewItem.TabIndex = 5;
            AddNewItem.Text = "Add New Item";
            AddNewItem.UseVisualStyleBackColor = true;
            AddNewItem.Click += AddNewItem_Click;
            // 
            // AddItemPanel
            // 
            AddItemPanel.Location = new Point(23, 3);
            AddItemPanel.Name = "AddItemPanel";
            AddItemPanel.Size = new Size(1070, 411);
            AddItemPanel.TabIndex = 6;
            // 
            // EditItem
            // 
            EditItem.Location = new Point(788, 320);
            EditItem.Name = "EditItem";
            EditItem.Size = new Size(181, 50);
            EditItem.TabIndex = 7;
            EditItem.Text = "Edit Item";
            EditItem.UseVisualStyleBackColor = true;
            EditItem.Click += EditItem_Click;
            // 
            // ShowWareHouseItemsUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(EditItem);
            Controls.Add(AddItemPanel);
            Controls.Add(AddNewItem);
            Controls.Add(Back);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(WareHouseItems);
            Name = "ShowWareHouseItemsUserControl";
            Size = new Size(1115, 431);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label WareHouseItems;
        private TextBox textBox1;
        private Label label1;
        private DataGridView dataGridView1;
        private Button Back;
        private Button AddNewItem;
        private Panel AddItemPanel;
        private Button EditItem;
    }
}
