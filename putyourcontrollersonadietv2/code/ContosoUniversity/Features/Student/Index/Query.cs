namespace ContosoUniversity.Features.Student.Index
{
    using MediatR;

    public class Query : IRequest<Result>
    {
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
        public string SearchString { get; set; }
        public int? Page { get; set; }
    }
}