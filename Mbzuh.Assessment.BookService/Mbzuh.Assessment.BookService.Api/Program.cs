global using Microsoft.AspNetCore.Mvc;
using Mbzuh.Assessment.BookService.Api.Filters;
using Mbzuh.Assessment.BookService.Application.Common.Configurations;
using Mbzuh.Assessment.BookService.Infrastructure.Configurations;
using Mbzuh.Assessment.BookService.Infrastructure.Persistence.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureBookServiceApplication();
builder.Services.ConfigureBookServiceInfrastructure(builder.Configuration);

// Add controllers and filters
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(SanitizeInputFilterAttribute)); // Clean input spaces
    options.Filters.Add(typeof(FluentValidationFilterAttribute)); // Validate input properties format
    options.Filters.Add(typeof(ApiExceptionFilterAttribute)); // Validate bussiness
});

//To allow being called from any origin
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// To allow re-writing the bad-request response (Needed for FluentValidationFilterAttribute)
builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Initialize database (Either in-memory database or sql server depending on appsettings.josn configuration)
    using var scope = app.Services.CreateScope();
    var dbContextInitializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
    await dbContextInitializer.InitializeAsync();

    // Seed data (Optionally depending on appsettings.josn configuration)
    if (Convert.ToBoolean(builder.Configuration["SeedDataOnStart"]))
    {
        var dbContextSeeder = scope.ServiceProvider.GetRequiredService<ApplicationDbContextDataSeeding>();
        await dbContextSeeder.SeedAsync();
    }
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseCors();
app.Run();
