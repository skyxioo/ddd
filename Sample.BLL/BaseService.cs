using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sample.IBLL;
using Sample.IDAL;
using Sample.Inject;
using Sample.Model;

namespace Sample.BLL
{
    public abstract class BaseService<T> : IBaseService<T> where T : class ,IEntity
    {
        public BaseService()
        {
            SetDAL();
        }

        public abstract void SetDAL();

        protected IBaseDAL<T> CurrentDAL;

        private IDbSession _currentDbSession;

        public IDbSession CurrentDbSession
        {
            get
            {
                if (_currentDbSession == null)
                {
                    IDbSessionFactory dbSessionFactory = Ioc.GetObject<IDbSessionFactory>("DbSessionFactory");
                    _currentDbSession = dbSessionFactory.GetDbSession();
                }
                return _currentDbSession;
            }
        }

        public int Add(T model)
        {
            return CurrentDAL.Add(model);
        }

        public int Delete(int id)
        {
            return CurrentDAL.Delete(id);
        }

        public int Delete(T model)
        {
            return CurrentDAL.Delete(model);
        }

        public int DeleteBy(Expression<Func<T, bool>> whereExp)
        {
            return CurrentDAL.DeleteBy(whereExp);
        }

        public int Update(T model, params string[] propertyNames)
        {
            return CurrentDAL.Update(model, propertyNames);
        }

        public int UpdateBy(T model, Expression<Func<T, bool>> whereExp, params string[] propertyNames)
        {
            return CurrentDAL.UpdateBy(model, whereExp, propertyNames);
        }

        public T GetEntity(int id)
        {
            return CurrentDAL.GetEntity(id);
        }

        public List<T> GetListBy(Expression<Func<T, bool>> whereExp)
        {
            return CurrentDAL.GetListBy(whereExp);
        }

        public List<T> GetListBy<TKey>(Expression<Func<T, bool>> whereExp, Expression<Func<T, TKey>> orderExp,
            bool isAsc)
        {
            return CurrentDAL.GetListBy(whereExp, orderExp, isAsc);
        }

        public List<T> GetPagedListBy<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereExp,
            Expression<Func<T, TKey>> orderExp, bool isAsc)
        {
            return CurrentDAL.GetPagedListBy(pageIndex, pageSize, whereExp, orderExp, isAsc);
        }
    }
}
