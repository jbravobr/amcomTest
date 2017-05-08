using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SQLiteNetExtensions.Extensions;

namespace amcom.DemoApp
{
	public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase, new()
	{
		public object _lock = new object();

		public RepositoryBase()
		{
			if (App.AppSQLiteConn == null)
				App.AppSQLiteConn = DBContext.Instance;

			CheckDatabase();
		}

		void CheckDatabase()
		{
			App.AppSQLiteConn.CreateTable<Car>(SQLite.CreateFlags.None);
			App.AppSQLiteConn.CreateTable<Geocoordinate>(SQLite.CreateFlags.None);
			App.AppSQLiteConn.CreateTable<Photo>(SQLite.CreateFlags.None);
			App.AppSQLiteConn.CreateTable<User>(SQLite.CreateFlags.None);
			App.AppSQLiteConn.CreateTable<Menu>(SQLite.CreateFlags.None);
		}

		public bool Any()
		{
			lock (_lock)
				return App.AppSQLiteConn.Table<T>().Any();
		}

		public void Delete(T TEntity)
		{
			lock (_lock)
				App.AppSQLiteConn.Delete(TEntity);
		}

		public List<T> GetAll()
		{
			lock (_lock)
				return App.AppSQLiteConn.GetAllWithChildren<T>(null, recursive: true);
		}

		public List<T> GetAllByPredicate(Expression<Func<T, bool>> predicate)
		{
			lock (_lock)
				return App.AppSQLiteConn.GetAllWithChildren(predicate, recursive: true);
		}

		public T GetById(int pkId)
		{
			lock (_lock)
				return App.AppSQLiteConn.Get<T>(pkId);
		}

		public T GetByPredicate(Expression<Func<T, bool>> predicate)
		{
			lock (_lock)
			{
				var entity = App.AppSQLiteConn.Table<T>().FirstOrDefault(predicate);
				if (entity != null)
					return App.AppSQLiteConn.GetWithChildren<T>(entity.Id, recursive: true);

				return new T();
			}
		}

		public void Insert(T TEntity)
		{
			lock (_lock)
				App.AppSQLiteConn.InsertOrReplaceWithChildren(TEntity, recursive: true);
		}

		public void Update(T TEntity)
		{
			lock (_lock)
				App.AppSQLiteConn.UpdateWithChildren(TEntity);
		}

		public int InsertAndReturnInsertedPK(T TEntity)
		{
			lock (_lock)
				return App.AppSQLiteConn.Insert(TEntity);
		}
	}
}