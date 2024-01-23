
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Common.Service.IServices
{
	public interface IBaseService<T> where T : class
	{
		IEnumerable<T> GetAll();
		IQueryable<T> GetAll(
		Expression<Func<T, bool>> predicate = null,
		Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
		Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
		bool disableTracking = true,
		bool ignoreQueryFilters = false);
	    T GetFirstOrDefault(
			   Expression<Func<T, bool>> predicate = null,
			   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			   Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
			   bool disableTracking = true,
			   bool ignoreQueryFilters = false);
		T Get(int Id);
		void Insert(T entity);
		void Update(T entity);
		void Delete(T entity);
	}


}
