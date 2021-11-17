using AppDataAccess.Repositories.File.Interfaces;
using AppModel.DTOs;
using DataAccess.Repositories.InMemory.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        public IInMemoryRepository _inMemoryRepo;
        public IFileRepository _fileRepo;
        //public ILoggerManager _logger;
        public UserService(IInMemoryRepository inMemoryRepo, IFileRepository fileRepo)
        {
            _inMemoryRepo = inMemoryRepo;
            _fileRepo = fileRepo;
        }
        public async Task<bool> RegisterUserAsync(string firstname, string lastname, string email, string phone, string github)
        {
            //int numberOfRows = _inMemoryRepo.RowCount();
            //int UserID = numberOfRows++;

            var user = await _inMemoryRepo.ReadAllUsersAsync();

            if (user.Count != 0 && user.Where(x => x.Email == email && x.PhoneNumber == phone && x.Github == github).Count() != 0)
            {
                return false;
            }
            else
            {
                //_inMemoryRepo.AddUser(firstname, lastname, email, phone, github);
                await _fileRepo.AddUserAsync(firstname, lastname, email, phone, github);
                return true;
            }
        }

        public async Task<List<UserToReturn>> GetUserAsync(string id)
        {
            //var listOfUsers = await _inMemoryRepo.ReadAllUsersAsync();
            var data = await _fileRepo.ReadUserAsync(id);

            var UserToReturn = new List<UserToReturn>();

            foreach (var user in data)
            {
                UserToReturn.Add(new UserToReturn { FullName = $"{user.FirstName} {user.LastName}", Email = user.Email, PhoneNumber = user.PhoneNumber, Github = user.Github });
            }
            return UserToReturn;
        }

        public async Task<List<UserToReturn>> GetAllUsersAsync()
        {
            //var listOfUsers = await _inMemoryRepo.ReadAllUsersAsync();
            var listOfUsers = await _fileRepo.ReadAllUsersAsync();

            var users = new List<UserToReturn>();

            foreach (var user in listOfUsers)
            {
                users.Add(new UserToReturn { FullName = $"{user.FirstName} {user.LastName}", Email = user.Email, PhoneNumber = user.PhoneNumber, Github = user.Github });
            }
            return users;
        }

        public Task<bool> EditUserAsync(string id, string firstname, string lastname, string email, string phone, string github)
        {
            //_inMemoryRepo.AddUser(firstname, lastname, email, phone, github);
            _fileRepo.UpdateUser(id, firstname, lastname, email, phone, github);

            return Task.Run(() => true);
        }

        public Task<bool> DeleteUserAsync(string id)
        {
            _fileRepo.DeleteUserAsync(id);

            return Task.Run(() => true);
        }
    }
}
