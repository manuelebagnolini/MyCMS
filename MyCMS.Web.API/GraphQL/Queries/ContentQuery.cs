﻿using MyCMS.Core.Entities;
using MyCMS.Core.Interfaces;

namespace MyCMS.Web.API.GraphQL.Queries
{
    /// <summary>
    /// Query type registered in GraphQL
    /// </summary>
    public class ContentQuery
    {
        /// <summary>
        /// Main query for inspect content.
        /// </summary>
        /// <param name="contentRepository"></param>
        /// <returns></returns>
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Content> GetContent([Service] IEntityRepository<Content> contentRepository)
        {
            return contentRepository.Query;
        }
    }
}
