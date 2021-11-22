using System.ComponentModel.DataAnnotations;
namespace MvcMovie.Models
{
    public class Student : Person
    {
        public string University { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}