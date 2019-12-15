using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Onion.Application.Interfaces;
using Onion.Domain.Entity;

namespace Onion.Application.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class Handler : IRequestHandler<UpdateStudentCommand>
        {
            private readonly ICommandRepository<Student> _commandRepository;
            private readonly IQueryRepository<Student> _queryRepository;

            public Handler(ICommandRepository<Student> commandRepository, IQueryRepository<Student> queryRepository)
            {
                _queryRepository = queryRepository;
                _commandRepository = commandRepository;
            }

            public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
            {
                var entity = await _queryRepository.Get(request.Id);
                entity.SetName(request.Name);
                await _commandRepository.Save(cancellationToken);

                return Unit.Value;
            }

            
        }
    }
}