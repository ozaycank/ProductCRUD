using System.Net.Http;
using System.Net.Http.Json; 
using System.Threading.Tasks;
using ProductCRUD.Models; 
using Microsoft.AspNetCore.Components;


namespace ProductCRUD.Services
{
    public class CategoryService : ICategoryService
    {
        private HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }
        public Task<Category[]> GetCategories()
        {
            return _http.GetJsonAsync<Category[]>("https://localhost:44335/api/categories/getall");
        }

    }
}
