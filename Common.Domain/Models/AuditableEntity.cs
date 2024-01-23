using Common.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class AuditableEntity:BaseEntity
	{
		public DateTime CreatedDate
		{
			get;
			set;
		}
		public int CreatedBy
		{
			get;
			set;
		}
		public int ModifiedBy
		{
			get;
			set;
		}

		public DateTime ModifiedDate
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}
	}
}
