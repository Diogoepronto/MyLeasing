using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Data.Entities
{
    public class Owner : IEntity
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
        public string ProfilePictureUrl { get; set; }
        public User User { get; set; }

        [Display(Name = "Owner Name")]
        public string OwnerName => $"{FirstName} {LastName}";

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ProfilePictureUrl))
                {
                    return null;
                }
                return $"https://localhost:44329//{ProfilePictureUrl.Substring(1)}";
            }
        }
    }
}
