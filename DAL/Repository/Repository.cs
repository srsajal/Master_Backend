
using master.DAL.Entity;
using master.DAL.IRepository;
using master.Dto;
using masterDDO.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace master.DAL.Repository
{
    public class Repository<T, Tcontext> : IRepository<T> where T : class where Tcontext : DbContext
    {
        public readonly Tcontext _masterDdoContext;
        protected Repository(Tcontext context)
        {
            this._masterDdoContext = context;
        }
        public async Task<List<T>> get()
        {
            return await _masterDdoContext.Set<T>().ToListAsync();        }
        public async Task<T> GetByIdAsync<TKey>(TKey id)
        {
            return await _masterDdoContext.Set<T>().FindAsync(id);
        }
        public bool add(T entity)
        {
            this._masterDdoContext.Set<T>().Add(entity);
            return true;
        }
        public bool update(T entity)
        {
            this._masterDdoContext.Entry(entity).State = EntityState.Modified;
            return true;
        }
        public void Detach(T entity)
        {
            var entry = _masterDdoContext.Entry(entity);
            if (entry != null)
            {
                entry.State = EntityState.Detached;
            }
        }
        public bool delete(T entity)
        {
            this._masterDdoContext.Set<T>().Remove(entity);
            return true;
        }
        public void saveChangesManage()
        {
            this._masterDdoContext.SaveChanges();
        }
        public async Task saveChangesAsync()
        {
            await this._masterDdoContext.SaveChangesAsync();
        }

        public async Task<ICollection<TResult>> GetSelectedColumnByConditionAsync<TResult>(
            Expression<Func<T, TResult>> selectExpression,
            int pageIndex = 0,
            int pageSize = 10,
            List<FilterParameter> dynamicFilters = null,
            string orderByField = null,
            string orderByOrder = null
        )
        {
            if (pageSize <= 0)
                throw new ArgumentException("pageSize is less or equal to ZERO");
            IQueryable<T> query = this._masterDdoContext.Set<T>();

            if (dynamicFilters != null && dynamicFilters.Any())
            {
                foreach (var filter in dynamicFilters)
                {
                    var dynimicFilterExpression = ExpressionHelper.GetFilterExpression<T>(filter.Field, filter.Value, filter.Operator);
                    query = query.Where(dynimicFilterExpression);
                }
            }
            // Dynamic order by expression
            if (!string.IsNullOrWhiteSpace(orderByField))
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var property = Expression.Property(parameter, orderByField);
                var lambda = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), parameter);

                if (orderByOrder == "ASC")
                {
                    query = query.OrderBy(lambda);
                }
                else
                {
                    query = query.OrderByDescending(lambda);
                }
            }
            var result = await query.Select(selectExpression).Skip(pageIndex).Take(pageSize).ToListAsync();
            return result;
        }

        public async Task<ICollection<TResult>> GetSelectedColumnByConditionAsync<TResult>(
             Expression<Func<T, bool>> filterExpression,
             Expression<Func<T, TResult>> selectExpression,
             int pageIndex = 0,
             int pageSize = 10,
             List<FilterParameter> dynamicFilters = null,
             string orderByField = null,
             string orderByOrder = null
         )
        {
            IQueryable<T> query = this._masterDdoContext.Set<T>().Where(filterExpression);

            if (dynamicFilters != null && dynamicFilters.Any())
            {
                foreach (var filter in dynamicFilters)
                {
                    var dynimicFilterExpression = ExpressionHelper.GetFilterExpression<T>(filter.Field, filter.Value, filter.Operator);
                    query = query.Where(dynimicFilterExpression);
                }
            }
            // Dynamic order by expression
            if (!string.IsNullOrWhiteSpace(orderByField))
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var property = Expression.Property(parameter, orderByField);
                var lambda = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), parameter);

                if (orderByOrder == "ASC")
                {
                    query = query.OrderBy(lambda);
                }
                else
                {
                    query = query.OrderByDescending(lambda);
                }
            }
            var result = await query.Select(selectExpression).Skip(pageIndex).Take(pageSize).ToListAsync();
            return result;
        }
        public async Task<ICollection<TResult>> GetSelectedColumnAsync<TResult>( Expression<Func<T, TResult>> selectExpression)
        {
            IQueryable<T> query = this._masterDdoContext.Set<T>();
            var result = await query.Select(selectExpression).ToListAsync();
            return result;
        }
        public async Task<TResult> GetSelectedIdColumnAsync<TResult, Tkey>(Tkey id,Expression<Func<T, TResult>> selectExpression)
        {

            var query = await this._masterDdoContext.Set<T>().FindAsync(id);
            var result = selectExpression.Compile().Invoke(query);
            return result;
        }

        public int CountWithCondition(Expression<Func<T, bool>> condition, List<FilterParameter> dynamicFilters = null)
        {
            IQueryable<T> query = this._masterDdoContext.Set<T>();

            if (dynamicFilters != null && dynamicFilters.Any())
            {
                foreach (var filter in dynamicFilters)
                {
                    var dynimicFilterExpression = ExpressionHelper.GetFilterExpression<T>(filter.Field, filter.Value, filter.Operator);
                    query = query.Where(dynimicFilterExpression);
                }
            }
            return query.Count(condition);
        }
        public async Task<int> CountWithConditionAsync(Expression<Func<T, bool>> condition, List<FilterParameter> dynamicFilters = null)
        {
            IQueryable<T> query = this._masterDdoContext.Set<T>();

            if (dynamicFilters != null && dynamicFilters.Any())
            {
                foreach (var filter in dynamicFilters)
                {
                    var dynimicFilterExpression = ExpressionHelper.GetFilterExpression<T>(filter.Field, filter.Value, filter.Operator);
                    query = query.Where(dynimicFilterExpression);
                }
            }
            return await query.CountAsync(condition);
        }
    }
}
