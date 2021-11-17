using AppModel;
using DataAccess.Repositories.InMemory.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories.InMemory.Implementations
{
    public class InMemoryRepository : IInMemoryRepository
    {

        public bool AddUser(string firstname, string lastname, string email, string phone, string github)
        {
            int rowCountBefore = this.RowCount();
            var user = new User();
            user.UserId = rowCountBefore++;
            user.FirstName = firstname;
            user.LastName = lastname;
            user.Email = email;
            user.PhoneNumber = phone;
            user.Github = github;
            InMemoryContext.Users.Add(user);

            foreach (var item in InMemoryContext.Users) Console.WriteLine(item.Id);

            int rowCountAfter = this.RowCount();
            if (rowCountAfter <= rowCountBefore) return false;

            return true;

        }

        public Task<List<User>> ReadAllUsersAsync()
        {
            int numberOfRows = this.RowCount();

            return Task.Run(() => InMemoryContext.Users);
        }

        public User ReadUser<T>(T data)
        {
            return default;
        }

        public async Task<User> UpdateUserAsync(int id, string firstname, string lastname, string email, string phone, string github)
        {
            int numberOfRows = this.RowCount();

            if (numberOfRows < 1)
                throw new Exception("No record found, table is empty!");

            var users = await ReadAllUsersAsync();

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserId == id)
                {
                    users[i].FirstName = firstname;
                    users[i].LastName = lastname;
                    users[i].Email = email;
                    users[i].PhoneNumber = phone;
                    users[i].Github = github;
                }
                else throw new Exception("User not found");
            }

            throw new Exception("User not found");
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            int numberOfRowsBefore = this.RowCount();

            if (numberOfRowsBefore < 1)
                throw new Exception("No record found, table is empty!");

            var users = await ReadAllUsersAsync();

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserId == id)
                {
                    InMemoryContext.Users.Remove(users[i]);
                    return true;
                }
            }

            int numberOfRowsAfter = this.RowCount();

            if (numberOfRowsAfter >= numberOfRowsBefore) return false;

            return true;

        }

        public int RowCount()
        {
            return InMemoryContext.Users.Count;
        }
    }
}
