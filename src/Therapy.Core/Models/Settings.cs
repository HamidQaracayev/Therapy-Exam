using System.ComponentModel.DataAnnotations;

namespace Therapy.Core.Models;

public class Settings : BaseEntity
{
    [StringLength(maximumLength:100)]
    public string? Key { get; set; }
    [Required]
    [StringLength(maximumLength: 100)]
    public string Value { get; set; }
}
