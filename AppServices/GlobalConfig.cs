using AppCommon;
using AppDataAccess.Repositories.File.Implementations;
using AppDataAccess.Repositories.File.Interfaces;
using DataAccess.Repositories.InMemory.Implementations;
using DataAccess.Repositories.InMemory.Interfaces;
using Services;
using Services.Implementations;

namespace AppServices
{
    public static class GlobalConfig
    {
        /// <summary>
        /// THIS IS A GLOBAL CONFIGURATION CLASS CREATED TO FACILITATE DEPENDENCY INJECTION. 
        /// </summary>

        public static ILoggerManager _logger;
        public static IInMemoryRepository _inMemoryRepo;
        public static IFileRepository _fileRepo;
        public static IUserService _userService;
        //public static IHistory History;

        public static string _path = Helper.GetAbsolutePath(@"\Users.txt");
        public static string _logPath = Helper.GetAbsolutePath(@"\logs.txt");

        static GlobalConfig()
        {
            _logger = new LoggerManager(_logPath);
            _inMemoryRepo = new InMemoryRepository();
            _fileRepo = new FileRepository(_path);
            _userService = new UserService(_inMemoryRepo, _fileRepo);
            //History = new History(LoggerManager);
        }

        public static void Destroy()
        {
            _inMemoryRepo = null;
            _inMemoryRepo = null;
            _userService = null;
            _logger = null;
            //History = null;
        }
    }
}
