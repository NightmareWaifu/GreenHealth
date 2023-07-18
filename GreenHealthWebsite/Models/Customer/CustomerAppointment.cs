using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreenHealthWebsite.Models.Customer
{
    public class CustomerAppointment
    {
        public CustomerAppointment() 
        {
            Status = "Pending";
            //CreatedDate = DateTime.Now;
        }

        //private DateTime CreatedDate = DateTime.Now;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        public int AppointmentID { get; set; }
        //[Required]
        //public string Name { get; set; }

        public string NRIC { get; set; }
        public string StaffID { get; set; }
        public string ExaminationRoomID { get; set; }

        public string Email { get; set; }
        //[Required]
        public string Description { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }
        //[Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Status { get; set; }

        //[Required]

        [NotMapped]
        public string ArrivalDate => AppointmentDate.ToString("d/M/yyyy");
        [NotMapped]
        public string ArrivalTime => AppointmentDate.ToString("h:mm tt");
    }
}
