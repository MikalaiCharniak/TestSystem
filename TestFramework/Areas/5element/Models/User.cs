using Microsoft.Extensions.Configuration;

namespace TestFramework.Areas._5element.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public User(IConfiguration configuration)
        {
            Email = configuration["LoginUser:Email"]; 
            Password = configuration["LoginUser:Password"];
        }
    }
}
