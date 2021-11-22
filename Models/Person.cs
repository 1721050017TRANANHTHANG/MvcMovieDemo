using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Person
    {
        [Key]
        public string PersonID { get; set; } = null!;
        public string FullName { get; set; } = null!;

    }
}