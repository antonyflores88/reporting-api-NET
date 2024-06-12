using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingAPI_DotNet8_EF.Entities
{
    [Table("Product", Schema ="Production")]
    public class Product
    {
        [Key]
        [Column("ProductID")]
        public int ProductID { get; set; }

        [Column("Name")]
        public string ProductName { get; set; } = string.Empty;
    }
}
