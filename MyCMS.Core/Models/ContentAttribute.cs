namespace MyCMS.Core.Models
{
    public class ContentAttribute
    {
        public int ContentAttributeID { get; set; }
        public int ContentID { get; set; }
        public int AttributeID { get; set; }
        public string? ValueText { get; set; }
        public int? ValueNumber { get; set; }
        public DateTime? ValueDate { get; set; }
        public int? AttributeOptionID { get; set; }

        public Content Content { get; set; }
        public Attribute Attribute { get; set; }
        public AttributeOption? AttributeOption { get; set; }
    }
}
