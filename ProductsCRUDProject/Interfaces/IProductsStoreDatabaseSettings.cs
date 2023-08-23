namespace ProductsCRUDProject.Models
{
    
        public interface IProductsStoreDatabaseSettings
        {
            string ProducsCollectionName { get; set; }
            string ConnectionString { get; set; }
            string DatabaseName { get; set; }

        }
    }
