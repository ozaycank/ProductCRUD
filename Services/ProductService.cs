using ProductCRUD.Models;
using System.Net.Http.Json; 

namespace ProductCRUD.Services
{
    public class ProductService : IProductService
    {
        private HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Product[]> GetProducts()
        {
            return _httpClient.GetFromJsonAsync<Product[]>("https://localhost:44335/api/products/getall"); // Updated method
        }

        public Task<Product> GetProductById(int productId)
        {
            return _httpClient.GetFromJsonAsync<Product>("https://localhost:44335/api/products/getbyid?productId=" + productId); // Updated method
        }

        public async Task Save(Product product)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:44335/api/products/update", product); // Updated method
        }

        public async Task Add(Product product)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:44335/api/products/add", product); // Updated method
        }
    }
}
