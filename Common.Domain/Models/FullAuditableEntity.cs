using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class FullAuditableEntity<T>
	{
		public bool IsDeleted
		{ 
			get; 
			set; 
		}
		public DateTime DeletedDate
		{
			get;
			set;
		}
		public int DeleatedBy
		{
			get;
			set;
		}
		
	}
}
