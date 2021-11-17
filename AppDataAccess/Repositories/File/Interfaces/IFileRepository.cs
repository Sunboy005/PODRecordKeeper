using System.Collections.Generic;
using System.Threading.Tasks;
using AppModel;

namespace AppDataAccess.Repositories.File.Interfaces
{
    public interface IFileRepository
    {
        Task<bool> AddUserAsync(string firstname, string lastname, string email, string phone, string github);

        Task<List<User>> ReadAllUsersAsync();

        Task<List<User>> ReadUserAsync(string id);

        void UpdateUser(string id, string firstname, string lastname, string email, string phone, string github);

        Task<bool> DeleteUserAsync(string id);
        int RowCount();
    }
}
