namespace MyCMS.Core.Entities
{
    public class AttributeOption : BaseEntity
    {
        public int AttributeId { get; set; }
        public string Value { get; set; }

        public Attribute Attribute { get; set; }
    }
}
