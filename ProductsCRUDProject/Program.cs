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
    builder.Configuration.GetSection(nameof(ProductsStoreDatabaseSettings)));//Bu kod, ProductsStoreDatabaseSettings s�n�f�n� yap�land�rma dosyas�ndan �ekmek ve bu ayarlar� uygulama hizmetlerine eklemek i�in kullan�l�r. Configure metodu, yap�land�rma ayarlar�n� belirtilen s�n�fa ba�lamak i�in kullan�l�r. Bu sayede, ProductsStoreDatabaseSettings s�n�f�n�n �zelliklerine yap�land�rma dosyas�ndaki de�erler enjekte edilebilir.
builder.Services.AddSingleton<IProductsStoreDatabaseSettings>(
    sp => sp.GetRequiredService<IOptions<ProductsStoreDatabaseSettings>>().Value);// ProductsStroreDatabaseSettigs t�r�nden singleaton nesne �retir
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("ProductsStoreDatabaseSettings:ConnectionString")));//Bu kod, MongoDB veritaban� i�in IMongoClient arabirimine sahip bir nesnenin singleton bir �rne�ini kaydeder. Bu sat�r, yap�land�rma dosyas�ndan MongoDB ba�lant� dizesini al�r ve bu ba�lant� dizesini kullanarak bir MongoClient �rne�i olu�turur. Bu �rnek, veritaban�na eri�im sa�lar.
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

