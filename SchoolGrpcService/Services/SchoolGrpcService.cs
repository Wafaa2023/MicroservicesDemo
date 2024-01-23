
using Grpc.Core;
using Grpc.Net.Client;
using StudentGrpcService.Protos;

public class SchoolGrpcService
{
	public StudentsResponse CallingGetStudentsBySchoolId(SchoolRequest request, ServerCallContext context)
	{
		// Fetch student information from Student microservice
		var studentsCount = FetchStudentsFromStudentMicroservice(2);

		return studentsCount;
	}

	private StudentsResponse FetchStudentsFromStudentMicroservice(int schoolId)
	{
		try
		{
			// Create a gRPC channel for communication
			var channel = GrpcChannel.ForAddress("https://localhost:5162");

			var studentClient = new StudentContract.StudentContractClient(channel);

			// Call the remote method to get students who've applied to the school
			var studentsResponse = studentClient.GetStudentsBySchoolId(new GetStudentsBySchoolIdRequest { SchoolId = 5 });

			return new StudentsResponse();
		}
		catch (RpcException ex)
		{
			// Handle gRPC-specific exceptions
			throw new Exception("Error communicating with Student microservice", ex);
		}
	}

}
