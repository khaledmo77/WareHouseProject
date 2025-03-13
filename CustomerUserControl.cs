using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouseProject
{
    public partial class CustomerUserControl : UserControl
    {
        private readonly WarehouseManagementContext _context = new WarehouseManagementContext(new Microsoft.EntityFrameworkCore.DbContextOptions<WarehouseManagementContext>());
        public event EventHandler WarehouseSaved;
        public event EventHandler CloseRequested;
        public CustomerUserControl()
        {

            InitializeComponent();
            showCustomer();
            panel1.Visible = false;
        }
        private void showCustomer()
        {
            var customer = _context.Customers.Select(w => new
            {
                w.CustomerId,
                w.Name,
                w.Location,
                w.PhoneNumber,
                //w.Email
            }).ToList();
            dataGridView1.Refresh();
            dataGridView1.DataSource = customer;
        }

        private void AddCustomer_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.BringToFront();
            WarehouseFormControl customerFormControl = new WarehouseFormControl(WarehouseFormControl.FormMode.AddCustomer);
            customerFormControl.WarehouseSaved += WarehouseForm_WarehouseSaved;
            customerFormControl.CloseRequested += WarehouseForm_CloseRequested;
            panel1.Controls.Clear(); // Clear previous controls
            panel1.Controls.Add(customerFormControl);
            customerFormControl.Dock = DockStyle.Fill;


            //panelContainer.BringToFront();
            //SupplierFormControl supplierFormControl = new SupplierFormControl(SupplierFormControl.FormMode.AddSupplier);
            //supplierFormControl.SupplierSaved += SupplierForm_SupplierSaved;
            //supplierFormControl.CloseRequested += SupplierForm_CloseRequested;
            //panelContainer.Controls.Clear(); // Clear previous controls
            //panelContainer.Controls.Add(supplierFormControl);
            //supplierFormControl.Dock = DockStyle.Fill;
        }
        private void WarehouseForm_WarehouseSaved(object sender, EventArgs e)
        {

            MessageBox.Show("customer saved successfully!");
            panel1.Visible = false;
            dataGridView1.Refresh();
            showCustomer();

            // Refresh the main DataGridView
        }

        private void WarehouseForm_CloseRequested(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.Controls.Remove((Control)sender); // Remove the control when closing
            dataGridView1.Refresh();
        }

        private void EditCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.");
                return;
            }
            else
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                var customer = _context.Customers.Find(id);
                if (customer != null)
                {
                    panel1.Visible = true;
                    panel1.BringToFront();
                    WarehouseFormControl customerFormControl = new WarehouseFormControl(WarehouseFormControl.FormMode.EditCustomer);
                    customerFormControl.WarehouseSaved += WarehouseForm_WarehouseSaved;
                    customerFormControl.CloseRequested += WarehouseForm_CloseRequested;
                    customerFormControl.setCustomerForEdit(customer);
                    panel1.Controls.Clear(); // Clear previous controls
                    panel1.Controls.Add(customerFormControl);
                    customerFormControl.Dock = DockStyle.Fill;
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
    }
}
