using System.ComponentModel.DataAnnotations;

namespace GreenHealthWebsite.Models.Staff.Pharmacy
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }

        public string SupplierInfo { get; set; }
    }
}
