using ProductsCRUDProject.Models;

namespace ProductsCRUDProject.Services
{
    public interface IProductService
    {
        List<Products> Get();
        Products Get(string id);
        Products Create(Products products);
        void Update(string id, Products products);
        void Remove(string id);
    }
}

