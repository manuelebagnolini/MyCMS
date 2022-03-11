namespace MyCMS.Core.Entities
{
    public class ContentRelation : BaseEntity
    {
        public int ContentRelationId { get; set; }
        public int ContainerContentId { get; set; }
        public int ReferredContentId { get; set; }
        public int ContentRelationTypeId { get; set; }

        public Content ContainerContent { get; set; }
        public Content ReferredContent { get; set; }
        public ContentRelationType ContentRelationType { get; set; }
    }
}
