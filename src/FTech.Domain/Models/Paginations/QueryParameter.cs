namespace FTech.Domain.Models.Paginations
{
    public class QueryParameter
    {
        public PaginationParam Page { get; set; }
    }

    public class PaginationParam
    {
        public int Size { get; set; } = 100;
        public int Index { get; set; } = 1;
    }
}
