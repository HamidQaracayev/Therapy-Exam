using System.ComponentModel.DataAnnotations;

namespace Therapy.Business.ViewModel;

public class AdminLoginViewModel
{
    [Required]
    [StringLength(maximumLength:65)]
    public string Username { get; set; }
    [Required]
    [StringLength(maximumLength:65,MinimumLength =8)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
