using MyCMS.Web.Sample.Data.GraphQL;

namespace MyCMS.Web.Sample.Data.Articles;

public class ArticleService
{
    MyCMSClient _client;

    public ArticleService(MyCMSClient client)
    {
        _client = client;
    }

    string FormatDateTime(DateTimeOffset offset)
    {
        return string.Format("{0} at {1}", offset.DateTime.ToShortDateString(), offset.DateTime.ToShortTimeString());
    }

    void ValidateArgs(int? first = null, int? last = null, string after = null, string before = null)
    {
        if (first == null && last == null)
        {
            throw new Exception("Argumenst error: 'first' and 'last' are both null, specify at least one");
        }
    }

    string FormatArticleValue(MyCMS.Web.Sample.Data.GraphQL.IGetArticles_Content_Edges_Node_Attributes model)
    {
        if (model.Attribute.AttributeType == AttributeTypes.Select)
        {
            return model.AttributeOption.Value;
        }
        if (model.Attribute.AttributeType == AttributeTypes.Date)
        {
            if (model.ValueDate != null)
            {
                return FormatDateTime(model.ValueDate.Value);
            }
        }
        if (model.Attribute.AttributeType == AttributeTypes.Number)
        {
            return model.ValueNumber.ToString();
        }
        
        return model.ValueText;
    }

    public async Task<ArticlesViewModel> GetArticlesViewModelAsync(int? first = null, int? last = null, string after = null, string before = null)
    {
        ValidateArgs(first, last, after, before);

        var viewModel = new ArticlesViewModel();

        var result = await _client.GetArticles.ExecuteAsync(first, last, after, before);
        
        var content = result.Data.Content;

        viewModel.HasNextPage = content.PageInfo.HasNextPage;
        viewModel.HasPreviousPage = content.PageInfo.HasPreviousPage;
        viewModel.StartCursor = content.PageInfo.StartCursor;
        viewModel.EndCursor = content.PageInfo.EndCursor;

        viewModel.Articles = content.Edges.Select(x => new ArticlesViewModel.Article
        {
            Cursor = x.Cursor,
            Title = x.Node.Title,
            Body = x.Node.Body,
            CreateUser = x.Node.CreateUser.Username,
            CreateDatetime = FormatDateTime(x.Node.CreateDatetime),
            Attributes = x.Node.Attributes.Select(a => new ArticlesViewModel.Attribute
            {
                Name = a.Attribute.Name,
                Value = FormatArticleValue(a) 
            }),
            HeaderImages = x.Node.HeaderImages
                .Select(i => new ArticlesViewModel.Image
            {
                Title = i.ReferredContent.Title,
                Url = i.ReferredContent.Url
            }).ToArray(),
        }).ToArray();

        return viewModel;
    }
}