
using Common.Domain.Models;
using Domain.Models;

namespace Student.Domain.Models
{
	public class Student : AuditableEntity
	{

		public string? Name
		{
			get;
			set;
		}

		public string? Address
		{
			get;
			set;
		}
		public int? Age
		{
			get;
			set;
		}
		public int? SchoolID
		{
			get;
			set;
		}
	}

}
