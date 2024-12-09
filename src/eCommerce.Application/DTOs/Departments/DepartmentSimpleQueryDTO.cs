using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs.Departments;
public record DepartmentSimpleQueryDTO
{
    [JsonPropertyName("department_id")]
    public long DepartmentId { get; init; }

    [JsonPropertyName("department_name")]
    public string DepartmentName { get; init; } = string.Empty;
}
