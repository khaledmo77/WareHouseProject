using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseProject
{
    public class SupplyOrderDTO
    {
        public int SupplyOrderId { get; set; }
        public int OrderID { get; set; }
        public int SupplierID { get; set; }
        public int WarehouseID { get; set; }
        public DateTime OrderDate { get; set; }
        public List<SupplyOrderItemDTO> Items { get; set; } = new List<SupplyOrderItemDTO>();

    }

    public class SupplyOrderItemDTO
    {
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime ProductionDate { get; set; }
    }

}
