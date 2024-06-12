using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingAPI_DotNet8_EF.Entities
{
    [Table("SalesOrderHeader", Schema = "Sales")]
    public class SalesOrderHeader
    {
        [Key]
        [Column("SalesOrderID")]
        public int OrderID { get; set; }

        [Column("OrderDate")]
        public DateTime OrderDate { get; set; }


        [Column("AccountNumber")]
        public string AccountNumber { get; set; } = string.Empty;

        [Column("CustomerID")]
        public int? CustomerID { get; set; } // Changed to nullable

        [Column("TotalDue")]
        public decimal TotalDue { get; set; }

    }
}
