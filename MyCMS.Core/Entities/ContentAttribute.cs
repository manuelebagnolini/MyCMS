namespace MyCMS.Core.Entities
{
    public class ContentAttribute : BaseEntity
    {
        public int ContentId { get; set; }
        public int AttributeId { get; set; }
        public string ValueText { get; set; }
        public int? ValueNumber { get; set; }
        public DateTime? ValueDate { get; set; }
        public int? AttributeOptionId { get; set; }

        public Content Content { get; set; }
        public Attribute Attribute { get; set; }
        public AttributeOption AttributeOption { get; set; }
    }
}
