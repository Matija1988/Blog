using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
     
    }
}
