using System.Web;

namespace Domain.Base;
public static class PaginationValue {
    public static int limit { get; } = 15;
    public static int page { get; } = 0;
}
public class Pagination
{
    private string[] _orderBy = Array.Empty<string>();

    private int _page = PaginationValue.page;
    private int _limit = PaginationValue.limit;
    private string _searchText = "";

    public int offset => _page * _limit;

    public string searchText {
        get => HttpUtility.UrlDecode(_searchText);
        set => _searchText = value ?? "";
    }

    public int limit {
        get => _limit;
        set {
            _limit = value;
        }
    }

    public int page {
        get => _page;
        set {
            if (value > 0) {
                _page = value;
            }
        }
    }

    public string[]? orderBy {
        get => _orderBy;
        set => _orderBy = value ?? Array.Empty<string>();
    }
}

