using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AppDataAccess.Repositories.File.Interfaces;
using AppModel;

namespace AppDataAccess.Repositories.File.Implementations
{
    public class FileRepository : IFileRepository
    {
        private readonly string _path;
        public FileRepository(string path)
        {
            _path = path;
        }
        public Task<bool> AddUserAsync(string firstname, string lastname, string email, string phone, string github)
        {
            ///*
            
            var user = new User();
            user.FirstName = firstname;
            user.LastName = lastname;
            user.Email = email;
            user.PhoneNumber = phone;
            user.Github = github;

            string output = $"{user.Id}, {user.FirstName}, {user.LastName}, {user.Email}, {user.PhoneNumber}, {user.Github}";

            string newString = string.Join(",", output);
            try
            {
                if (System.IO.File.Exists(_path)) System.IO.File.AppendAllText(_path, newString + "\n");
                else System.IO.File.WriteAllText(_path, newString + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //*/

            #region

            /*
            
            using (StreamWriter sw = new StreamWriter(_path, true))
            {
                //int rowCountBefore = this.RowCount();
                var user = new User();
                user.FirstName = firstname;
                user.LastName = lastname;
                user.Email = email;
                user.PhoneNumber = phone;
                user.Github = github;

                var line = "";
                line += user.Id + ",";
                line += user.FirstName + ",";
                line += user.LastName + ",";
                line += user.Email + ",";
                line += user.PhoneNumber + ",";
                line += user.Github;

                sw.Write(line);

                sw.Write(sw.NewLine);
            }

            */

            #endregion

            return Task.Run(() => true);
        }

        public Task<List<User>> ReadAllUsersAsync()
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                var records = new List<User>();

                var result = sr.ReadToEnd();

                var splittedByNewLine = result.Split("\n");//(new string[] { Environment.NewLine }, StringSplitOptions.None);

                foreach (var item in splittedByNewLine)
                {
                    if (!item.Equals(""))
                    {
                        var data = item.Split(",");
                        if(data.Length > 0)
                        {
                            User user = new User();
                            user.FirstName = data[1];
                            user.LastName = data[2];
                            user.Email = data[3];
                            user.PhoneNumber = data[4];
                            user.Github = data[5];
                            records.Add(user);
                        }
                    }
                }

                return Task.Run(() => records);
            }
        }

        public Task<List<User>> ReadUserAsync(string id)
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                var data = new List<User>();

                var result = sr.ReadToEnd();

                var splittedByNewLine = result.Split("\n");//(new string[] { Environment.NewLine }, StringSplitOptions.None);
                for (int i = 0; i < splittedByNewLine.Length; i++)
                {
                    var item = splittedByNewLine[i].Split(',');
                    if (item[0].ToString() == id)
                    {
                        User user = new User();
                        user.FirstName = item[1];
                        user.LastName = item[2];
                        user.Email = item[3];
                        user.PhoneNumber = item[4];
                        user.Github = item[5];
                        data.Add(user);
                    }
                }

                return Task.Run(() => data);
            }
        }

        public void UpdateUser(string id, string firstname, string lastname, string email, string phone, string github)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(_path);
                for (int i = 0; i < lines.Length; i++)
                {
                    var data = lines[i].Split(',');
                    if (data[0] == id)
                    {
                        lines[i] = $"{id}, {firstname}, {lastname}, {email}, {phone}, {github}";
                    }
                }
                System.IO.File.WriteAllLines(_path, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public Task<bool> DeleteUserAsync(string id)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(_path);
                for (int i = 0; i < lines.Length; i++)
                {
                    var data = lines[i].Split(',');
                    if (data[0].ToString() == id)
                    {
                        lines[i] = $"\b\b";
                    }
                }
                System.IO.File.WriteAllLines(_path, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Task.Run(() => true);
        }

        public int RowCount()
        {
            int lineCount = 0;
            using (TextReader reader = System.IO.File.OpenText(_path))
            {
                while (reader.ReadLine() != null) { lineCount++; }
            }

            /*

            int lineCount = 0;
            using (StreamReader reader = new StreamReader(_path, true))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            */

            return lineCount;

        }
    }
}
