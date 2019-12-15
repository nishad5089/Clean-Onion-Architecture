using System;
using MediatR;

namespace Onion.Application.Students.Queries.GetStudentDetail
{
    public class GetStudentDetailQuery : IRequest<StudentDetailVm>
    {
         public Guid Id { get; set; }
    }
}