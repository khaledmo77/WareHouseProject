namespace WareHouseProject
{
    partial class SuppliersUserControl
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
            AddSup = new Button();
            EditSup = new Button();
            panel1 = new Panel();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(59, 13);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(634, 175);
            dataGridView1.TabIndex = 0;
            // 
            // AddSup
            // 
            AddSup.Location = new Point(160, 210);
            AddSup.Name = "AddSup";
            AddSup.Size = new Size(148, 57);
            AddSup.TabIndex = 1;
            AddSup.Text = "ADD Supplier";
            AddSup.UseVisualStyleBackColor = true;
            AddSup.Click += AddSup_Click;
            // 
            // EditSup
            // 
            EditSup.Location = new Point(448, 212);
            EditSup.Name = "EditSup";
            EditSup.Size = new Size(143, 55);
            EditSup.TabIndex = 2;
            EditSup.Text = "Edit Supplier";
            EditSup.UseVisualStyleBackColor = true;
            EditSup.Click += EditSup_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(20, 13);
            panel1.Name = "panel1";
            panel1.Size = new Size(932, 440);
            panel1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(766, 75);
            button1.Name = "button1";
            button1.Size = new Size(94, 51);
            button1.TabIndex = 4;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BackBtn_Click;
            // 
            // SuppliersUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(EditSup);
            Controls.Add(AddSup);
            Controls.Add(dataGridView1);
            Name = "SuppliersUserControl";
            Size = new Size(1009, 461);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button AddSup;
        private Button EditSup;
        private Panel panel1;
        private Button button1;
    }
}
