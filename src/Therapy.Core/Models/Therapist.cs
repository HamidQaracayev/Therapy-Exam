using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Therapy.Core.Models;

public class Therapist : BaseEntity
{
    [Required]
    [StringLength(maximumLength: 60)]
    public string FullName { get; set; }
    [Required]
    [StringLength(maximumLength: 60)]
    public string Profession { get; set; }
    [Required]
    [StringLength(maximumLength: 123)]
    public string FbUrl { get; set; }
    [Required]
    [StringLength(maximumLength: 123)]
    public string IgUrl { get; set; }
    [Required]
    [StringLength(maximumLength: 123)]
    public string TwitterUrl { get; set; }
    [Required]
    [StringLength(maximumLength: 123)]
    public string LinkedinUrl { get; set; }

    public string? ImageUrl { get; set; }
    [NotMapped]
    public IFormFile? Image { get; set; }
}
