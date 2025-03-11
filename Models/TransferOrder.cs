using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseProject.Models
{
    public class TransferOrder
    {
        public int TransferOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int SourceWarehouseId { get; set; }
        [ForeignKey("SourceWarehouseId")]
        public Warehouse SourceWarehouse { get; set; }
     

        public int DestinationWarehouseId { get; set; }
        [ForeignKey("DestinationWarehouseId")]
        public Warehouse DestinationWarehouse { get; set; }
       
        public ICollection<TransferOrderDetail> TransferOrderDetails { get; set; }
    }

}
