using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MvcMovie.Models
{
    public class Category
    {
        [Key]
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}