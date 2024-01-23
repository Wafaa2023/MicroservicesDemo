using Common.Repository.IRepository;
using Common.Service.IServices;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace School.Service.Services
{
	public class SchoolService : IBaseService<Domain.Models.School>
	{
		private readonly IRepository<Domain.Models.School> _repository;
		public SchoolService(IRepository<Domain.Models.School> repository)
		{
			_repository = repository;
		}
		public IEnumerable<Domain.Models.School> GetAll()
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
		public IQueryable<Domain.Models.School> GetAll(
		Expression<Func<Domain.Models.School, bool>> predicate = null,
		Func<IQueryable<Domain.Models.School>, IOrderedQueryable<Domain.Models.School>> orderBy = null,
		Func<IQueryable<Domain.Models.School>, IIncludableQueryable<Domain.Models.School, object>> include = null,
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
		public virtual Domain.Models.School GetFirstOrDefault(
			Expression<Func<Domain.Models.School, bool>> predicate = null,
			Func<IQueryable<Domain.Models.School>, IOrderedQueryable<Domain.Models.School>> orderBy = null,
			Func<IQueryable<Domain.Models.School>, IIncludableQueryable<Domain.Models.School, object>> include = null,
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
		public Domain.Models.School Get(int Id)
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

		public void Insert(Domain.Models.School entity)
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

		public void Update(Domain.Models.School entity)
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
		public void Delete(Domain.Models.School entity)
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
		
	}
}