using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MvcMovie.Models
{
    public class Loaisanpham
    {
        [Key]
        public string lspID { get; set; }
        public string tenloai { get; set; }
        public ICollection<sanpham> sanpham { get; set; }
    }
}