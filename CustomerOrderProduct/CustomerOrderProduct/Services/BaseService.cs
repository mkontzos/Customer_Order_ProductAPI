using CustomerOrderProduct.Interfaces;
using Generics.Messages;

namespace CustomerOrderProduct.Services
{
	public class BaseService<T> : IBaseService<T>
	{
		public Task<GenericResponse<T>> Create(T entity)
		{
			throw new NotImplementedException();
		}

		public Task<GenericResponse<ICollection<T>>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<GenericResponse<T>> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<GenericResponse<T>> Update(T entity)
		{
			throw new NotImplementedException();
		}

		public Task<GenericResponse<T>> Delete(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
