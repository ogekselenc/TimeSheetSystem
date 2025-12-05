using Microsoft.EntityFrameworkCore;
using TimeSheetSystem.Data.Data;
using TimeSheetSystem.Data.Repositories;
using TimeSheetSystem.Data.UnitOfWork;
using TimeSheetSystem.Domain.Employees.CreateEmployee;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TimeSheetDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateEmployeeHandler).Assembly)
);

builder.Services.AddScoped<ICreateEmployeeRepository, CreateEmployeeRepository>();
builder.Services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
