using System.ComponentModel.DataAnnotations;

namespace CSCPA.Web.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public string Email { get; set; }
    }


}
