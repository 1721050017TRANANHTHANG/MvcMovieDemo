using System.ComponentModel.DataAnnotations;
namespace MvcMovie.Models
{
    public class Product
    {
        [Key]
        public string ProductID { get; set; } = null!;

        public string ProductName { get; set; } = null!;
        public string CategoryID { get; set; } = null!;
        public Category Category { get; set; } = null!;
    }
}