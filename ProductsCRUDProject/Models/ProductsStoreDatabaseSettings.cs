
namespace ProductsCRUDProject.Models
{
    public class ProductsStoreDatabaseSettings : IProductsStoreDatabaseSettings
    {
        public string ProducsCollectionName { get; set; } = ""; // Başlangıç değeri atandı
        public string ConnectionString { get; set; } = ""; // Başlangıç değeri atandı
        public string DatabaseName { get; set; } = ""; // Başlangıç değeri atandı
    }
}
