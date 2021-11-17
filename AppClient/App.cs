using System;
using System.Collections.Generic;
using System.Text;
using AppServices;
using Services;
using View.UI;

namespace AppClient
{
    public class App
    {
        public async static void Run()
        {
            IUserService userService = GlobalConfig._userService;
            InputCollect user = new InputCollect();
            Views view = new Views();
            char? choice;



            while (true)
            {
                Console.WriteLine("Enter '1' for new User(s) Registration " +
                                  "\nEnter '2' to view a User" +
                                  "\nEnter '3' to view all Users" +
                                  "\nEnter '4' to edit User details" +
                                  "\nEnter '5' to search User by name" +
                                  "\nEnter '6' to search User by id" +
                                  "\nEnter '7' to delete User" +
                                  "\nEnter '8' to delete a list of users by a list of user Ids ");
                Console.Write("\nYour Input: ");
                choice = Console.ReadLine().ToCharArray()[0];
                

                if (choice == '1')
                {
                    user.UserInput();
                    //Console.Clear();
                }
                else if (choice == '2')
                {
                    string id = user.InputUserId();
                    await view.PrintUser(id);
                }
                else if (choice == '3')
                {
                    await view.PrintAllUsers();
                }
                else if (choice == '4')
                {
                    user.EditUserInput();
                    //Console.Clear();
                }
                else if (choice == '7')
                {
                    string id = user.InputUserId();
                    await userService.DeleteUserAsync(id);
                    //Console.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                }
            }
        }
    }
}
