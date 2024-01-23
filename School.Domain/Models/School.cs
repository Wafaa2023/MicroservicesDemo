

using Common.Domain.Models;
using Domain.Models;

namespace School.Domain.Models
{
	public class School : AuditableEntity
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

	}

}
