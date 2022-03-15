namespace MyCMS.Web.Sample.Data;

public interface ICursorPaging
{
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }
    public string StartCursor { get; set; }
    public string EndCursor { get; set; }
}