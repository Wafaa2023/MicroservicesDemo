using Grpc.Core;
using Student.Api.Protos;
using Student.Service.IServices;
public class GrpcStudentService : StudentContract.StudentContractBase
{
	private readonly IStudentService _studentService;

	public GrpcStudentService(IStudentService studentService)
	{
		_studentService = studentService;
	}

	public override Task<GetStudentsBySchoolIdResponse> GetStudentsBySchoolId(GetStudentsBySchoolIdRequest request, ServerCallContext context)
	{
		var students =  _studentService.GetStudentsBySchoolId(request.SchoolId);

		try
		{
			// Map properties from domain model to proto model
			var protoStudents = students.Select(student => new Student.Api.Protos.Student
			{
				Id = student.Id,
				Name = student.Name,
				Age =Convert.ToInt32(student.Age)
			}).ToList();

			var response = new GetStudentsBySchoolIdResponse();
			response.Students.AddRange(protoStudents);
			return Task.FromResult(response);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error in GetStudentsBySchoolId: {ex.Message}");
			throw;
		}
	}
}