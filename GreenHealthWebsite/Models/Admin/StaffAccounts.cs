using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreenHealthWebsite.Models.Admin
{
	public class StaffAccounts
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//[Required]
		public string NRIC { get; set; }
		public string StaffID { get; set; }
		public string Name { get; set; }
        [DataType(DataType.Password)]
        public byte[] Password { get; set; }
		public string Gender { get; set; }
		public string Roles { get; set; }

        //Make sure that the Phonenumber is 8 digit and only numbers in
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Phone number should be 8 digits.")]
        [Display(Name = "Phone Number")]
        public int PhoneNum { get; set; }

		//Check that it's an email
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

		// Only displaying the date
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of birth")]
        public DateTime DOB { get; set; }
		public string Status { get; set; }
		public string Address { get; set; }
	}
}
