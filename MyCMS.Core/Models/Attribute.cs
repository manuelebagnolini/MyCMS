namespace MyCMS.Core.Models
{
    public enum AttributeTypes
    {
        Text,
        Number,
        Date,
        Select
    }

    public class Attribute
    {
        public int AttributeID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public AttributeTypes AttributeType { get; set; }

        public ICollection<AttributeOption> Options { get; set; }
    }
}
