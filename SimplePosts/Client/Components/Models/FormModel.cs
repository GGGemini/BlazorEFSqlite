using SimplePosts.Shared.Models.Entities;

namespace SimplePosts.Client.Components.Models
{
    public class FormModel
    {
        public string Heading { get; set; }
        public Product Product { get; set; } = new Product();
        public string ButtonText { get; set; }
    }
}
