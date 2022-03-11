using MyCMS.Core.Models;
using MyCMS.Data;

namespace MyCMS.Web.API.Queries
{
    public class ContentQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Content> GetContent([Service] MyCMSContext context)
        {
            return context.Contents;
        }
    }
}
