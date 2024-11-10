using System.Text.Json.Serialization;

namespace eCommerce.Application.Common.Bases;
public class BaseReponseGeneric<T>
{
    public T? Data { get; set; }
    public string? Message { get; set; }

    [JsonPropertyName("obejct_id")]
    public string? ObjectId { get; set; }
}
