using Azure;
using Grpc.Core;
using Student.Service.IServices;
using StudentGrpcService.Protos;

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
		var response = new GetStudentsBySchoolIdResponse
		{
			//Students = students
		};
		return Task.FromResult(response);
	}
}