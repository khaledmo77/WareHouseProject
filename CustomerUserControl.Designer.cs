namespace WareHouseProject
{
    partial class CustomerUserControl
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
            AddCustomer = new Button();
            EditCustomer = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(156, 29);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(567, 188);
            dataGridView1.TabIndex = 0;
            // 
            // AddCustomer
            // 
            AddCustomer.Location = new Point(210, 246);
            AddCustomer.Name = "AddCustomer";
            AddCustomer.Size = new Size(148, 45);
            AddCustomer.TabIndex = 1;
            AddCustomer.Text = "Add Customer";
            AddCustomer.UseVisualStyleBackColor = true;
            AddCustomer.Click += AddCustomer_Click;
            // 
            // EditCustomer
            // 
            EditCustomer.Location = new Point(524, 246);
            EditCustomer.Name = "EditCustomer";
            EditCustomer.Size = new Size(144, 45);
            EditCustomer.TabIndex = 2;
            EditCustomer.Text = "Edit Customer";
            EditCustomer.UseVisualStyleBackColor = true;
            EditCustomer.Click += EditCustomer_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(21, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(837, 344);
            panel1.TabIndex = 3;
            // 
            // CustomerUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(EditCustomer);
            Controls.Add(AddCustomer);
            Controls.Add(dataGridView1);
            Name = "CustomerUserControl";
            Size = new Size(893, 362);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button AddCustomer;
        private Button EditCustomer;
        private Panel panel1;
    }
}
