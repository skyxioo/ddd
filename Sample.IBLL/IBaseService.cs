﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using  Sample.Model;

namespace Sample.IBLL
{
    public interface IBaseService<T> where T : class ,IEntity
    {
        int Add(T model);
        int AddRange(IEnumerable<T> list);
        int Delete(int id);
        int Delete(T model);
        int DeleteBy(Expression<Func<T, bool>> whereExp);
        int Update(T model, params string[] propertyNames);
        int UpdateBy(T model, Expression<Func<T, bool>> whereExp, params string[] propertyNames);
        T GetEntity(int id);
        IQueryable<T> GetListBy(Expression<Func<T, bool>> whereExp);
        IQueryable<T> GetListBy<TKey>(Expression<Func<T, bool>> whereExp, Expression<Func<T, TKey>> orderExp, bool isAsc = true);
        List<T> GetPagedListBy<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereExp, Expression<Func<T, TKey>> orderExp, bool isAsc, out int count);
    }
}
