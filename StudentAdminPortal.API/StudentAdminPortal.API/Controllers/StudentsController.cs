using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.Models;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
           var students  = await studentRepository.GetStudentsAsync();
            return Ok(mapper.Map<List<Student>>(students));
        }

        [HttpGet]
        [Route("{studentId:guid}"), ActionName("GetStudentAsync")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            var student = await studentRepository.GetStudentAsync(studentId);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Student>(student));
        }

        [HttpPut]
        [Route("{studentId:Guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentRequest request)
        {
           if(await studentRepository.Exists(studentId))
            {
                var updateStudent = await studentRepository.UpdateStudentAsync(studentId, mapper.Map<Entities.Student>(request));
                if(updateStudent != null)
                {
                    return Ok(mapper.Map<Student>(updateStudent));
                }
                return null;
            }
             else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{studentId:Guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
            if(await studentRepository.Exists(studentId))
            {
                var deleteStudent = await studentRepository.DeleteStudentAsync(studentId);
                return Ok(mapper.Map<Student>(deleteStudent));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("newStudent")]
        public async Task<IActionResult> CreateStudentAsync([FromBody] CreateStudentRequest request)
        {
            var newStudent = await studentRepository.CreateStudentAsync(mapper.Map<Entities.Student>(request));
            return Ok(newStudent);
           /* return CreatedAtAction(nameof(GetStudentAsync), new {studentId = newStudent.Id }, mapper.Map<Student>(newStudent));*/
        }   
    }
}
