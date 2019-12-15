using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Onion.Application.Interfaces;
using Onion.Domain.Entity;

namespace Onion.Application.Students.Queries.GetStudentList {
    public class GetStudentsListQueryHandler : IRequestHandler<GetStudentsListQuery, List<StudentLookupDto>> {
        private readonly IQueryRepository<Student> _queryRepository;

        public GetStudentsListQueryHandler (IQueryRepository<Student> queryRepository) {
            _queryRepository = queryRepository;

        }
        public async Task<List<StudentLookupDto>> Handle (GetStudentsListQuery request, CancellationToken cancellationToken) {
            var students = await _queryRepository.GetAll ();
            // Students = (IEnumerable<StudentLookupDto>) students
           // var vm = new StudentsListVm ();
             var vm = new List<StudentLookupDto>();
            foreach (var student in students) {
               
                vm.Add(new StudentLookupDto{
                    Name = student.Name
                });
            }
            return vm;
        }
    }
}