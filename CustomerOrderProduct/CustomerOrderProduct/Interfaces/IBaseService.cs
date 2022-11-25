using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Models;
using Generics.Messages;

namespace CustomerOrderProduct.Interfaces
{
	public interface IBaseService<TEntity>
	{
		Task<GenericResponse<TEntity>> GetById(Guid id);
		Task<GenericResponse<ICollection<TEntity>>> GetAll();
		Task<GenericResponse<TEntity>> Create(TEntity entity);
		Task<GenericResponse<TEntity>> Update(TEntity entity);
		Task<GenericResponse<TEntity>> Delete(Guid id);
	}
}
