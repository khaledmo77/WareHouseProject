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
    public partial class ShowWareHouseItemsUserControl : UserControl
    {
        private readonly WarehouseManagementContext _context = new WarehouseManagementContext(new Microsoft.EntityFrameworkCore.DbContextOptions<WarehouseManagementContext>());
        public event EventHandler WarehouseSaved;
        public event EventHandler CloseRequested;
        private Warehouse _warehouse;
        private int _warehouseID;
        public ShowWareHouseItemsUserControl(int wareHouseID)
        {
            InitializeComponent();
            AddItemPanel.Visible = false;
            _warehouseID = wareHouseID;
            LoadItemDetails(_warehouseID);
        }
        private void LoadItemDetails(int wareHouseID)
        {
            _warehouse = _context.Warehouses.FirstOrDefault(w => w.WarehouseId == wareHouseID);

            var items = _context.WarehouseItems
                .Where(wi => wi.WarehouseId == wareHouseID)
                .Select(wi => new
                {
                    WarehouseName = wi.Warehouse != null ? wi.Warehouse.Name : "Unknown Warehouse",
                    ItemName = wi.Item != null ? wi.Item.Name : "Unknown Item",
                    wi.Quantity,
                    wi.ItemId
                })
                .ToList();

            // Ensure the DataGridView updates properly
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = items;
            dataGridView1.Refresh();
        }



        private void WareHouseItems_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            WarehouseSaved?.Invoke(this, EventArgs.Empty); // Trigger refresh request before closing
            CloseRequested?.Invoke(this, EventArgs.Empty); // Notify parent to close this control
        }

        private void AddNewItem_Click(object sender, EventArgs e)
        {
            AddItemPanel.Visible = true;
            AddItemPanel.BringToFront();
            WarehouseFormControl warehouseFormControl = new WarehouseFormControl(WarehouseFormControl.FormMode.AddItem);
            warehouseFormControl.WarehouseSaved += WarehouseForm_WarehouseSaved;
            warehouseFormControl.CloseRequested += WarehouseForm_CloseRequested;
            warehouseFormControl.SetWarehouseAddItem(_warehouse);
            AddItemPanel.Controls.Clear(); // Clear previous controls
            AddItemPanel.Controls.Add(warehouseFormControl);
            warehouseFormControl.Dock = DockStyle.Fill;

        }
        private void WarehouseForm_WarehouseSaved(object sender, EventArgs e)
        {
            MessageBox.Show("Item saved successfully!");
            AddItemPanel.Visible = false;
            dataGridView1.Refresh();
            LoadItemDetails(_warehouseID); // Refresh DataGridView
        }
        private void WarehouseForm_CloseRequested(object sender, EventArgs e)
        {
            AddItemPanel.Visible = false;
        }
        private void EditItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.");
                return;
            }

            // Check if "ItemId" column exists in DataGridView before accessing it
            if (!dataGridView1.Columns.Contains("ItemId"))
            {
                MessageBox.Show("ItemId column not found. Ensure the correct data is loaded.");
                return;
            }

            int itemIdColumnIndex = dataGridView1.Columns["ItemId"].Index;
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[itemIdColumnIndex].Value);

            var warehouseItem = _context.WarehouseItems.Find(id);

            if (warehouseItem == null)
            {
                MessageBox.Show("Selected item not found in the database.");
                return;
            }

            AddItemPanel.Visible = true;
            AddItemPanel.BringToFront();

            // Ensure the form supports editing
            WarehouseFormControl warehouseFormControl = new WarehouseFormControl(WarehouseFormControl.FormMode.EditItem);

            warehouseFormControl.WarehouseSaved += WarehouseForm_WarehouseSaved;
            warehouseFormControl.CloseRequested += WarehouseForm_CloseRequested;

            // Pass the existing warehouse item for editing
            warehouseFormControl.SetItemForEdit(warehouseItem);

            AddItemPanel.Controls.Clear(); // Clear previous controls
            AddItemPanel.Controls.Add(warehouseFormControl);
            warehouseFormControl.Dock = DockStyle.Fill;
        }


        //private void Edit_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Please select a row to edit.");
        //        return;
        //    }
        //    else
        //    {
        //        int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
        //        var warehouse = _context.Warehouses.Find(id);
        //        if (warehouse != null)
        //        {
        //            panelContainer.Visible = true;
        //            panelContainer.BringToFront();
        //            WarehouseFormControl warehouseFormControl = new WarehouseFormControl(WarehouseFormControl.FormMode.AddWarehouse);
        //            warehouseFormControl.WarehouseSaved += WarehouseForm_WarehouseSaved;
        //            warehouseFormControl.CloseRequested += WarehouseForm_CloseRequested;

        //            warehouseFormControl.SetWarehouse(warehouse);
        //            panelContainer.Controls.Clear(); // Clear previous controls
        //            panelContainer.Controls.Add(warehouseFormControl);
        //            warehouseFormControl.Dock = DockStyle.Fill;
        //        }
        //    }
        //}
    }
}
