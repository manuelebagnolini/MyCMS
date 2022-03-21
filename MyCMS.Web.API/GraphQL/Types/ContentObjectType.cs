using MyCMS.Core.Entities;

namespace MyCMS.Web.API.GraphQL.Types
{
    public class ContentObjectType : ObjectType<Content>
    {
        protected override void Configure(IObjectTypeDescriptor<Content> descriptor)
        {
            descriptor
                .Field(f => f.Attributes)
                .UseFiltering()
                .UseSorting();

            descriptor
                .Field(f => f.Contents)
                .UseFiltering()
                .UseSorting();

            descriptor
                .Field(f => f.ReferencedBy)
                .UseFiltering()
                .UseSorting();
        }
    }
}
