using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WareHouseProject.Models;
using Microsoft.EntityFrameworkCore;
namespace WareHouseProject
{
    public partial class WarehouseFormControl : UserControl
    {
        private readonly WarehouseManagementContext _context = new WarehouseManagementContext(new Microsoft.EntityFrameworkCore.DbContextOptions<WarehouseManagementContext>());
        public event EventHandler WarehouseSaved;
        public event EventHandler CloseRequested;

        private Warehouse _warehouse;
        public enum FormMode { AddWarehouse, AddItem, EditItem, AddSupplier, EditSupplier, AddCustomer, EditCustomer, AddSupplyOrder, EditSupplyOrder } // Define modes
        private FormMode _mode;
        public WarehouseFormControl(FormMode mode)
        {
            InitializeComponent();
            _mode = mode;
            updateLayout();
        }
        private void updateLayout()
        {
            if (_mode == FormMode.AddItem || _mode == FormMode.EditItem)
            {
                QuantatyBox.Visible = true;
                QuantityLabel.Visible = true;
                AddLable.Text = _mode == FormMode.AddItem ? "Add Item" : "Edit Item";
                nameLable.Text = "Item Name";
                nameLable2.Text = "Price";
            }
            else if (_mode == FormMode.AddWarehouse)
            {
                AddLable.Text = "Add Warehouse";
                nameLable.Text = "Warehouse Name";
                nameLable2.Text = "Location";
            }
            else if (_mode == FormMode.AddSupplier || _mode == FormMode.EditSupplier)
            {
                QuantatyBox.Visible = true;
                QuantityLabel.Visible = true;
                QuantityLabel.Text = "Phone Number";
                AddLable.Text = _mode == FormMode.AddSupplier ? "Add Supplier" : "Edit Supplier";
                nameLable.Text = "Supplier Name";
                nameLable2.Text = "Location";
            }
            else if (_mode == FormMode.AddCustomer || _mode == FormMode.EditCustomer)
            {
                QuantatyBox.Visible = true;
                QuantityLabel.Visible = true;
                QuantityLabel.Text = "Phone Number";
                AddLable.Text = _mode == FormMode.AddCustomer ? "Add Customer" : "Edit Customer";
                nameLable.Text = "Customer Name";
                nameLable2.Text = "Location";
            }
            else if (_mode == FormMode.AddSupplyOrder || _mode == FormMode.EditSupplyOrder)
            {
                //quantity
                QuantatyBox.Visible = true;
                //dates
                OrderDateLabel.Visible = true;
                OrdermonthCalendar1.Visible = true;
                ExpiryDateLabel.Visible = true;
              ExpirymonthCalendar1.Visible = true;
                ProductionDateLabel.Visible = true;
              ProductionmonthCalendar2.Visible = true;
                //wareHouse combobox data
                wareHouseCombo.Visible = true;
                wareHouseCombo.DataSource = _context.Warehouses.ToList();
                wareHouseCombo.DisplayMember = "Name";
                wareHouseCombo.ValueMember = "WarehouseId";
                wareHouseIDLabelCombo.Visible = true;
                //item combobox data
                ItemIdCombo.Visible = true;
                ItemNameLabelCombo.Visible = true;
                NameTextBox.Visible = false;
                LocationOrPriceTextBox.Visible = false;
                ItemIdCombo.DataSource = _context.Items.ToList();
                ItemIdCombo.DisplayMember = "Name";
                ItemIdCombo.ValueMember = "ItemId";
                //supplier combobox data
                supplierIdLabelCombo.Visible = true;
                SupplierCombo.Visible = true;
                SupplierCombo.DataSource = _context.Suppliers.ToList();
                SupplierCombo.DisplayMember = "Name";
                SupplierCombo.ValueMember = "SupplierId";
                QuantityLabel.Visible = true;
                QuantityLabel.Text = "Quantity";
                AddLable.Text = _mode == FormMode.AddSupplyOrder ? "Add Supply Order" : "Edit Supply Order";
                nameLable.Visible =false;
                nameLable2.Visible=false;
            }
        }
        //private void LoadData()
        //{
        //    // Load Suppliers into ComboBox
         
        ////    SupplierComboBox.DisplayMember = "Name";  // Show Supplier Name
        // //   SupplierComboBox.ValueMember = "Id";  // Use Supplier ID internally

        //    // Load Products into ComboBox
     
        //  //  ProductComboBox.DisplayMember = "Name";  // Show Product Name
        ////    ProductComboBox.ValueMember = "Id";  // Use Product ID internally
        //}

        private void save_Click(object sender, EventArgs e)
        {
            if (_mode == FormMode.AddWarehouse)
            {
                SaveWarehouse();
            }
            else if (_mode == FormMode.AddItem || _mode == FormMode.EditItem)
            {
                SaveItem(_warehouse);
            }
            else if (_mode == FormMode.AddSupplier || _mode == FormMode.EditSupplier)
            {
                SaveSupplier();
            }
            else if (_mode == FormMode.AddCustomer || _mode == FormMode.EditCustomer)
            {
                saveCustomer();
            }
            else if (_mode == FormMode.AddSupplyOrder || _mode == FormMode.EditSupplyOrder)
            {
                SaveSupplyOrder();
            }
        }
        private int? editingSupplyOrderId = null;
     // Nullable so we can check if it's new

        private void SaveSupplyOrder()
        {
            if (SupplierCombo.SelectedValue == null || wareHouseCombo.SelectedValue == null)
            {
                MessageBox.Show("Please select a valid Supplier and Warehouse.");
                return;
            }

            if (ItemIdCombo.SelectedValue == null)
            {
                MessageBox.Show("Please select a valid Product.");
                return;
            }

            if (!int.TryParse(QuantatyBox.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            // Get selected values
            int supplierId = (int)SupplierCombo.SelectedValue;
            int warehouseId = (int)wareHouseCombo.SelectedValue;
            int itemId = (int)ItemIdCombo.SelectedValue;
            DateTime orderDate = OrdermonthCalendar1.SelectionStart;
            DateTime expiryDate = ExpirymonthCalendar1.SelectionStart;
            DateTime productionDate = ProductionmonthCalendar2.SelectionStart;

            if (editingSupplyOrderId.HasValue)
            {
                var existingSupplyOrder = _context.SupplyOrders.Find(editingSupplyOrderId.Value);
                if (existingSupplyOrder == null)
                {
                    MessageBox.Show("Error: Supply order not found.");
                    return;
                }

                // ✅ Update existing order details
                existingSupplyOrder.OrderDate = orderDate;
                existingSupplyOrder.WarehouseId = warehouseId;
                existingSupplyOrder.SupplierId = supplierId;

                var existingSupplyOrderDetail = _context.SupplyOrderDetails
                    .FirstOrDefault(d => d.SupplyOrderId == existingSupplyOrder.SupplyOrderId && d.ItemId == itemId);

                if (existingSupplyOrderDetail != null)
                {
                    // ✅ Update existing item details
                    existingSupplyOrderDetail.Quantity = quantity;
                    existingSupplyOrderDetail.ExpiryDate = expiryDate;
                    existingSupplyOrderDetail.ProductionDate = productionDate;
                }
                else
                {
                    // ✅ If the item was not found, add a new one
                    var newSupplyOrderDetail = new SupplyOrderDetail
                    {
                        SupplyOrderId = existingSupplyOrder.SupplyOrderId,
                        ItemId = itemId,
                        Quantity = quantity,
                        ExpiryDate = expiryDate,
                        ProductionDate = productionDate
                    };
                    _context.SupplyOrderDetails.Add(newSupplyOrderDetail);
                }
            }
            else // ✅ If it's a new order, create a new instance
            {
                var newSupplyOrder = new SupplyOrder
                {
                    OrderDate = orderDate,
                    WarehouseId = warehouseId,
                    SupplierId = supplierId
                };

                _context.SupplyOrders.Add(newSupplyOrder);
                _context.SaveChanges();

                var newSupplyOrderDetail = new SupplyOrderDetail
                {
                    SupplyOrderId = newSupplyOrder.SupplyOrderId,
                    ItemId = itemId,
                    Quantity = quantity,
                    ExpiryDate = expiryDate,
                    ProductionDate = productionDate
                };

                _context.SupplyOrderDetails.Add(newSupplyOrderDetail);
            }

            _context.SaveChanges();
            WarehouseSaved?.Invoke(this, EventArgs.Empty);

            // Instead of Dispose(), close the form or reset fields
            this.Dispose(); // If you want to close the form after saving
        }

        public void setSupplyOrderForEdit(SupplyOrderDTO supplyOrder)
        {
            if (supplyOrder == null) return;
  
            editingSupplyOrderId = supplyOrder.SupplyOrderId;
            // Ensure ComboBoxes are populated before setting values
            LoadComboBoxes();

            // Set values for ComboBoxes

            SupplierCombo.SelectedValue = supplyOrder.SupplierID;
            wareHouseCombo.SelectedValue = supplyOrder.WarehouseID;

            // Set Dates
            OrdermonthCalendar1.SetDate(supplyOrder.OrderDate);



            if (supplyOrder.Items.Any())
            {
                var firstItem = supplyOrder.Items.FirstOrDefault();
                ExpirymonthCalendar1.SetDate(firstItem.ExpiryDate);
                ProductionmonthCalendar2.SetDate(firstItem.ProductionDate);
                ItemIdCombo.SelectedValue = firstItem.ItemID;
                QuantatyBox.Text = firstItem.Quantity.ToString();
            }

        }
        public void LoadComboBoxes()
        {
            // Load suppliers
            SupplierCombo.DataSource = _context.Suppliers.ToList();
            SupplierCombo.DisplayMember = "SupplierName";  // Adjust based on your DB column name
            SupplierCombo.ValueMember = "SupplierId";

            // Load warehouses
            wareHouseCombo.DataSource = _context.Warehouses.ToList();
            wareHouseCombo.DisplayMember = "WarehouseName";  // Adjust based on your DB column name
            wareHouseCombo.ValueMember = "WarehouseId";

            // Load items
            ItemIdCombo.DataSource = _context.Items.ToList();
            ItemIdCombo.DisplayMember = "ItemName";  // Adjust based on your DB column name
            ItemIdCombo.ValueMember = "ItemId";
        }

        //public void SetItemForEdit(WarehouseItem item, Warehouse warehouse)
        //{
        //    _warehouse = warehouse;

        //    if (item != null && item.Item != null)
        //    {
        //        _mode = FormMode.EditItem;
        //        NameTextBox.Text = item.Item?.Name;
        //        LocationOrPriceTextBox.Text = item.Item?.Price.ToString();
        //        QuantatyBox.Text = item.Quantity.ToString();
        //    }
        //}

        private void saveCustomer()
        {
            string customerName = NameTextBox.Text.Trim();
            string location = LocationOrPriceTextBox.Text.Trim();
            int phoneNumber;
            if (string.IsNullOrWhiteSpace(customerName) ||
                string.IsNullOrWhiteSpace(location) ||
                !int.TryParse(QuantatyBox.Text, out phoneNumber))
            {
                MessageBox.Show("Please enter a valid customer name, location, and phone number.");
                return;
            }
            if (_mode == FormMode.AddCustomer)
            {
                // Ensure customer doesn't already exist
                var existingCustomer = _context.Customers.AsNoTracking().FirstOrDefault(s => s.Name == customerName);

                Customer newCustomer = new Customer
                {
                    Name = customerName,
                    Location = location,
                    PhoneNumber = phoneNumber.ToString()
                };
                _context.Customers.Add(newCustomer);
            }
            else if (_mode == FormMode.EditCustomer)
            {
                var existingCustomer = _context.Customers.FirstOrDefault(s => s.Name == customerName);
                if (existingCustomer == null)
                {
                    MessageBox.Show("Customer not found for editing.");
                    return;
                }
                // Update customer details
                existingCustomer.Location = location;
                existingCustomer.PhoneNumber = phoneNumber.ToString();
                _context.Customers.Update(existingCustomer);
            }
            _context.SaveChanges();
            WarehouseSaved?.Invoke(this, EventArgs.Empty);
            this.Dispose();
        }
        private void SaveSupplier()
        {
            string supplierName = NameTextBox.Text.Trim();
            string location = LocationOrPriceTextBox.Text.Trim();
            int phoneNumber;

            if (string.IsNullOrWhiteSpace(supplierName) ||
                string.IsNullOrWhiteSpace(location) ||
                !int.TryParse(QuantatyBox.Text, out phoneNumber))
            {
                MessageBox.Show("Please enter a valid supplier name, location, and phone number.");
                return;
            }

            if (_mode == FormMode.AddSupplier)
            {
                // Ensure supplier doesn't already exist
                var existingSupplier = _context.Suppliers.AsNoTracking().FirstOrDefault(s => s.Name == supplierName);

                if (existingSupplier != null)
                {
                    MessageBox.Show("A supplier with this name already exists. Try a different name.");
                    return;
                }

                Supplier newSupplier = new Supplier
                {
                    Name = supplierName,
                    Location = location,
                    PhoneNumber = phoneNumber.ToString()
                };

                _context.Suppliers.Add(newSupplier);
            }
            else if (_mode == FormMode.EditSupplier)
            {
                var existingSupplier = _context.Suppliers.FirstOrDefault(s => s.Name == supplierName);

                if (existingSupplier == null)
                {
                    MessageBox.Show("Supplier not found for editing.");
                    return;
                }

                // Update supplier details
                existingSupplier.Location = location;
                existingSupplier.PhoneNumber = phoneNumber.ToString();
                _context.Suppliers.Update(existingSupplier);
            }

            _context.SaveChanges();
            WarehouseSaved?.Invoke(this, EventArgs.Empty);
            this.Dispose();
        }


        //private void save_Click(object sender, EventArgs e)
        //{
        //    string warehouseName = NameTextBox.Text;
        //    string warehouseLocation = LocationTextBox.Text;

        //    int capacity;
        //    if (string.IsNullOrWhiteSpace(warehouseName) || string.IsNullOrWhiteSpace(warehouseLocation))
        //    {

        //        MessageBox.Show("Please enter valid data.");
        //        return;
        //    }
        //    if (_warehouse == null)
        //    {
        //        var warehouse = new Warehouse
        //        {
        //            Name = warehouseName,
        //            Location = warehouseLocation
        //        };
        //        _context.Warehouses.Add(warehouse);


        //    }
        //    else // Edit existing warehouse
        //    {
        //        _warehouse.Name = warehouseName;
        //        _warehouse.Location = warehouseLocation;
        //        _context.Warehouses.Update(_warehouse);
        //    }

        //    _context.SaveChanges();


        //    WarehouseSaved?.Invoke(this, EventArgs.Empty);
        //    this.Dispose();
        //    //   _context.Warehouses.Add(warehouse);
        //    // _context.SaveChanges(); 

        //}
        private void SaveWarehouse()
        {
            string warehouseName = NameTextBox.Text;
            string warehouseLocation = LocationOrPriceTextBox.Text;

            if (string.IsNullOrWhiteSpace(warehouseName) || string.IsNullOrWhiteSpace(warehouseLocation))
            {
                MessageBox.Show("Please enter valid data for the warehouse.");
                return;
            }

            if (_warehouse == null)
            {
                var warehouse = new Warehouse
                {
                    Name = warehouseName,
                    Location = warehouseLocation
                };
                _context.Warehouses.Add(warehouse);
            }
            else
            {
                _warehouse.Name = warehouseName;
                _warehouse.Location = warehouseLocation;
                _context.Warehouses.Update(_warehouse);
            }

            _context.SaveChanges();
            WarehouseSaved?.Invoke(this, EventArgs.Empty);
            this.Dispose();
        }

        //private void SaveItem()
        //{

        //    string itemName = NameTextBox.Text;
        //    string priceText = LocationOrPriceTextBox.Text;
        //    decimal price;
        //    int quantity=Convert.ToInt32( QuantatyBox.Text);
        //    if (string.IsNullOrWhiteSpace(itemName) || !decimal.TryParse(priceText, out price))
        //    {
        //        MessageBox.Show("Please enter a valid item name and price.");
        //        return;
        //    }
        //    if (_warehouse == null)
        //    {
        //        MessageBox.Show("No warehouse selected. Please select a warehouse before adding an item.");
        //        return;
        //    }
        //    var item = _context.Items.FirstOrDefault(i => i.Name == itemName);
        //    if (item == null)
        //    {
        //        item = new Item
        //        {
        //            Name = itemName,
        //            Price = price
        //        };
        //        _context.Items.Add(item);
        //        _context.SaveChanges();
        //    }
        //    else
        //    {
        //        item.Price = price; // Update price if item exists
        //        _context.Items.Update(item);
        //    }
        //    var warehouseItem = _context.WarehouseItems
        //         .FirstOrDefault(wi => wi.WarehouseId == _warehouse.WarehouseId && wi.ItemId == item.ItemId);
        //    if (warehouseItem == null)
        //    {
        //        warehouseItem = new WarehouseItem
        //        {
        //            WarehouseId = _warehouse.WarehouseId,
        //            ItemId = item.ItemId,
        //            Quantity = quantity
        //        };
        //        _context.WarehouseItems.Add(warehouseItem);
        //    }
        //    else
        //    {
        //        warehouseItem.Quantity += quantity; // Increase quantity if it already exists
        //        _context.WarehouseItems.Update(warehouseItem);
        //    }
        //    _context.SaveChanges();

        //    WarehouseSaved?.Invoke(this, EventArgs.Empty);
        //    this.Dispose();
        //    // Since the second textbox is used for price


        //}
        private void SaveItem(Warehouse warehouse)
        {
            if (warehouse == null)
            {
                MessageBox.Show("No warehouse selected. Please select a warehouse before adding an item.");
                return;
            }

            string itemName = NameTextBox.Text;
            string priceText = LocationOrPriceTextBox.Text;
            int quantity;

            if (string.IsNullOrWhiteSpace(itemName) || !decimal.TryParse(priceText, out decimal price) || !int.TryParse(QuantatyBox.Text, out quantity))
            {
                MessageBox.Show("Please enter a valid item name, price, and quantity.");
                return;
            }

            // Check if the item exists
            var item = _context.Items.AsNoTracking().FirstOrDefault(i => i.Name == itemName);
            if (item == null)
            {
                item = new Item { Name = itemName, Price = price };
                _context.Items.Add(item);
                _context.SaveChanges(); // Save to get ItemId
            }
            else
            {
                item.Price = price; // Update price if item exists
                _context.Items.Update(item);
            }

            // Ensure the warehouse ID is set correctly
            var warehouseItem = _context.WarehouseItems
                .FirstOrDefault(wi => wi.WarehouseId == warehouse.WarehouseId && wi.ItemId == item.ItemId);

            if (warehouseItem == null)
            {
                warehouseItem = new WarehouseItem
                {
                    WarehouseId = warehouse.WarehouseId, // Ensure warehouse ID is assigned
                    ItemId = item.ItemId,
                    Quantity = quantity
                };
                _context.WarehouseItems.Add(warehouseItem);
            }
            else
            {
                warehouseItem.Quantity = _mode == FormMode.EditItem ? quantity : warehouseItem.Quantity + quantity; // Increase quantity if it already exists
                _context.WarehouseItems.Update(warehouseItem);
            }

            _context.SaveChanges();
            WarehouseSaved?.Invoke(this, EventArgs.Empty);
            this.Dispose();
        }
        public void SetItemForEdit(WarehouseItem item, Warehouse warehouse)
        {
            _warehouse = warehouse;

            if (item != null && item.Item != null)
            {
                _mode = FormMode.EditItem;
                NameTextBox.Text = item.Item?.Name;
                LocationOrPriceTextBox.Text = item.Item?.Price.ToString();
                QuantatyBox.Text = item.Quantity.ToString();
            }
        }
        public void setSupplierForEdit(Supplier supplier)
        {
            if (supplier != null)
            {
                NameTextBox.Text = supplier.Name;
                LocationOrPriceTextBox.Text = supplier.Location;
                QuantatyBox.Text = supplier.PhoneNumber;
            }
        }
        public void setCustomerForEdit(Customer customer)
        {
            if (customer != null)
            {
                NameTextBox.Text = customer.Name;
                LocationOrPriceTextBox.Text = customer.Location;
                QuantatyBox.Text = customer.PhoneNumber;
            }
        }


        private void cancel_Click(object sender, EventArgs e)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);

        }
        public void SetWarehouse(Warehouse warehouse)
        {
            _warehouse = warehouse;
            if (_warehouse != null)
            {
                NameTextBox.Text = _warehouse.Name;
                LocationOrPriceTextBox.Text = _warehouse.Location;
            }
        }
        //public void SetWarehouseItem(WarehouseItem item)
        //{
        //    if (item != null)
        //    {
        //        // Editing existing item
        //        txtItemName.Text = item.Item != null ? item.Item.Name : "";
        //        LocationOrPriceTextBox.Text = item.Item != null ? item.Item.Price.ToString() : "";
        //        txtQuantity.Text = item.Quantity.ToString();
        //        hiddenItemId.Value = item.ItemId.ToString(); // Store ID if needed
        //    }
        //    else
        //    {
        //        // Adding new item
        //        txtItemName.Text = "";
        //        txtQuantity.Text = "";
        //        hiddenItemId.Value = ""; // Reset hidden ID
        //    }
        //}

        public void SetWarehouseAddItem(Warehouse warehouse)
        {
            _warehouse = warehouse;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ItemIdLabelCombo_Click(object sender, EventArgs e)
        {

        }

    }
}
