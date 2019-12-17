using Microsoft.Extensions.Configuration;

namespace TestFramework.Areas._5element.Models
{
    public class ProductReview
    {
        public string City { get; set; }
        public int Grade { get; set; }
        public string ProductAdvantages { get; set; }
        public string ProductDisadvantages { get; set; }
        public string ReviewBody { get; set; }

        public ProductReview(IConfiguration configuration)
        {
            City = configuration["WriteProductReply:City"];
            Grade = int.Parse(configuration["WriteProductReply:Grade"]);
            ProductAdvantages = configuration["WriteProductReply:ProductAdvantages"];
            ProductDisadvantages = configuration["WriteProductReply:ProductDisadvantages"];
            ReviewBody = configuration["WriteProductReply:ReviewBody"];
        }
    }
}
