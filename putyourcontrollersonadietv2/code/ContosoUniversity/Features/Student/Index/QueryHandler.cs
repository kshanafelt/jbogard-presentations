namespace ContosoUniversity.Features.Student.Index
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using DAL;
    using Infrastructure;
    using MediatR;

    public class QueryHandler : IRequestHandler<Query, Result>
    {
        private readonly SchoolContext db;

        public QueryHandler(SchoolContext db)
        {
            this.db = db;
        }

        public Result Handle(Query message)
        {
            var model = new Result
            {
                CurrentSort = message.SortOrder,
                NameSortParm = String.IsNullOrEmpty(message.SortOrder) ? "name_desc" : "",
                DateSortParm = message.SortOrder == "Date" ? "date_desc" : "Date",
            };

            if (message.SearchString != null)
            {
                message.Page = 1;
            }
            else
            {
                message.SearchString = message.CurrentFilter;
            }

            model.CurrentFilter = message.SearchString;
            model.SearchString = message.SearchString;

            var students = from s in db.Students
                            select s;
            if (!String.IsNullOrEmpty(message.SearchString))
            {
                students = students.Where(s => s.LastName.Contains(message.SearchString)
                                                || s.FirstMidName.Contains(message.SearchString));
            }
            switch (message.SortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default: // Name ascending 
                    students = students.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (message.Page ?? 1);
            model.Results = students.ProjectToPagedList<Model>(pageNumber, pageSize);

            return model;
        }
    }
}