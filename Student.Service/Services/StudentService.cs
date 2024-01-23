using Common.Repository.IRepository;
using Common.Service.IServices;
using Microsoft.EntityFrameworkCore.Query;
using Student.Service.IServices;
using System.Linq.Expressions;

namespace Student.Service.Services
{
	public class StudentService : IBaseService<Domain.Models.Student>,IStudentService
	{
		private readonly IRepository<Domain.Models.Student> _repository;
		public StudentService(IRepository<Domain.Models.Student> repository)
		{
			_repository = repository;
		}
		public IEnumerable<Domain.Models.Student> GetAll()
		{
			try
			{
				var obj = _repository.GetAll();

				if (obj != null)
				{
					return obj;
				}
				else
				{
					return null;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
		public IQueryable<Domain.Models.Student> GetAll(
		Expression<Func<Domain.Models.Student, bool>> predicate = null,
		Func<IQueryable<Domain.Models.Student>, IOrderedQueryable<Domain.Models.Student>> orderBy = null,
		Func<IQueryable<Domain.Models.Student>, IIncludableQueryable<Domain.Models.Student, object>> include = null,
		bool disableTracking = true,
		bool ignoreQueryFilters = false)
		{
			try
			{
				var obj = _repository.GetAll(predicate, orderBy, include, disableTracking, ignoreQueryFilters);
				if (obj != null)
				{
					return obj;
				}
				else
				{
					return null;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
		public virtual Domain.Models.Student GetFirstOrDefault(
			Expression<Func<Domain.Models.Student, bool>> predicate = null,
			Func<IQueryable<Domain.Models.Student>, IOrderedQueryable<Domain.Models.Student>> orderBy = null,
			Func<IQueryable<Domain.Models.Student>, IIncludableQueryable<Domain.Models.Student, object>> include = null,
			bool disableTracking = true,
			bool ignoreQueryFilters = false)
		{
			try
			{
				var obj = _repository.GetFirstOrDefault(predicate, orderBy, include, disableTracking, ignoreQueryFilters);
				if (obj != null)
				{
					return obj;
				}
				else
				{
					return null;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
		public Domain.Models.Student Get(int Id)
		{
			try
			{
				var obj = _repository.Get(Id);
				if (obj != null)
				{
					return obj;
				}
				else
				{
					return null;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public void Insert(Domain.Models.Student entity)
		{
			try
			{
				if (entity != null)
				{
					_repository.Insert(entity);
					_repository.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public void Update(Domain.Models.Student entity)
		{
			try
			{
				if (entity != null)
				{
					_repository.Update(entity);
					_repository.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
		public void Delete(Domain.Models.Student entity)
		{
			try
			{
				if (entity != null)
				{
					_repository.Delete(entity);
					_repository.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
		public IEnumerable<Domain.Models.Student> GetStudentsBySchoolId(int schoolId)
		{
			try
			{
				var studentsNamesList = _repository.GetAll().Where(s => s.SchoolID == schoolId);
				if (studentsNamesList != null)
				{
					return studentsNamesList;
				}
				else
				{
					return null;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}