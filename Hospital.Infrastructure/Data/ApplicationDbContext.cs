using Hospital.Domain.Users.Appointmets;
using Hospital.Domain.Users.Discharge;
using Hospital.Domain.Users.Doctors;
using Hospital.Domain.Users.Inventory;
using Hospital.Domain.Users.Invoices;
using Hospital.Domain.Users.MedicalServices;
using Hospital.Domain.Users.Patients;
using Hospital.Domain.Users.Prescriptions;
using Hospital.Domain.Users.Receptionists;
using Microsoft.EntityFrameworkCore;
using Hospital.Domain.Users.Surgery;
using Hospital.Domain.Users.Inpatients;
using Hospital.Domain.Users.Payments;
using Hospital.Domain.Users.Finance;
using Hospital.Domain.Users.HumanResources;

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
        public DbSet<MedicalService> MedicalServices{ get;  set; }

        public DbSet<Surgery> Surgeries { get; set; }
        public DbSet<SurgeryStaff> SurgeryStaffs { get; set; }
        public DbSet<SurgerySupply> SurgerySupplies { get; set; }

        public DbSet<PatientStay> PatientStays { get; set; }
        public DbSet<StaySupply> StaySupplies { get; set; }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Bed> Beds { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<CashTransaction> CashTransactions { get; set; }
        public DbSet<PatientAccount> PatientAccounts { get; set; }

        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public DbSet<EmployeeLoan> EmployeeLoans { get; set; }
        public DbSet<EmployeeAdjustment> EmployeeAdjustments { get; set; }





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

            //  Surgery → SurgeryStaff / SurgerySupply
            modelBuilder.Entity<Surgery>()
                .HasMany(s => s.Staff)
                .WithOne(ss => ss.Surgery)
                .HasForeignKey(ss => ss.SurgeryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Surgery>()
                .HasMany(s => s.Supplies)
                .WithOne(ss => ss.Surgery)
                .HasForeignKey(ss => ss.SurgeryId)
                .OnDelete(DeleteBehavior.Cascade);

            //  Room → Beds
            modelBuilder.Entity<Room>()
                .HasMany(r => r.Beds)
                .WithOne(b => b.Room)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            //  Payment: optional relations
            modelBuilder.Entity<Payment>()
                .HasOne<Surgery>()
                .WithMany()
                .HasForeignKey(p => p.SurgeryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Payment>()
                .HasOne<PatientStay>()
                .WithMany()
                .HasForeignKey(p => p.PatientStayId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<EmployeeAdjustment>()
                .Property(e => e.Type)
                .HasConversion<string>();

        }



    }
}

