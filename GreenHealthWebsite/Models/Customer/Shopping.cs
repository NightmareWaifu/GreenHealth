using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreenHealthWebsite.Models.Customer
{
    public class Shopping
    {
        public Guid ShopID { get; set; }
        public string ProductName { get; set; }
    }
}
