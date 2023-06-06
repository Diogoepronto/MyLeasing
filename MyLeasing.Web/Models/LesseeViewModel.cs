using Microsoft.AspNetCore.Http;
using MyLeasing.Web.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyLeasing.Web.Models
{
    public class LesseeViewModel : Lessee
    {
        [Display(Name = "Profile Picture")]
        public IFormFile Photo { get; set; }
    }
}
