using Hospital.Domain.Users.Appointmets;
using Hospital.Domain.Users.Discharge;
using Hospital.Domain.Users.Doctors;
using Hospital.Domain.Users.Inventory;
using Hospital.Domain.Users.Invoices;
using Hospital.Domain.Users.Patients;
using Hospital.Domain.Users.Prescriptions;
using Hospital.Domain.Users.Receptionists;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<UserBase> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<DischargeSummary> DischargeSummaries { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specilization> Specilizations { get; set; }
        public DbSet<DoctorSpecilization> DoctorSpecilizations { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserBase>()
                .Property(u => u.Role)
                .HasConversion<string>();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Status)
                .HasConversion<string>();


            modelBuilder.Entity<DoctorSpecilization>()
                .HasKey(ds => new { ds.DoctorId, ds.SpecilizationId });

            modelBuilder.Entity<DoctorSpecilization>()
                .HasOne(ds => ds.Doctor)
                .WithMany(d => d.DoctorSpecilizations)
                .HasForeignKey(ds => ds.DoctorId);

            modelBuilder.Entity<DoctorSpecilization>()
                .HasOne(ds => ds.Specilization)
                .WithMany(s => s.DoctorSpecilizations)
                .HasForeignKey(ds => ds.SpecilizationId);

        }
    }
}
