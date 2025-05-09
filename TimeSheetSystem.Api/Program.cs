using Microsoft.EntityFrameworkCore;
using TimeSheetSystem.Data.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TimeSheetDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
