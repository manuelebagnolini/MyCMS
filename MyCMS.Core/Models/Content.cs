namespace MyCMS.Core.Models
{
    public class Content
    {
        public int ContentID { get; set; }
        public string Title { get; set; }
        public string? Body { get; set; }
        public string? Url { get; set; }
        public int ContentTypeID { get; set; }
        public int CreateUserID { get; set; }
        public DateTime CreateDatetime { get; set; }
        public int ModifyUserID { get; set; }
        public DateTime ModifyDatetime { get; set; }
        
        public ContentType ContentType { get; set; }
        public User CreateUser { get; set; }
        public User ModifyUser { get; set; }
        public ICollection<ContentAttribute> Attributes { get; set; }
        public ICollection<ContentRelation> Contents { get; set; }
        public ICollection<ContentRelation> ReferencedBy { get; set; }
    }
}
