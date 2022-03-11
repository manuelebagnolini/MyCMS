namespace MyCMS.Core.Models
{
    public class ContentRelation
    {
        public int ContentRelationID { get; set; }
        public int ContainerContentID { get; set; }
        public int ReferredContentID { get; set; }
        public int ContentRelationTypeID { get; set; }

        public Content ContainerContent { get; set; }
        public Content ReferredContent { get; set; }
        public ContentRelationType ContentRelationType { get; set; }
    }
}
