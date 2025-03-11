using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseProject.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }

        public ICollection<SupplyOrder> SupplyOrders { get; set; }
        public ICollection<TransferOrderDetail> TransferOrderDetails { get; set; }
    }

}
