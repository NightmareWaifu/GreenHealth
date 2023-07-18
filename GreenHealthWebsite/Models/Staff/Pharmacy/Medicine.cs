using System.ComponentModel.DataAnnotations;

namespace GreenHealthWebsite.Models.Staff.Pharmacy
{
    public class Medicine
    {
        [Key]
        public int MedicineID { get; set; }

        [Display(Name = "Name")]
        public string Medicine_Name { get; set; } = null!;

        public string Description { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "ExpiryDate")]
        public DateTime Expiry_Date { get; set; }

        public string Image { get; set; } = null!;
    }
}
