using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppCommon;
using AppServices;
using Services;
using Services.Implementations;

namespace AppClient
{
    class Views
    {
        IUserService userService = GlobalConfig._userService;
        ILoggerManager logger = GlobalConfig._logger;
        //IHistory history = GlobalConfig.History;

        public async Task PrintUser(string id)
        {
            try
            {
                var users = await userService.GetUserAsync(id);

                int widthOfTable = 85;
                //Console.Clear();

                Helper.PrintLine(widthOfTable);
                Helper.PrintRow(widthOfTable, "FULLNAME", "EMAIL", "PHONE NUMBER", "GITHUB URL");
                Helper.PrintLine(widthOfTable);


                foreach (var user in users)
                {

                    Helper.PrintRow(widthOfTable, user.FullName, user.Email, user.PhoneNumber, user.Github);
                }

                Helper.PrintLine(widthOfTable);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

        }

        public async Task PrintAllUsers()
        {
            try
            {
                var users = await userService.GetAllUsersAsync();

                int widthOfTable = 85;
                //Console.Clear();

                Helper.PrintLine(widthOfTable);
                Helper.PrintRow(widthOfTable, "FULLNAME", "EMAIL", "PHONE NUMBER", "GITHUB URL");
                Helper.PrintLine(widthOfTable);


                foreach (var user in users)
                {

                    Helper.PrintRow(widthOfTable, user.FullName, user.Email, user.PhoneNumber, user.Github);
                }

                Helper.PrintLine(widthOfTable);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }


            #region

            /*
            String header = @"
            |--------------------------|------------------------|-------------------|---------------------------------|
            |FullName                  |Email                   |Phone Number       |   Github URL                    |
            |--------------------------|------------------------|-------------------|---------------------------------|
             ";

                        string body = "", output = "";

                        string footer = @"
            |--------------------------|------------------------|-------------------|---------------------------------|
                        ";

                        foreach (var user in users)
                        {
                            body += $@"
            |{user.FullName}    |{user.Email}    |{user.PhoneNumber}        |{user.Github}    |
            ";
                        }
            */
            //output = header + body + footer;
            //Console.WriteLine(output);

            #endregion
        }
    }
}
