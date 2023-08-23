
using ProductsCRUDProject.Models;

namespace ProductsCRUDApi.IReposoritory
{

    public interface IProductsReposotitory
    {
        Products Save(Products product);

        Products Get(string id);
        List<Products> Gets();
        string Delete(string id);
    }
}