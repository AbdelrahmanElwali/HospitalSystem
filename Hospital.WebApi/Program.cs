using Hospital.Application.Interfaces;
using Hospital.Domain.Interfaces;
using Hospital.Infrastructure.Data;
using Hospital.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hospital API", Version = "v1" });
});


builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
builder.Services.AddScoped<IDischargeSummaryRepository, DischargeSummaryRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IReceptionistRepository, ReceptionistRepository>();
builder.Services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
builder.Services.AddScoped<IMedicalServiceRepository, MedicalServiceRepository>();
builder.Services.AddScoped<ISurgeryRepository, SurgeryRepository>();
builder.Services.AddScoped<ISurgeryStaffRepository, SurgeryStaffRepository>();
builder.Services.AddScoped<ISurgerySupplyRepository, SurgerySupplyRepository>();
builder.Services.AddScoped<IPatientStayRepository, PatientStayRepository>();
builder.Services.AddScoped<IStaySupplyRepository, StaySupplyRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IBedRepository, BedRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPatientAccountRepository, PatientAccountRepository>();
builder.Services.AddScoped<ICashTransactionRepository, CashTransactionRepository>();
builder.Services.AddScoped<IEmployeeSalaryRepository, EmployeeSalaryRepository>();
builder.Services.AddScoped<IEmployeeLoanRepository, EmployeeLoanRepository>();
builder.Services.AddScoped<IEmployeeAdjustmentRepository, EmployeeAdjustmentRepository>();


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hospital API v1");
    c.RoutePrefix = string.Empty; 
});


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();
