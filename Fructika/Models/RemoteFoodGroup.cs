using Newtonsoft.Json;

namespace Fructika.Models
{
    public class RemoteFoodGroup
    {
        public string GroupId { get; set; }
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }
        public string Name { get; set; }
        public string FriendlyName { get => Name; }
        public string Image { get => GroupId; }
        public string Icon { get => $"icon_{GroupId}"; }
    }
}
