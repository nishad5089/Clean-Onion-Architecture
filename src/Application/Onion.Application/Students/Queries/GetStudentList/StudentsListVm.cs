using System.Collections.Generic;

namespace Onion.Application.Students.Queries.GetStudentList
{
    public class StudentsListVm
    {
         public IList<StudentLookupDto> Students { get; set; }
    }
}