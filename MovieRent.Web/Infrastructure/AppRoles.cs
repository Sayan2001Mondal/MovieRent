using System.Text.Json.Serialization;

namespace MovieRent.Web.Infrastructure
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AppRoles
    {
        User = 1,
        Admin = 2,
    }
}
