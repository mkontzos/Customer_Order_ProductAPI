using Generics.Messages;

namespace CustomerOrderProduct.Interfaces
{
   public interface IBaseRepository<TEntityDto, TEntity>
      where TEntityDto : class
      where TEntity : class
   {
      Task<GenericResponse<ICollection<TEntity>>> GetAll();
      Task<GenericResponse<TEntity>> GetById(Guid id);
      Task<GenericResponse<TEntity>> Create(TEntityDto entity);
      Task<GenericResponse<TEntity>> Update(TEntityDto entity);
      Task<GenericResponse<TEntity>> Delete(Guid id);
   }
}
