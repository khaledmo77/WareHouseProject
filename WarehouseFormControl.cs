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
namespace WareHouseProject
{
    public partial class WarehouseFormControl : UserControl
    {
        private readonly WarehouseManagementContext _context = new WarehouseManagementContext(new Microsoft.EntityFrameworkCore.DbContextOptions<WarehouseManagementContext>());
        public event EventHandler WarehouseSaved;
        public event EventHandler CloseRequested;
        private Warehouse _warehouse;
        public enum FormMode { AddWarehouse, AddItem, EditItem } // Define modes
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
        }
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
            var item = _context.Items.FirstOrDefault(i => i.Name == itemName);
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
        public void SetItemForEdit(WarehouseItem item)
        {
            if (item != null)
            {
                _mode = FormMode.EditItem;
                NameTextBox.Text = item.Item?.Name;
                LocationOrPriceTextBox.Text = item.Item?.Price.ToString();
                QuantatyBox.Text = item.Quantity.ToString();
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
    }
}
