using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs.Departments;
public class DepartmentCommandDTO
{
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public long? Id { get; set; }
    public string Name { get; init; } = string.Empty;
}