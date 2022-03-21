    namespace MyCMS.Web.Sample.Data.Articles;
    
    public class ArticlesViewModel : ICursorPaging
    {
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public string StartCursor { get; set; }
        public string EndCursor { get; set; }
      
        public IEnumerable<Article> Articles { get; set; }

        public class Article
        {
            public string Cursor { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
            public string CreateUser { get; set; }

            public string CreateDatetime { get; set; }

            public IEnumerable<Attribute> Attributes { get; set; }

            public IEnumerable<Image> HeaderImages { get; set; }
        }

        public class Attribute
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        public class Image
        {
            public string Title { get; set; }
            public string Url { get; set; }
        }
    }