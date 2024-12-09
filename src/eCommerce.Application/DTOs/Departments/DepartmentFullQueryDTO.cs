using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs.Departments;
public record class DepartmentFullQueryDTO
{
    [JsonPropertyName("id")]
    public long DepartmentId { get; init; }

    [JsonPropertyName("name")]
    public string DepartmentName { get; init; } = string.Empty;

    [JsonPropertyName("created_date")]
    public DateTimeOffset? CreatedDate { get; private set; }

    [JsonPropertyName("updated_date")]
    public DateTimeOffset? UpdatedDate { get; private set; }
}
