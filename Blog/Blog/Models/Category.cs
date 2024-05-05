using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Category : Entity
    {
        [Required]
        [StringLength(50, ErrorMessage = "Maximum allowed number of characters: 50")]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        [StringLength(1000, ErrorMessage ="Maximum allowed number of characters: 1000")]
        public string CategoryDescription { get; set; }


    }
}
