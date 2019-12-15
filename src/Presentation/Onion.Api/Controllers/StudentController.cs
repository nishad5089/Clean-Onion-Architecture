using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Students.Commands.CreateStudent;
using Onion.Application.Students.Commands.UpdateStudent;
using Onion.Application.Students.Queries.GetStudentDetail;
using Onion.Application.Students.Queries.GetStudentList;

namespace Onion.Api.Controllers {

    public class StudentController : BaseController {
        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] CreateStudentCommand command) {
            await Mediator.Send (command);
            return Ok ();
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<StudentDetailVm>> Get (Guid id) {
        //     var vm = await Mediator.Send (new GetStudentDetailQuery { Id = id });
        //     return Ok (vm);
        // }

        [HttpGet]
        public async Task<ActionResult<StudentsListVm>> GetAll () {
            
            var vm = await Mediator.Send (new GetStudentsListQuery ());
            return Ok (vm);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> Update ([FromBody] UpdateStudentCommand command) {
            
            await Mediator.Send (command);
            return Ok ();
        }
    }
}