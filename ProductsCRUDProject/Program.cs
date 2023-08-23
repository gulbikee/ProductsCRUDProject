using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductsCRUDProject.Models;
using ProductsCRUDProject.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["ProductsStoreDatabaseSettings:ConnectionString"];
var serviceApiKey = builder.Configuration["ProductsStoreDatabaseSettings:ServiceApiKey"];
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(connectionString));

// Add services to the container.
builder.Services.Configure<ProductsStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(ProductsStoreDatabaseSettings)));//Bu kod, ProductsStoreDatabaseSettings sýnýfýný yapýlandýrma dosyasýndan çekmek ve bu ayarlarý uygulama hizmetlerine eklemek için kullanýlýr. Configure metodu, yapýlandýrma ayarlarýný belirtilen sýnýfa baðlamak için kullanýlýr. Bu sayede, ProductsStoreDatabaseSettings sýnýfýnýn özelliklerine yapýlandýrma dosyasýndaki deðerler enjekte edilebilir.
builder.Services.AddSingleton<IProductsStoreDatabaseSettings>(
    sp => sp.GetRequiredService<IOptions<ProductsStoreDatabaseSettings>>().Value);// ProductsStroreDatabaseSettigs türünden singleaton nesne üretir
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("ProductsStoreDatabaseSettings:ConnectionString")));//Bu kod, MongoDB veritabaný için IMongoClient arabirimine sahip bir nesnenin singleton bir örneðini kaydeder. Bu satýr, yapýlandýrma dosyasýndan MongoDB baðlantý dizesini alýr ve bu baðlantý dizesini kullanarak bir MongoClient örneði oluþturur. Bu örnek, veritabanýna eriþim saðlar.
builder.Services.AddScoped<IProductService, ProductService>();
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

