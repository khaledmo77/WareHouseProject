using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseProject.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ICollection<WarehouseItem> WarehouseItems { get; set; }
        public ICollection<SupplyOrderDetail> SupplyOrderDetails { get; set; }
        public ICollection<WithdrawalOrderDetail> WithdrawalOrderDetails { get; set; }
        public ICollection<TransferOrderDetail> TransferOrderDetails { get; set; }
    }

}
