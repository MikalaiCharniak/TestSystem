using Microsoft.Extensions.Configuration;

namespace TestFramework.Areas._5element.Models
{
    public class ProductQuestion
    {
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string QuestionBody { get; set; }

        public ProductQuestion(IConfiguration configuration)
        {
            City = configuration["WriteProductQuestion:City"];
            PhoneNumber = configuration["WriteProductQuestion:PhoneNumber"];
            QuestionBody = configuration["WriteProductQuestion:QuestionBody"];
        }
    }
}
