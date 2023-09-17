using System.Threading.Tasks;
using ProductCRUD.Models;

namespace ProductCRUD.Services
{
    public interface ICategoryService
    {
        Task<Category[]> GetCategories();
    }
}
