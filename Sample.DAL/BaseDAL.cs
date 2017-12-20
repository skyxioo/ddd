using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using Sample.IDAL;
using Sample.Model;

namespace Sample.DAL
{
    public abstract class BaseDAL<T> : IBaseDAL<T> where T : class, IEntity
    {
        public BaseDAL()
        {
            SetDbContext();
        }

        public abstract void SetDbContext();

        protected DbContext _dbContext;

        public int Add(T model)
        {
            _dbContext.Set<T>().Add(model);
            return _dbContext.SaveChanges();
        }

        public int AddRange(IEnumerable<T> list)
        {
            _dbContext.Set<T>().AddRange(list);
            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var model = _dbContext.Set<T>().Find(id);
            _dbContext.Entry(model).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public int Delete(T model)
        {
            _dbContext.Set<T>().Remove(model);
            return _dbContext.SaveChanges();
        }
        public int DeleteBy(Expression<Func<T, bool>> whereExp)
        {
            var batch = _dbContext.Set<T>().Where(whereExp).ToList();
            batch.ForEach(p => {
                _dbContext.Set<T>().Remove(p);
            });
            return _dbContext.SaveChanges();
        }
        public int Update(T model, params string[] propertyNames)
        {
            DbEntityEntry<T> entry = _dbContext.Entry<T>(model);
            entry.State = EntityState.Unchanged;
            foreach (var property in propertyNames)
            {
                entry.Property(property).IsModified = true;
            }

            return _dbContext.SaveChanges();
        }
        public int UpdateBy(T model, Expression<Func<T, bool>> whereExp, params string[] propertyNames)
        {
            List<T> batch = _dbContext.Set<T>().Where(whereExp).ToList();
            Type t = typeof(T);
            var propertys = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            Dictionary<string, PropertyInfo> propertyDict = new Dictionary<string, PropertyInfo>();
            propertys.ForEach(p => {
                if (propertyNames.Contains(p.Name))
                    propertyDict.Add(p.Name, p);
            });

            foreach (var property in propertyNames)
            {
                if (propertyDict.ContainsKey(property))
                {
                    PropertyInfo prop = propertyDict[property];
                    var newVal = prop.GetValue(model);
                    foreach (var item in batch)
                    {
                        prop.SetValue(item, newVal);
                    }
                }
            }

            return _dbContext.SaveChanges();
        }
        public T GetEntity(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        public List<T> GetListBy(Expression<Func<T, bool>> whereExp)
        {
            return _dbContext.Set<T>().Where(whereExp).ToList();
        }
        public List<T> GetListBy<TKey>(Expression<Func<T, bool>> whereExp, Expression<Func<T, TKey>> orderExp, bool isAsc)
        {
            if (isAsc)
            {
                return _dbContext.Set<T>().Where(whereExp).OrderBy<T, TKey>(orderExp).ToList();
            }
            else
            {
                return _dbContext.Set<T>().Where(whereExp).OrderByDescending<T, TKey>(orderExp).ToList();
            }
        }
        public List<T> GetPagedListBy<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereExp, Expression<Func<T, TKey>> orderExp, bool isAsc)
        {
            if (isAsc)
            {
                return _dbContext.Set<T>()
                    .Where(whereExp)
                    .OrderBy<T, TKey>(orderExp)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize)
                    .ToList();
            }
            else
            {
                return _dbContext.Set<T>()
                    .Where(whereExp)
                    .OrderByDescending<T, TKey>(orderExp)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize)
                    .ToList();
            }
        }
    }
}
