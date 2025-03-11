using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseProject.Models
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<WarehouseItem> WarehouseItems { get; set; }
        public ICollection<SupplyOrder> SupplyOrders { get; set; }
        public ICollection<WithdrawalOrder> WithdrawalOrders { get; set; }
        public ICollection<TransferOrder> TransferOrders { get; set; }
    }

}
