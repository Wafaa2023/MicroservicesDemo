

namespace Student.Service.IServices
{
	public interface IStudentService
	{
		IEnumerable<Domain.Models.Student> GetStudentsBySchoolId(int schoolId);
	}
}
