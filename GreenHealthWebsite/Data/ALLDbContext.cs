using GreenHealthWebsite.Models.Staff.Pharmacy;
using GreenHealthWebsite.Models.Admin;
using GreenHealthWebsite.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace GreenHealthWebsite.Data
{
    public class ALLDbContext : DbContext
    {
        public ALLDbContext(DbContextOptions<ALLDbContext> options) : base(options)
        {
        }

        public DbSet<CustomerAppointment> CustomerAppointment { get; set; }
        public DbSet<PatientAccounts> CustomerAccounts { get; set; }
        public DbSet<StaffAccounts> StaffAccounts { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<MedicineOrder> MedicineOrders { get; set; }
    }
}
