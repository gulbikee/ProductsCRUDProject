using MongoDB.Bson;
using MongoDB.Driver;
using ProductsCRUDProject.Models;

namespace ProductsCRUDProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Products> _products;

        public ProductService(IProductsStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _products = database.GetCollection<Products>(settings.ProducsCollectionName);
        }

        public Products Create(Products products)
        {
            products.Id = ObjectId.GenerateNewId().ToString(); 
            _products.InsertOne(products);
            return products;
        }

       

        public List<Products> Get()
        {
            return _products.Find(products => true).ToList();
        }

        public Products Get(string id)
        {
            return _products.Find(products => products.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _products.DeleteOne(products => products.Id == id);
        }

        public void Update(string id, Products products)
        {
            _products.ReplaceOne(p => p.Id == id, products);
        }

       
    }
}
