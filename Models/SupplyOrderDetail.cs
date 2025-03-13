using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseProject.Models
{
    public class SupplyOrderDetail
    {
        public int SupplyOrderDetailId { get; set; }
        public int SupplyOrderId { get; set; }
        public SupplyOrder SupplyOrder { get; set; }
        public DateTime ProductionDate { get; set; }

        public DateTime ExpiryDate
        {
            get; set;
        }
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
    }

}
