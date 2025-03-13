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
    public partial class SupplyOrderUserControl : UserControl
    {
        private readonly WarehouseManagementContext _context = new WarehouseManagementContext(new Microsoft.EntityFrameworkCore.DbContextOptions<WarehouseManagementContext>());
        public event EventHandler WarehouseSaved;
        public event EventHandler CloseRequested;

        public SupplyOrderUserControl()
        {
            InitializeComponent();
            panel1.Visible = false;
            LoadSupplyOrder();
        }
        private void LoadSupplyOrder()
        {
            try
            {
                var supplyOrders = _context.SupplyOrders
                    .Select(order => new
                    {
                        OrderID = order.SupplyOrderId,
                        SupplierName = order.Supplier.Name, // Assuming Supplier has a Name
                        WarehouseName = order.Warehouse.Name, // Assuming Warehouse has a Name
                        OrderDate = order.OrderDate,
                        Items = order.SupplyOrderDetails.Select(d => new
                        {
                            ItemName = d.Item.Name, // Assuming Item has a Name
                            Quantity = d.Quantity
                        }).ToList()
                    })
                    .ToList();

                // Flatten the data for display
                var displayData = new List<dynamic>();

                foreach (var order in supplyOrders)
                {
                    foreach (var item in order.Items)
                    {
                        displayData.Add(new
                        {
                            order.OrderID,
                            order.SupplierName,
                            order.WarehouseName,
                            order.OrderDate,
                            item.ItemName,
                            item.Quantity
                        });
                    }
                }

                // Bind to DataGridView
                dataGridView1.DataSource = null; // Clear existing data
                dataGridView1.DataSource = displayData;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Refresh(); // Refresh after setting the DataSource
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading supply orders: " + ex.Message);
            }
        }

        private void AddSupplyOrder_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.BringToFront();
            WarehouseFormControl supplyOrderFormControl = new WarehouseFormControl(WarehouseFormControl.FormMode.AddSupplyOrder);
            supplyOrderFormControl.WarehouseSaved += WarehouseForm_WarehouseSaved;
            supplyOrderFormControl.CloseRequested += WarehouseForm_CloseRequested;
            panel1.Controls.Clear(); // Clear previous controls
            panel1.Controls.Add(supplyOrderFormControl);
            supplyOrderFormControl.Dock = DockStyle.Fill;


        }
        private void WarehouseForm_WarehouseSaved(object sender, EventArgs e)
        {

            MessageBox.Show("supplier order saved successfully!");
            panel1.Visible = false;
            dataGridView1.Refresh();
            LoadSupplyOrder();

            // Refresh the main DataGridView
        }

        private void WarehouseForm_CloseRequested(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.Controls.Remove((Control)sender); // Remove the control when closing
            dataGridView1.Refresh();
        }

        private void EditSupplyOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.");
                return;
            }

            // Get the selected order ID
            int orderID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["OrderID"].Value);

            // Load the order details
            var orderDetails = _context.SupplyOrders
          .Where(order => order.SupplyOrderId == orderID)
          .Select(order => new SupplyOrderDTO
          {
              SupplyOrderId = order.SupplyOrderId,
              SupplierID = order.SupplierId,
              WarehouseID = order.WarehouseId,
              OrderDate = order.OrderDate,
              Items = order.SupplyOrderDetails.Select(d => new SupplyOrderItemDTO
              {
                  ItemID = d.ItemId,
                  Quantity = d.Quantity,
                  ExpiryDate = d.ExpiryDate,
                  ProductionDate = d.ProductionDate
              }).ToList()
          })
          .FirstOrDefault();

            if (orderDetails == null)
            {
                MessageBox.Show("Order not found.");
                return;
            }

            // Show the editing panel
            panel1.Visible = true;
            panel1.BringToFront();

            // Create form control
            WarehouseFormControl supplyOrderFormControl = new WarehouseFormControl(WarehouseFormControl.FormMode.EditSupplyOrder);

            // Event handlers
            supplyOrderFormControl.WarehouseSaved += WarehouseForm_WarehouseSaved;
            supplyOrderFormControl.CloseRequested += WarehouseForm_CloseRequested;

            // Clear previous controls and add new form control
            panel1.Controls.Clear();
            panel1.Controls.Add(supplyOrderFormControl);
            supplyOrderFormControl.Dock = DockStyle.Fill;

            // Load ComboBox data before setting values
            supplyOrderFormControl.LoadComboBoxes();

            // Set order details in form
            supplyOrderFormControl.setSupplyOrderForEdit(orderDetails);
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide this control
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }
  //      private void ShowWarehouseForm()
  //      {
  //          // Check if the parent form already contains the Warehouse form
  //          var warehouseControl = this.Parent?.Controls.OfType<WarehouseForm>().FirstOrDefault();

  //          if (warehouseControl == null)
  //          {
  //              warehouseControl = new WarehouseForm(); // Create a new instance
  //              warehouseControl.Dock = DockStyle.Fill; // Fit inside the panel
  //// Ensure it can be closed

  //              if (this.Parent is Panel panelContainer)
  //              {
  //                  panelContainer.Controls.Clear(); // Clear previous controls
  //           // Add Warehouse form
  //                  panelContainer.Visible = true; // Show the panel
  //              }
  //          }
  //          else
  //          {
  //              warehouseControl.Visible = true; // If it's already there, just show it
  //          }
  //      }

    }
}
