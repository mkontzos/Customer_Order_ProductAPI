namespace Generics.HelperClasses;
public interface IObjectMapperBase<TEntityDto, TEntity>
   where TEntity : class, new()
   where TEntityDto : class, new()
{
   Task<TEntity> MapEntities(TEntityDto entityDto);
}
