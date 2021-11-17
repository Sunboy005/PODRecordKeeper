using AppServices;
using Services;
using System;
using AppCommon;
using Commons;

namespace View.UI
{
    public class InputCollect
    {

        IUserService userService = GlobalConfig._userService;

        public string id, firstname, lastname, email, phone, github;

        public string InputUserId()
        {
            Console.Write("UserId: ");
            id = Console.ReadLine();
            return id;
        }

        public string InputFirstName()
        {
            Console.Write("FirstName: ");
            firstname = Console.ReadLine();
            return Helper.SanitizeString(firstname);
        }

        public string InputLastName()
        {
            Console.Write("LastName: ");
            lastname = Console.ReadLine();
            return Helper.SanitizeString(lastname);
        }

        public string InputEmail()
        {
            Console.Write("Email: ");
            email = Console.ReadLine();
            if (!Validate.IsValidEmail(email))
            {
                Console.WriteLine("Please enter a valid email address");
                email = InputEmail();
            }
            return email;
        }

        public string InputPhoneNumber()
        {
            Console.Write("Phone Number: ");
            phone = Console.ReadLine();
            if (!Validate.IsPhoneNumber(phone))
            {
                Console.WriteLine("Please enter a valid phone number");
                phone = InputPhoneNumber();
            }
            return phone;
        }

        public string InputGithubURL()
        {
            Console.Write("Github URL: ");
            github = Console.ReadLine();
            if (!Validate.IsValidURL(github))
            {
                Console.WriteLine("Please enter a valid URL");
                github = InputGithubURL();
            }
            return github;
        }

        public void UserInput()
        {
            char choice = 'y';

            while (choice == 'y')
            {
                InputFirstName();
                InputLastName();
                InputEmail();
                InputPhoneNumber();
                InputGithubURL();

                userService.RegisterUserAsync(firstname, lastname, email, phone, github);
                Console.Clear();
                Console.Write("Would You Like to Register More User (y/n) ");

                choice = Console.ReadLine().ToCharArray()[0];
            }

        }

        public void EditUserInput()
        {
            InputUserId();
            InputFirstName();
            InputLastName();
            InputEmail();
            InputPhoneNumber();
            InputGithubURL();

            userService.EditUserAsync(id, firstname, lastname, email, phone, github);

        }

    }
}
