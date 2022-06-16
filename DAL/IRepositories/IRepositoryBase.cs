using System;
namespace DAL.IRepositories
{
	public interface IRepositoryBase<T>
	{
		public  Task<List<T>>  GetList(int skip, int take);
		public Task<T> GetById(int id);
		public Task<T> Save(T entity);
		public Task<T> Update(int id, T entity);
		public Task<bool>  Delete(int id);
	}
}

