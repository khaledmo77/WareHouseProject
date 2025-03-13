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
            SupplierCombo = new ComboBox();
            supplierIdLabelCombo = new Label();
            wareHouseIDLabelCombo = new Label();
            wareHouseCombo = new ComboBox();
            OrderDateLabel = new Label();
            OrdermonthCalendar1 = new MonthCalendar();
            ItemNameLabelCombo = new Label();
            ItemIdCombo = new ComboBox();
            ProductionmonthCalendar2 = new MonthCalendar();
            ProductionDateLabel = new Label();
            ExpirymonthCalendar1 = new MonthCalendar();
            ExpiryDateLabel = new Label();
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
            nameLable2.Location = new Point(28, 136);
            nameLable2.Name = "nameLable2";
            nameLable2.Size = new Size(66, 20);
            nameLable2.TabIndex = 5;
            nameLable2.Text = "Location";
            // 
            // save
            // 
            save.Location = new Point(484, 94);
            save.Name = "save";
            save.Size = new Size(112, 75);
            save.TabIndex = 6;
            save.Text = "Save";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // cancel
            // 
            cancel.Location = new Point(484, 191);
            cancel.Name = "cancel";
            cancel.Size = new Size(112, 81);
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
            // SupplierCombo
            // 
            SupplierCombo.FormattingEnabled = true;
            SupplierCombo.Location = new Point(168, 128);
            SupplierCombo.Name = "SupplierCombo";
            SupplierCombo.Size = new Size(259, 28);
            SupplierCombo.TabIndex = 10;
            SupplierCombo.Visible = false;
            // 
            // supplierIdLabelCombo
            // 
            supplierIdLabelCombo.AutoSize = true;
            supplierIdLabelCombo.Location = new Point(18, 136);
            supplierIdLabelCombo.Name = "supplierIdLabelCombo";
            supplierIdLabelCombo.Size = new Size(83, 20);
            supplierIdLabelCombo.TabIndex = 11;
            supplierIdLabelCombo.Text = "Supplier ID";
            supplierIdLabelCombo.Visible = false;
            // 
            // wareHouseIDLabelCombo
            // 
            wareHouseIDLabelCombo.AutoSize = true;
            wareHouseIDLabelCombo.Location = new Point(28, 240);
            wareHouseIDLabelCombo.Name = "wareHouseIDLabelCombo";
            wareHouseIDLabelCombo.Size = new Size(102, 20);
            wareHouseIDLabelCombo.TabIndex = 13;
            wareHouseIDLabelCombo.Text = "WareHouse id";
            wareHouseIDLabelCombo.Visible = false;
            // 
            // wareHouseCombo
            // 
            wareHouseCombo.FormattingEnabled = true;
            wareHouseCombo.Location = new Point(168, 237);
            wareHouseCombo.Name = "wareHouseCombo";
            wareHouseCombo.Size = new Size(259, 28);
            wareHouseCombo.TabIndex = 12;
            wareHouseCombo.Visible = false;
            // 
            // OrderDateLabel
            // 
            OrderDateLabel.AutoSize = true;
            OrderDateLabel.Location = new Point(695, 256);
            OrderDateLabel.Name = "OrderDateLabel";
            OrderDateLabel.Size = new Size(101, 20);
            OrderDateLabel.TabIndex = 14;
            OrderDateLabel.Text = "Date of Order";
            OrderDateLabel.Visible = false;
            // 
            // OrdermonthCalendar1
            // 
            OrdermonthCalendar1.Location = new Point(814, 240);
            OrdermonthCalendar1.Name = "OrdermonthCalendar1";
            OrdermonthCalendar1.TabIndex = 15;
            OrdermonthCalendar1.Visible = false;
            // 
            // ItemNameLabelCombo
            // 
            ItemNameLabelCombo.AutoSize = true;
            ItemNameLabelCombo.Location = new Point(29, 82);
            ItemNameLabelCombo.Name = "ItemNameLabelCombo";
            ItemNameLabelCombo.Size = new Size(83, 20);
            ItemNameLabelCombo.TabIndex = 17;
            ItemNameLabelCombo.Text = "Item Name";
            ItemNameLabelCombo.Visible = false;
            ItemNameLabelCombo.Click += ItemIdLabelCombo_Click;
            // 
            // ItemIdCombo
            // 
            ItemIdCombo.FormattingEnabled = true;
            ItemIdCombo.Location = new Point(165, 82);
            ItemIdCombo.Name = "ItemIdCombo";
            ItemIdCombo.Size = new Size(259, 28);
            ItemIdCombo.TabIndex = 16;
            ItemIdCombo.Visible = false;
            // 
            // ProductionmonthCalendar2
            // 
            ProductionmonthCalendar2.Location = new Point(814, 15);
            ProductionmonthCalendar2.Name = "ProductionmonthCalendar2";
            ProductionmonthCalendar2.TabIndex = 19;
            ProductionmonthCalendar2.Visible = false;
            // 
            // ProductionDateLabel
            // 
            ProductionDateLabel.AutoSize = true;
            ProductionDateLabel.Location = new Point(679, 57);
            ProductionDateLabel.Name = "ProductionDateLabel";
            ProductionDateLabel.Size = new Size(117, 20);
            ProductionDateLabel.TabIndex = 18;
            ProductionDateLabel.Text = "Production Date";
            ProductionDateLabel.Visible = false;
            // 
            // ExpirymonthCalendar1
            // 
            ExpirymonthCalendar1.Location = new Point(162, 277);
            ExpirymonthCalendar1.Name = "ExpirymonthCalendar1";
            ExpirymonthCalendar1.TabIndex = 21;
            ExpirymonthCalendar1.Visible = false;
            // 
            // ExpiryDateLabel
            // 
            ExpiryDateLabel.AutoSize = true;
            ExpiryDateLabel.Location = new Point(26, 298);
            ExpiryDateLabel.Name = "ExpiryDateLabel";
            ExpiryDateLabel.Size = new Size(103, 20);
            ExpiryDateLabel.TabIndex = 20;
            ExpiryDateLabel.Text = "Date of Expiry";
            ExpiryDateLabel.Visible = false;
            // 
            // WarehouseFormControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ExpirymonthCalendar1);
            Controls.Add(ExpiryDateLabel);
            Controls.Add(ProductionmonthCalendar2);
            Controls.Add(ProductionDateLabel);
            Controls.Add(ItemNameLabelCombo);
            Controls.Add(ItemIdCombo);
            Controls.Add(OrdermonthCalendar1);
            Controls.Add(OrderDateLabel);
            Controls.Add(wareHouseIDLabelCombo);
            Controls.Add(wareHouseCombo);
            Controls.Add(supplierIdLabelCombo);
            Controls.Add(SupplierCombo);
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
            Size = new Size(1095, 625);
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
        private ComboBox SupplierCombo;
        private Label supplierIdLabelCombo;
        private Label wareHouseIDLabelCombo;
        private ComboBox wareHouseCombo;
        private Label OrderDateLabel;
        private MonthCalendar OrdermonthCalendar1;
        private Label ItemNameLabelCombo;
        private ComboBox ItemIdCombo;
        private MonthCalendar ProductionmonthCalendar2;
        private Label ProductionDateLabel;
        private MonthCalendar ExpirymonthCalendar1;
        private Label ExpiryDateLabel;
    }
}
