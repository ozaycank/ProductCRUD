using ProductCRUD.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProductCRUD.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductListViewModel> GetProductById(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ProductListViewModel>($"products/{Id}");
        }

        public async Task<ProductListViewModel[]> GetProducts()
        {
            return await _httpClient.GetFromJsonAsync<ProductListViewModel[]>("products");
        }

        public async Task Add(ProductListViewModel productListViewModel)
        {
            await _httpClient.PostAsJsonAsync("products", productListViewModel);
        }

        public async Task Save(ProductListViewModel productListViewModel)
        {
            if (productListViewModel.Id == 0)
            {
                // This is a new product, so we'll add it
                await Add(productListViewModel);
            }
            else
            {
                // This is an existing product, so we'll update it
                await _httpClient.PutAsJsonAsync($"products/{productListViewModel.Id}", productListViewModel);
            }
        }

        public async Task<string[]> GetCategories()
        {
            return await _httpClient.GetFromJsonAsync<string[]>("products/categories");
        }

        public async Task<ProductListViewModel[]> GetProductsByCategory(string category)
        {
            return await _httpClient.GetFromJsonAsync<ProductListViewModel[]>($"products/category/{category}");
        }

        //public async Task<Cart> GetCart(int userId)
        //{
        //    return await _httpClient.GetFromJsonAsync<Cart>($"carts?userId={userId}");
        //}

        public async Task<ProductListViewModel[]> GetLimitedProducts(int limit)
        {
            return await _httpClient.GetFromJsonAsync<ProductListViewModel[]>($"products?limit={limit}");
        }

        public async Task DeleteProduct(int Id)
        {
            await _httpClient.DeleteAsync($"products/{Id}");
        }
    }
}
