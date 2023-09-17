using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCRUD.Models;

namespace ProductCRUD.Services
{
    public interface IAuthService
    {
        Task Login(LoginModel loginModel);
        Task Logout();
    }
}
