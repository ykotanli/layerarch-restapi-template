using LayerTemplate.Business.Abstract;
using LayerTemplate.Business.Concrete;
using LayerTemplate.DataAccess.Context;
using LayerTemplate.DataAccess.Models;
using LayerTemplate.DataAccess.Repository.EntityFramework;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
//deneme satirlari, yorum olanlar şimdilik devredisi
//builder.Configuration.GetSection("PlatformConstants").Bind(MutualConstants.settings);
//builder.Services.AddDbContext<LayerTemplateTestDBContext>(options => options.UseSqlServer(MutualConstants.settings.DBConnectionStr));
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IUserService, UserManager>(); //hatali sandigim lane!
builder.Services.AddDbContext<personDbContext>(); //sonradan eklediğim
//LayerTemplate.API.Workers.MainWorker.IntiliazeServices();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
