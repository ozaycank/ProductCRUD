using ProductCRUD.Models;

namespace ProductCRUD.Services
{
    public interface IProductService
    {
        Task<ProductListViewModel[]> GetProducts();
        Task Add(ProductListViewModel productListViewModel);
        Task Save(ProductListViewModel productListViewModel);
        Task<ProductListViewModel> GetProductById(int Id);

    }
}
