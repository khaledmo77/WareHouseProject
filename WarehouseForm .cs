using WareHouseProject.Models;

namespace WareHouseProject
{
    public partial class WarehouseForm : Form
    {
        private readonly WarehouseManagementContext _context = new WarehouseManagementContext(new Microsoft.EntityFrameworkCore.DbContextOptions<WarehouseManagementContext>());

        public WarehouseForm()
        {
            InitializeComponent();
            LoadWareHouses();
            panelContainer.Visible = false;
        }
        private void LoadWareHouses()
        {
            dataGridView1.DataSource = _context.Warehouses.Select(w => new
            {
                w.WarehouseId,
                w.Name,
                w.Location,
                ItemCount = w.WarehouseItems.Count // Instead of showing navigation property
            })
       .ToList();
            dataGridView1.Refresh();
        }

        private void AddWareHouse_Click_1(object sender, EventArgs e)
        {
            panelContainer.Visible = true;
            panelContainer.BringToFront();
            WarehouseFormControl warehouseFormControl = new WarehouseFormControl(WarehouseFormControl.FormMode.AddWarehouse);
            warehouseFormControl.WarehouseSaved += WarehouseForm_WarehouseSaved;
            warehouseFormControl.CloseRequested += WarehouseForm_CloseRequested;
            panelContainer.Controls.Clear(); // Clear previous controls
            panelContainer.Controls.Add(warehouseFormControl);
            warehouseFormControl.Dock = DockStyle.Fill;
        }
        private void WarehouseForm_WarehouseSaved(object sender, EventArgs e)
        {
            MessageBox.Show("Warehouse added successfully!");
            LoadWareHouses();
            panelContainer.Visible = false;

            //  WarehouseFormControl.Controls.Clear(); // Remove form after saving
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int warehouseId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["WarehouseId"].Value);

                //    int itemId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ItemId"].Value);

                //  int wareHouseID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                ShowItemDetailsUserControl(warehouseId);

            }


        }
        private void ShowItemDetailsUserControl(int wareHouseID)
        {
            panelContainer.Visible = true; // Ensure the panel is visible
            panelContainer.Controls.Clear(); // Clear previous controls

            ShowWareHouseItemsUserControl itemDetailsControl = new ShowWareHouseItemsUserControl(wareHouseID);
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(itemDetailsControl);
            itemDetailsControl.WarehouseSaved += WarehouseControl_WarehouseSaved;
            itemDetailsControl.CloseRequested += WarehouseForm_CloseRequested;

            itemDetailsControl.Dock = DockStyle.Fill;
            panelContainer.BringToFront(); // Bring panel forward
            dataGridView1.Refresh();
        }
        private void WarehouseControl_WarehouseSaved(object sender, EventArgs e)
        {
            LoadWareHouses(); // Refresh the main DataGridView
        }

        private void WarehouseForm_CloseRequested(object sender, EventArgs e)
        {
            panelContainer.Visible = false;
            this.Controls.Remove((Control)sender); // Remove the control when closing
            dataGridView1.Refresh();
        }
  
        private void Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.");
                return;
            }
            else
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                var warehouse = _context.Warehouses.Find(id);
                if (warehouse != null)
                {
                    panelContainer.Visible = true;
                    panelContainer.BringToFront();
                    WarehouseFormControl warehouseFormControl = new WarehouseFormControl(WarehouseFormControl.FormMode.AddWarehouse);
                    warehouseFormControl.WarehouseSaved += WarehouseForm_WarehouseSaved;
                    warehouseFormControl.CloseRequested += WarehouseForm_CloseRequested;

                    warehouseFormControl.SetWarehouse(warehouse);
                    panelContainer.Controls.Clear(); // Clear previous controls
                    panelContainer.Controls.Add(warehouseFormControl);
                    warehouseFormControl.Dock = DockStyle.Fill;
                }
            }
        }
        private void DeleteWareHouse_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }
            else
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                var warehouse = _context.Warehouses.Find(id);
                if (warehouse != null)
                {
                    try
                    {
                        _context.Warehouses.Remove(warehouse);
                        _context.SaveChanges();
                        LoadWareHouses();
                        MessageBox.Show("Warehouse deleted successfully.");

                    }
                    catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                    {
                        MessageBox.Show("Cannot delete this warehouse because it has related records in other tables.", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
        }

        private void showSuppliers_Click(object sender, EventArgs e)
        {

            panelContainer.Visible = true;
            panelContainer.BringToFront();
            panelContainer.Controls.Clear(); // Clear previous controls

            SuppliersUserControl suppliersUserControl = new SuppliersUserControl();
            suppliersUserControl.CloseRequested += SupplyOrderUserControl_CloseRequested;
            panelContainer.Controls.Add(suppliersUserControl);
            suppliersUserControl.Dock = DockStyle.Fill;

            //  MessageBox.Show("SuppliersUserControl added!"); // Debugging step
        }


        private void showCustomers_Click(object sender, EventArgs e)
        {

            panelContainer.Visible = true;
            panelContainer.BringToFront();
            panelContainer.Controls.Clear(); // Clear previous controls
            CustomerUserControl customerUserControl = new CustomerUserControl();
            panelContainer.Controls.Add(customerUserControl);
            customerUserControl.Dock = DockStyle.Fill;
        }

        private void AddSupplyOrder_Click(object sender, EventArgs e)//show supply order
        {
            panelContainer.Visible = true;
            panelContainer.BringToFront();
            panelContainer.Controls.Clear(); // Clear previous controls
            SupplyOrderUserControl supplyOrderUserControl = new SupplyOrderUserControl();
            supplyOrderUserControl.CloseRequested += SupplyOrderUserControl_CloseRequested;
            panelContainer.Controls.Add(supplyOrderUserControl);
            supplyOrderUserControl.Dock = DockStyle.Fill;
        }

        private void SupplyOrderUserControl_CloseRequested(object sender, EventArgs e)
        {
            panelContainer.Visible = false; // Hide the container panel
            panelContainer.Controls.Clear(); // Clear controls
        }

    }
}
