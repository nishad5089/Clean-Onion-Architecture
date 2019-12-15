using System;
using MediatR;

namespace Onion.Application.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}