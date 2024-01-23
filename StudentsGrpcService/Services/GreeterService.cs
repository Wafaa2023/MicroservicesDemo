using Grpc.Core;

namespace StudentsGrpcService.Services
{
	public class GreeterService : Greeter.GreeterBase
	{
		public Task<StudentListResponse> GetStudentsBySchoolId(SchoolRequest request, ServerCallContext context)
		{
			// Fetch a list of students by school ID from your data source
			var students = FetchStudentsBySchoolId(request.SchoolId);

			return Task.FromResult(new StudentListResponse
			{
				Students = { students }
			});
		}

		private List<Student> FetchStudentsBySchoolId(int schoolId)
		{
			// Simulate fetching a list of students by school ID from a data source
			return new List<Student.Domain.Models.Student>
		{
			new Student.Domain.Models.Student
			{
				Name = "John Doe",
				Age = 20,
				Address = "Alex",
				SchoolID = schoolId
			},
            // Add more students as needed
        };

		}
	}

}