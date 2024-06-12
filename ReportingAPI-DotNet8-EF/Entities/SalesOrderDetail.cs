using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingAPI_DotNet8_EF.Entities
{
    [Table("SalesOrderDetail",Schema ="Sales")]
    public class SalesOrderDetail
    {
        [Key]
        [Column("SalesOrderDetailID")]
        public int SalesOrderID { get; set; }

        [Column("UnitPrice")]
        public decimal UnitPrice { get; set; }

        [Column("OrderQty")]
        public short Quantity { get; set; }

        [Column("LineTotal")]
        public decimal TotalPrice { get; set; }
    }
}
