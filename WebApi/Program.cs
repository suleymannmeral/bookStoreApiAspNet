using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using Presentation.ActionFilters;
using Repositories.EFCore;
using Services.Contracts;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));
builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = false; // içerik pazarlığına açığız yani xml,csv gibi istekleri de kabul edebilir
    config.ReturnHttpNotAcceptable = true;

}
)
    .AddNewtonsoftJson()
    .AddCustomCsvFormatter()
    .AddXmlDataContractSerializerFormatters()  //Xml  dönüşü yapabilir artık
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

builder.Services.AddScoped<ValidationFilterAttribute>();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
}
);
//Web API'de varsayılan olarak ModelState geçersiz olduğunda (yani bir model doğrulama hatası varsa) otomatik olarak
//400 Bad Request döndürülmesini devre dışı bırakır.

//Eğer bir controller'da [ApiController] attribute'u varsa ve gelen model geçersizse (ModelState.IsValid == false),
//ASP.NET Core otomatik olarak 400 Bad Request döner.  Biz bunun değiştiriyoruz



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();

builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureActionFilters();
builder.Services.ConfigureCors();
var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if(app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
