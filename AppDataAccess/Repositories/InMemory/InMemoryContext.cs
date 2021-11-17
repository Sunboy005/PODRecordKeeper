using AppModel;
using System.Collections.Generic;

namespace DataAccess.Repositories.InMemory
{
    public class InMemoryContext
    {
        public static List<User> Users { get; set; } = new List<User>();
    }
}
