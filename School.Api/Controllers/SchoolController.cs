using School.Domain.Data;
using Microsoft.AspNetCore.Mvc;
using Common.Service.IServices;
using Grpc.Net.Client;
using Student.Api.Protos;
using Grpc.Core;


namespace Schools.Api.Controllers
{
	[Route("api/Schools")]
	[ApiController]
	public class SchoolController : ControllerBase
	{
		private readonly IBaseService<School.Domain.Models.School> _baseService;
		private readonly SchoolDbContext _SchoolDbContext;
		public SchoolController(IBaseService<School.Domain.Models.School> customService, SchoolDbContext SchoolDbContext)
		{
			_baseService = customService;
			_SchoolDbContext = SchoolDbContext;
		}

		[HttpGet(nameof(GetAllSchool))]
		public IActionResult GetAllSchool()
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
		[HttpGet(nameof(GetAllSchoolByFilter))]
		public IActionResult GetAllSchoolByFilter(string addres="Alex")
		{
			var obj = _baseService.GetAll(s=>s.Address== addres);
			if (obj == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(obj);
			}
		}
		
		[HttpGet(nameof(GetSchoolById))]
		public IActionResult GetSchoolById(int Id)
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
		
		[HttpPost(nameof(CreateSchool))]
		public IActionResult CreateSchool(School.Domain.Models.School School)
		{
			if (School != null)
			{
				_baseService.Insert(School);
				return Ok("Created Successfully");
			}
			else
			{
				return BadRequest("Somethingwent wrong");
			}
		}
		[HttpPost(nameof(UpdateSchool))]
		public IActionResult UpdateSchool(School.Domain.Models.School School)
		{
			if (School != null)
			{
				_baseService.Update(School);
				return Ok("Updated SuccessFully");
			}
			else
			{
				return BadRequest();
			}
		}
		[HttpDelete(nameof(DeleteSchool))]
		public IActionResult DeleteSchool(School.Domain.Models.School school)
		{
			if (school != null)
			{
				_baseService.Delete(school);
				return Ok("Deleted Successfully");
			}
			else
			{
				return BadRequest("Something went wrong");
			}
		}

		// Call the remote student microservice to get students  who've applied to the school

		[HttpGet(nameof(GetStudentsBySchoolId))]
		public IActionResult GetStudentsBySchoolId(int schoolId)
		{
			try
			{
				var channel = GrpcChannel.ForAddress("https://localhost:7256");
				var studentClient = new StudentContract.StudentContractClient(channel);

				var request = new GetStudentsBySchoolIdRequest { SchoolId = schoolId };

				var response = studentClient.GetStudentsBySchoolId(request);

				// Check if the gRPC call was successful
				if (response != null && response != null)
				{
					return Ok(response); 
				}
				else
				{
					return NotFound("No students found for the given school ID."); 
				}
			}
			// Handle gRPC-specific exceptions
			catch (RpcException ex)
			{
				Console.WriteLine($"Error communicating with Student microservice: {ex.Status}");
				return StatusCode(500, "Internal Server Error"); 
			}
			// Handle other exceptions
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
				return StatusCode(500, "Internal Server Error"); 
			}
		}

	}
}