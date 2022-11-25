using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Models;
using Generics.Messages;

namespace CustomerOrderProduct.Interfaces
{
	public interface ITestInheritanceService<TEntity> : IBaseService<TEntity>
	{
		Task<GenericResponse<TEntity>> GetById2(Guid id);
	}
}
