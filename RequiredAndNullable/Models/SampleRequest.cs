using System.ComponentModel.DataAnnotations;

namespace RequiredAndNullable.Models;

public class SampleRequest
{
    public string Optional { get; set; }

    [Required]
    public string Required { get; set; }
}
