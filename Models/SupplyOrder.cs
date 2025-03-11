using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseProject.Models
{
    public class SupplyOrder
    {
        public int SupplyOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public ICollection<SupplyOrderDetail> SupplyOrderDetails { get; set; }
    }

}
