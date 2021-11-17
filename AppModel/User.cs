using System;

namespace AppModel
{
    public class User
    {
        public string Id = Guid.NewGuid().ToString();

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Github { get; set; }
    }
}
