﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace amcom.DemoApp
{
	public interface IRepositoryBase<T> where T : EntityBase
	{
		void Insert(T TEntity);
		void Update(T TEntity);
		void Delete(T TEntity);

		T GetById(int pkId);
		T GetByPredicate(Expression<Func<T, bool>> predicate);

		List<T> GetAll();
		List<T> GetAllByPredicate(Expression<Func<T, bool>> predicate);

		bool Any();
	}
}