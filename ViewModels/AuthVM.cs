using System.ComponentModel.DataAnnotations;

namespace todoV2.ViewModels
{
    public class AuthVM
    {
        [Required]
        public string username { get; set; }
        [Required, DataType(DataType.Password)]
        public string password { get; set; }
    }
}
