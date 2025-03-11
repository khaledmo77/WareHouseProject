using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseProject.Models
{
    public class TransferOrderDetail
    {
        public int TransferOrderDetailId { get; set; }
        public int TransferOrderId { get; set; }
        public TransferOrder TransferOrder { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
    }

}
