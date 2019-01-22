namespace Fructika.Models
{
    public class FoodGroup
    {
        public FoodGroup(){}

        public FoodGroup(RemoteFoodGroup foodGroup)
        {
            ExternalId= foodGroup.GroupId;
            Name = foodGroup.Name;
            Language = foodGroup.Language;
        }

        public bool Enabled
        {
            get; set;
            //get => Preferences.Get(ExternalId, true);
            //set => Preferences.Set(ExternalId, value);
        }
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string FriendlyName { get => Name; }
        public string Image { get => ExternalId; }
        public string Icon { get => $"icon_{ExternalId}"; }
        public string Language { get; set; }
    }
}
