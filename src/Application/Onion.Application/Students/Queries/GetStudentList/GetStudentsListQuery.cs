using System.Collections.Generic;
using MediatR;

namespace Onion.Application.Students.Queries.GetStudentList
{
    public class GetStudentsListQuery : IRequest<List<StudentLookupDto>>
    {
        
    }
}