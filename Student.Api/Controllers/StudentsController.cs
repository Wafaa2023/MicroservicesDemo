using Student.Domain.Data;
using Microsoft.AspNetCore.Mvc;
using Common.Service.IServices;

namespace Students.Api.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IBaseService<Student.Domain.Models.Student> _baseService;
		private readonly StudentDbContext _studentDbContext;
        public StudentsController(IBaseService<Student.Domain.Models.Student> baseService, StudentDbContext studentDbContext)
        {
            _baseService = baseService;
			_studentDbContext = studentDbContext;

		}
        [HttpGet(nameof(GetStudentById))]
        public IActionResult GetStudentById(int Id)
        {
            var obj = _baseService.Get(Id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpGet(nameof(GetAllStudent))]
        public IActionResult GetAllStudent()
        {
            var obj = _baseService.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost(nameof(CreateStudent))]
        public IActionResult CreateStudent(Student.Domain.Models.Student student)
        {
            if (student != null)
            {
                _baseService.Insert(student);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }
        [HttpPost(nameof(UpdateStudent))]
        public IActionResult UpdateStudent(Student.Domain.Models.Student student)
        {
            if (student != null)
            {
                _baseService.Update(student);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete(nameof(DeleteStudent))]
        public IActionResult DeleteStudent(Student.Domain.Models.Student student)
        {
            if (student != null)
            {
                _baseService.Delete(student);
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
        
    }
}