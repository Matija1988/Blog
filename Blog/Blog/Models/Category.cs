using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Category : Entity
    {
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }

        public string CategoryDescription { get; set; }

    }
}
