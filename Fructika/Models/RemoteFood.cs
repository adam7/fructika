using Newtonsoft.Json;

namespace Fructika.Models
{
    public class RemoteFood
    {
        public string ExternalId { get; set; }
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }
        public string Description { get; set; }
        public string FoodGroupImage { get; set; }
        public string FoodGroup { get; set; }
        public double? Protein { get; set; }
        public double? TotalSugars { get; set; }
        public double? Sucrose { get; set; }
        public double? Glucose { get; set; }
        public double? Fructose { get; set; }
        public double? Lactose { get; set; }
        public double? Maltose { get; set; }
        public double? DietaryFiber { get; set; }
    
}
}
