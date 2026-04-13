using JobListingsBoard_API.Data;
using JobListingsBoard_API.Middlewares;
using JobListingsBoard_API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.s
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IJobService, JobService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler("/error"); // Handles all unhandled exceptions globally before anything else runs

app.UseHttpsRedirection(); // Forces all requests to use HTTPS for security

app.UseRouting(); // Determines which endpoint will handle the request

app.UseMiddleware<RequestLogger>();

app.UseAuthorization(); // Checks if the user is authorized to access the endpoint

app.MapControllers(); // Maps incoming requests to controllers

app.Run();
