namespace MyCMS.Core.Entities
{
    public class Attribute : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public AttributeTypes AttributeType { get; set; }

        public ICollection<AttributeOption> Options { get; set; }
    }

    public enum AttributeTypes
    {
        Text,
        Number,
        Date,
        Select
    }
}
