﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using System.Text;
using System.Threading.Tasks;
using Shiftwise._52cards.mvc.DataEntities;

namespace Shiftwise._52cards.mvc.repository
{
    public interface IGenericDataRepository<T> where T : class, IEntity
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        void Add(params T[] items);
        void AddRange(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
        IQueryable<T> Queryable(bool tracking);
    }

}
