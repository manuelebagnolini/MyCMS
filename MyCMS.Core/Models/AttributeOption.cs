namespace MyCMS.Core.Models
{
    public class AttributeOption
    {
        public int AttributeOptionID { get; set; }
        public int AttributeID { get; set; }
        public string Value { get; set; }

        public Attribute Attribute { get; set; }
    }
}
