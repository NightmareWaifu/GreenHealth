using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreenHealthWebsite.Models.Staff.Pharmacy
{
    public class MedicineOrder
    {
        [Key]
        public int OrderID { get; set; }

        [ForeignKey("Medicines")]
        public int MedicineID { get; set; }
        [ForeignKey("Suppliers")]
        public int SupplierID { get; set; }

        [Display(Name = "Medicine")]
        public string Medicine_Name { get; set; }

        [Display(Name = "Supplier")]
        public String SupplierName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "DateOrdered")]
        public DateTime OrderedDate { get; set; }
        public int OrderedStock { get; set; }

        public Medicine Medicines { get; set; }

        public Supplier Suppliers { get; set; }
    }
}
