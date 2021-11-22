using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MvcMovie.Models
{
    public class sanpham
    {
        [Key]
        public string spID { get; set; }
        public string tensp { get; set; }

        public string CategoryID { get; set; }

        public Category Category { get; set; }
    }
}

//dotnet-aspnet-codegenerator controller -name sanphamsController -m sanpham -dc MvcMovieContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite
