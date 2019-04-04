
namespace Lab04Tyshchenko.Model
{
    class DescriptionValueBinder
    {
        public SortingEnum Value { get; set; }
        public string Description { get; set; }

        public DescriptionValueBinder()
        {
        }

        public DescriptionValueBinder(SortingEnum value, string description)
        {
            Value = value;
            Description = description;
        }
    }

}
