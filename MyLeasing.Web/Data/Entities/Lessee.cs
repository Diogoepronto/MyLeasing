using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyLeasing.Web.Data.Entities
{
    public class Lessee : IEntity
    {
        public int Id { get; set; }

        [Required]
        public int Document { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Fixed Phone")]
        public string FixedPhone { get; set; }

        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }

        public string Address { get; set; }

        [Display(Name = "Profile Picture")]
        public string PhotoUrl { get; set; }
        public User User { get; set; }

        [Display(Name = "Lessee Name")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Full Name with Document")]
        public string FullNameWithDocument => $"{Document} - {FirstName} {LastName}";

        public string PhotoFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(PhotoUrl))
                {
                    return null;
                }
                return $"https://localhost:44329//{PhotoUrl.Substring(1)}";
            }
        }
    }
}
