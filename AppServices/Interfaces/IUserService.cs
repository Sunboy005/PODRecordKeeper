using System.Collections.Generic;
using System.Threading.Tasks;
using AppModel;
using AppModel.DTOs;

namespace Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(string firstname, string lastname, string email, string phone, string github);
        Task<List<UserToReturn>> GetAllUsersAsync();
        Task<List<UserToReturn>> GetUserAsync(string id);
        Task<bool> DeleteUserAsync(string id);
        Task<bool> EditUserAsync(string id, string firstname, string lastname, string email, string phone, string github);
    }
}