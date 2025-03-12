namespace WareHouseProject
{
    partial class WarehouseFormControl
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
            AddLable = new Label();
            NameTextBox = new TextBox();
            LocationOrPriceTextBox = new TextBox();
            nameLable = new Label();
            nameLable2 = new Label();
            save = new Button();
            cancel = new Button();
            QuantityLabel = new Label();
            QuantatyBox = new TextBox();
            SuspendLayout();
            // 
            // AddLable
            // 
            AddLable.AutoSize = true;
            AddLable.Location = new Point(219, 19);
            AddLable.Name = "AddLable";
            AddLable.Size = new Size(121, 20);
            AddLable.TabIndex = 0;
            AddLable.Text = "ADD WareHouse";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(168, 79);
            NameTextBox.Multiline = true;
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(259, 34);
            NameTextBox.TabIndex = 1;
            // 
            // LocationOrPriceTextBox
            // 
            LocationOrPriceTextBox.Location = new Point(168, 133);
            LocationOrPriceTextBox.Multiline = true;
            LocationOrPriceTextBox.Name = "LocationOrPriceTextBox";
            LocationOrPriceTextBox.Size = new Size(259, 36);
            LocationOrPriceTextBox.TabIndex = 2;
            // 
            // nameLable
            // 
            nameLable.AutoSize = true;
            nameLable.Location = new Point(18, 82);
            nameLable.Name = "nameLable";
            nameLable.Size = new Size(129, 20);
            nameLable.TabIndex = 4;
            nameLable.Text = "WareHouse Name";
            // 
            // nameLable2
            // 
            nameLable2.AutoSize = true;
            nameLable2.Location = new Point(28, 133);
            nameLable2.Name = "nameLable2";
            nameLable2.Size = new Size(66, 20);
            nameLable2.TabIndex = 5;
            nameLable2.Text = "Location";
            // 
            // save
            // 
            save.Location = new Point(129, 252);
            save.Name = "save";
            save.Size = new Size(94, 29);
            save.TabIndex = 6;
            save.Text = "Save";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // cancel
            // 
            cancel.Location = new Point(360, 252);
            cancel.Name = "cancel";
            cancel.Size = new Size(94, 29);
            cancel.TabIndex = 7;
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += cancel_Click;
            // 
            // QuantityLabel
            // 
            QuantityLabel.AutoSize = true;
            QuantityLabel.Location = new Point(29, 191);
            QuantityLabel.Name = "QuantityLabel";
            QuantityLabel.Size = new Size(65, 20);
            QuantityLabel.TabIndex = 9;
            QuantityLabel.Text = "Quantity";
            QuantityLabel.Visible = false;
            // 
            // QuantatyBox
            // 
            QuantatyBox.Location = new Point(168, 188);
            QuantatyBox.Multiline = true;
            QuantatyBox.Name = "QuantatyBox";
            QuantatyBox.Size = new Size(259, 34);
            QuantatyBox.TabIndex = 8;
            QuantatyBox.Visible = false;
            QuantatyBox.TextChanged += textBox1_TextChanged;
            // 
            // WarehouseFormControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(QuantityLabel);
            Controls.Add(QuantatyBox);
            Controls.Add(cancel);
            Controls.Add(save);
            Controls.Add(nameLable2);
            Controls.Add(nameLable);
            Controls.Add(LocationOrPriceTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(AddLable);
            Name = "WarehouseFormControl";
            Size = new Size(572, 305);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AddLable;
        private TextBox NameTextBox;
        private TextBox LocationOrPriceTextBox;
        private Label nameLable;
        private Label nameLable2;
        private Button save;
        private Button cancel;
        private Label QuantityLabel;
        private TextBox QuantatyBox;
    }
}
