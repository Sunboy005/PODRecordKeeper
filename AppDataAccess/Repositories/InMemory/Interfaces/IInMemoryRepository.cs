using AppModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories.InMemory.Interfaces
{
    public interface IInMemoryRepository
    {
        bool AddUser(string firstname, string lastname, string email, string phone, string github);

        Task<List<User>> ReadAllUsersAsync();

        User ReadUser<T>(T data);

        Task<User> UpdateUserAsync(int id, string firstname, string lastname, string email, string phone, string github);

        Task<bool> DeleteUserAsync(int id);
        int RowCount();
    }
}
