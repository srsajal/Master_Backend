using master.BAL.IServices;
using master.BAL.Services;
using master.DAL.DBContext;
using master.DAL.Entity;
using master.DAL.IRepository;
using master.DAL.Repository;
using master.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MasterManagementDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("MasterManagementDBConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories
builder.Services.AddScoped<IRepository<Ddo>, masterDDORepostiory>();
builder.Services.AddTransient<ImasterDDORepository, masterDDORepostiory>();
builder.Services.AddScoped<IRepository<Department>, masterDepartmentRepository>();
builder.Services.AddTransient<ImasterDepartmentRepository, masterDepartmentRepository>();
builder.Services.AddScoped<IRepository<Treasury>, masterTreasuryRepository>();
builder.Services.AddTransient<ImasterTreasuryRepository, masterTreasuryRepository>();
builder.Services.AddTransient<ImasterSCHEME_HEADRepository, masterSCHEME_HEADRepository>();
builder.Services.AddScoped<ImasterSCHEME_HEADRepository, masterSCHEME_HEADRepository>();

// Services
builder.Services.AddTransient<ImasterDDOService, masterDDOService>();
builder.Services.AddTransient<ImasterDepartmentService, masterDepartmentService>();
builder.Services.AddTransient<ImasterTreasuryService, masterTreasuryService>();
builder.Services.AddTransient<ImasterSCHEME_HEADService, masterSCHEME_HEADService>();


builder.Services.AddAutoMapper(typeof(MappingConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
