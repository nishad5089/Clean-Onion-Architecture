using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Onion.Application.Interfaces;
using Onion.Domain.Entity;

namespace Onion.Application.Students.Commands.CreateStudent {
    public class CreateStudentCommand : IRequest {
        public string Name { get; set; }

        public class Handler : IRequestHandler<CreateStudentCommand> {

            private readonly IMediator _mediator;

            private readonly ICommandRepository<Student> _commandRepository;

            public Handler (IMediator mediator, ICommandRepository<Student> commandRepository) {
                _mediator = mediator;
                _commandRepository = commandRepository;
            }

            public async Task<Unit> Handle (CreateStudentCommand request, CancellationToken cancellationToken) {
                var entity = new Student ();
                entity.SetName (request.Name);

                await _commandRepository.Insert (entity);

                await _commandRepository.Save (cancellationToken);

                return Unit.Value;
            }

            
        }
    }
}