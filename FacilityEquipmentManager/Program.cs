using FacilityEquipmentManager.Data;
using FacilityEquipmentManager.Middleware;
using FacilityEquipmentManager.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

builder.Services.AddScoped<ContractService>();
builder.Services.AddSingleton<IContractQueue, ContractQueue>();
builder.Services.AddHostedService<ContractBackgroundProcessor>();

var app = builder.Build();

app.UseMiddleware<ApiKeyMiddleware>();
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
