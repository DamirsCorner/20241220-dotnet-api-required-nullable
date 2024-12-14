namespace RequiredAndNullable.Models;

public class SampleRequest
{
    public string? Optional { get; set; }

    public required string Required { get; set; }
}
