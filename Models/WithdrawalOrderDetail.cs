using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseProject.Models
{
    public class WithdrawalOrderDetail
    {
        public int WithdrawalOrderDetailId { get; set; }
        public int WithdrawalOrderId { get; set; }
        public WithdrawalOrder WithdrawalOrder { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
    }

}
