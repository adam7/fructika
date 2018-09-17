using Newtonsoft.Json;

namespace Fructika.Models
{
    public class Food
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "foodGroupImage")]
        public string FoodGroupImage { get; set; }

        [JsonProperty(PropertyName = "foodGroup")]
        public string FoodGroup { get; set; }

        [JsonProperty(PropertyName = "protein")]
        public decimal? Protein { get; set; }

        [JsonProperty(PropertyName = "totalSugars")]
        public decimal? TotalSugars { get; set; }
        
        [JsonProperty(PropertyName = "sucrose")]
        public decimal? Sucrose { get; set; }
        
        [JsonProperty(PropertyName = "glucose")]
        public decimal? Glucose { get; set; }
        
        [JsonProperty(PropertyName = "fructose")]
        public decimal? Fructose { get; set; }

        [JsonProperty(PropertyName = "lactose")]
        public decimal? Lactose { get; set; }

        [JsonProperty(PropertyName = "maltose")]
        public decimal? Maltose { get; set; }

        [JsonProperty(PropertyName = "dietaryFiber")]
        public decimal? DietaryFiber { get; set; }
    }
}
