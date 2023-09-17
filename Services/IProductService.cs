using ProductCRUD.Models;
using System.Threading.Tasks;

namespace ProductCRUD.Services
{
    public interface IProductService
    {
        Task<Product[]> GetProducts();
        Task<Product> GetProductById(int productId);
        Task Save(Product product);
        Task Add(Product product);

    }
}
