using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace amcom.DemoApp
{
	public class ApplicationService<T> : IApplicationService<T> where T : EntityBase
	{
		readonly IRepositoryBase<T> _repository;

		public ApplicationService(IRepositoryBase<T> repository)
		{
			_repository = repository;
		}

		public async Task<bool> Any()
		{
			return await Task.FromResult(_repository.Any());
		}

		public async Task Delete(T TEntity)
		{
			await Task.Run(() => _repository.Delete(TEntity));
		}

		public async Task<List<T>> GetAll()
		{
			return await Task.FromResult(_repository.GetAll());
		}

		public async Task<List<T>> GetAllByPredicate(Expression<Func<T, bool>> predicate)
		{
			return await Task.FromResult(_repository.GetAllByPredicate(predicate));
		}

		public async Task<T> GetById(int pkId)
		{
			return await Task.FromResult(_repository.GetById(pkId));
		}

		public async Task<T> GetByPredicate(Expression<Func<T, bool>> predicate)
		{
			return await Task.FromResult(_repository.GetByPredicate(predicate));
		}

		public async Task Insert(T TEntity)
		{
			await Task.Run(() => _repository.Insert(TEntity));
		}

		public async Task<int> InsertAndReturnInsertedPK(T TEntity)
		{
			return await Task.Run(() => _repository.InsertAndReturnInsertedPK(TEntity));
		}

		public async Task Update(T TEntity)
		{
			await Task.Run(() => _repository.Update(TEntity));
		}
	}
}