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
    public partial class SuppliersUserControl: UserControl
    {
        private readonly WarehouseManagementContext _context = new WarehouseManagementContext(new Microsoft.EntityFrameworkCore.DbContextOptions<WarehouseManagementContext>());
        public event EventHandler WarehouseSaved;
        public event EventHandler CloseRequested;
        private Warehouse _warehouse;



        public SuppliersUserControl()
        {
            InitializeComponent();
            panel1.Visible = false;
            showSuppliers();
     
        }
        private void showSuppliers()
        {
            var suppliers = _context.Suppliers.Select(w => new
            {
                w.SupplierId,
                w.Name,
                w.Location,
                w.PhoneNumber,
                //w.Email
            }) .ToList();
            dataGridView1.Refresh();
            dataGridView1.DataSource = suppliers;
        }
        private void AddSup_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.BringToFront();
            WarehouseFormControl supplierFormControl = new WarehouseFormControl(WarehouseFormControl.FormMode.AddSupplier);
            supplierFormControl.WarehouseSaved += WarehouseForm_WarehouseSaved;
            supplierFormControl.CloseRequested += WarehouseForm_CloseRequested;
            panel1.Controls.Clear(); // Clear previous controls
            panel1.Controls.Add(supplierFormControl);
            supplierFormControl.Dock = DockStyle.Fill;


            //panelContainer.BringToFront();
            //SupplierFormControl supplierFormControl = new SupplierFormControl(SupplierFormControl.FormMode.AddSupplier);
            //supplierFormControl.SupplierSaved += SupplierForm_SupplierSaved;
            //supplierFormControl.CloseRequested += SupplierForm_CloseRequested;
            //panelContainer.Controls.Clear(); // Clear previous controls
            //panelContainer.Controls.Add(supplierFormControl);
            //supplierFormControl.Dock = DockStyle.Fill;
        }
        private void EditSup_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.");
                return;
            }
            else
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                var supplier = _context.Suppliers.Find(id);
                if (supplier != null)
                {
                    panel1.Visible = true;
                    panel1.BringToFront();
                    WarehouseFormControl supplierFormControl = new WarehouseFormControl(WarehouseFormControl.FormMode.EditSupplier);
                    supplierFormControl.WarehouseSaved += WarehouseForm_WarehouseSaved;
                    supplierFormControl.CloseRequested += WarehouseForm_CloseRequested;
                    supplierFormControl.setSupplierForEdit(supplier);
                    panel1.Controls.Clear(); // Clear previous controls
                    panel1.Controls.Add(supplierFormControl);
                    supplierFormControl.Dock = DockStyle.Fill;
                }
            }

            //panel1.Visible = true;
            //panel1.BringToFront();
            //WarehouseFormControl supplierFormControl = new WarehouseFormControl(WarehouseFormControl.FormMode.EditSupplier);
            //supplierFormControl.WarehouseSaved += WarehouseForm_WarehouseSaved;
            //supplierFormControl.CloseRequested += WarehouseForm_CloseRequested;
            //panel1.Controls.Clear(); // Clear previous controls
            //panel1.Controls.Add(supplierFormControl);
            //supplierFormControl.Dock = DockStyle.Fill;
        }
        private  void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide this control
            CloseRequested?.Invoke(this, EventArgs.Empty);
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
        private void WarehouseForm_WarehouseSaved(object sender, EventArgs e)
        {

            MessageBox.Show("supplier saved successfully!");
            panel1.Visible = false;
            dataGridView1.Refresh();
            showSuppliers();

            // Refresh the main DataGridView
        }

        private void WarehouseForm_CloseRequested(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.Controls.Remove((Control)sender); // Remove the control when closing
            dataGridView1.Refresh();
        }
        // private void LoadWareHouses()
        // {
        //     dataGridView1.DataSource = _context.Warehouses.Select(w => new
        //     {
        //         w.WarehouseId,
        //         w.Name,
        //         w.Location,
        //         ItemCount = w.WarehouseItems.Count // Instead of showing navigation property
        //     })
        //.ToList();
        //     dataGridView1.Refresh();
        // }
    }
}
