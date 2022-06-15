using System;
namespace DAL.IRepositories
{
	public interface IRepositoryBase<T>
	{
		public  Task<List<T>>  GetList(int skip, int take);
		public Task<T> GetById(int id);
		public Task Save(T entity);
		public Task Update(int id, T entity);
		public Task  Delete(int id);
	}
}

