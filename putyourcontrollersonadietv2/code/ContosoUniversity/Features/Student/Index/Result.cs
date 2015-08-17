namespace ContosoUniversity.Features.Student.Index
{
    using PagedList;

    public class Result
    {
        public string CurrentSort { get; set; }
        public string NameSortParm { get; set; }
        public string DateSortParm { get; set; }
        public string CurrentFilter { get; set; }
        public string SearchString { get; set; }

        public IPagedList<Model> Results { get; set; }
    }
}