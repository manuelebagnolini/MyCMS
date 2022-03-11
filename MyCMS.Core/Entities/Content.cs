namespace MyCMS.Core.Entities
{
    public class Content : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }
        public int ContentTypeId { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDatetime { get; set; }
        public int ModifyUserId { get; set; }
        public DateTime ModifyDatetime { get; set; }
        
        public ContentType ContentType { get; set; }
        public User CreateUser { get; set; }
        public User ModifyUser { get; set; }
        public ICollection<ContentAttribute> Attributes { get; set; }
        public ICollection<ContentRelation> Contents { get; set; }
        public ICollection<ContentRelation> ReferencedBy { get; set; }
    }
}
