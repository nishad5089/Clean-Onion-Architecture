using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Onion.Application.Interfaces;
using Onion.Domain.Entity;

namespace Onion.Application.Students.Queries.GetStudentDetail {
    public class GetStudentDetailQueryHandler : IRequestHandler<GetStudentDetailQuery, StudentDetailVm> {
        private readonly IQueryRepository<Student> _queryRepository;

        public GetStudentDetailQueryHandler (IQueryRepository<Student> context) {
            _queryRepository = context;
        }

        public async Task<StudentDetailVm> Handle (GetStudentDetailQuery request, CancellationToken cancellationToken) {
            var entity = await _queryRepository.Get (request.Id);

            var studentDetailVm = new StudentDetailVm () {
                Name = entity.Name
            };
            return studentDetailVm;
        }
    }
}