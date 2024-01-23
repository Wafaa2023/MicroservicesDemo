using Common.Domain.Models;
using Common.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Common.Repository.Repository
{
	public class Repository<T, C> : IRepository<T> where T : BaseEntity where C : DbContext
	{
		#region property

		private readonly C _context;
		private DbSet<T> entities;

		#endregion property

		#region Constructor

		public Repository(C applicationDbContext)
		{
			_context = applicationDbContext;
			entities = _context.Set<T>();
		}

		#endregion Constructor

		public IEnumerable<T> GetAll()
		{
			return entities.AsEnumerable();
		}
		public IQueryable<T> GetAll(
			Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
			bool disableTracking = true,
			bool ignoreQueryFilters = false)
			{
				// Start with the base queryable for the entity type
				IQueryable<T> query = _context.Set<T>();

				// Apply filtering if provided
				if (predicate != null)
				{
					query = query.Where(predicate);
				}

				// Apply ordering if provided
				if (orderBy != null)
				{
					query = orderBy(query);
				}

				// Apply eager loading for related entities if provided
				if (include != null)
				{
					query = include(query);
				}

				// Optionally disable change tracking
				if (disableTracking)
				{
					query = query.AsNoTracking();
				}

				// Optionally ignore global query filters
				if (ignoreQueryFilters)
				{
					query = query.IgnoreQueryFilters();
				}

				return query;
		}
		public virtual T GetFirstOrDefault(
			Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
			bool disableTracking = true,
			bool ignoreQueryFilters = false)
		{
			IQueryable<T> query = GetAll(predicate, orderBy, include, disableTracking, ignoreQueryFilters);

			return orderBy != null ? orderBy(query).FirstOrDefault() : query.FirstOrDefault();
		}
		public T Get(int Id)
		{
			return entities.FirstOrDefault(c => c.Id == Id);
		}

		public void Insert(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			entities.Add(entity);
			_context.SaveChanges();
		}
		public void Update(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			entities.Update(entity);
			_context.SaveChanges();
		}

		public void Delete(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			entities.Remove(entity);
			_context.SaveChanges();
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}



	}
}