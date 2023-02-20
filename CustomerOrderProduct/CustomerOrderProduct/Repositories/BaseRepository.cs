using AutoMapper;
using CustomerOrderProduct.Interfaces;
using CustomerOrderProduct.Models;
using Generics.HelperClasses;
using Generics.Messages;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderProduct.Services
{
   public abstract class BaseRepository<TEntityDto, TEntity>
      : IBaseRepository<TEntityDto, TEntity>
      where TEntityDto : class, new()
      where TEntity : class, new()
   {
      private CustomerOrderProductDbContext _context = null;
      private readonly IMapper _mapper;
      private DbSet<TEntity> _table = null;

      public BaseRepository(CustomerOrderProductDbContext context,
          IMapper mapper)
      {
         _context = context;
         _mapper = mapper;
         _table = _context.Set<TEntity>();
      }

      public async Task<GenericResponse<ICollection<TEntity>>> GetAll()
      {
         var response = new GenericResponse<ICollection<TEntity>>();

         response.Data = await _table.ToListAsync();

         return response;
      }

      public async Task<GenericResponse<TEntity>> GetById(Guid id)
      {
         var response = new GenericResponse<TEntity>();

         if (id == Guid.Empty)
         {
            response.ErrorCode = ErrorCodes.Status400BadRequest;
            response.Message = "Id can not be empty.";
            return response;
         }

         try
         {
            var result = await _table.FindAsync(id);

            if (result == null)
            {
               response.ErrorCode = ErrorCodes.Status404NotFound;
               response.Message = "Record not found in database.";

               return response;
            }

            response.Data = result;
            response.ErrorCode = ErrorCodes.Status200Ok;
            response.Message = "Record successfully retrieved.";

            return response;
         }
         catch (Exception e)
         {
            //log
            response.ErrorCode = ErrorCodes.Status500InternalServerError;
            response.Message = e.Message;

            return response;
         }
      }

      public Task<GenericResponse<TEntity>> Create(TEntityDto entity)
      {
         var response = new GenericResponse<TEntity>();

         //try
         //{
         //   var newEntity = new TEntity ;

         //   var product = new Product
         //   {
         //      Id = Guid.NewGuid(),
         //      Title = productDto.Title,
         //      Manufacturer = productDto.Manufacturer,
         //      ProductionDate = productDto.ProductionDate,
         //      ReturnDate = productDto.ReturnDate
         //   };

         //   _customerOrderProductDbContext.Entry(product).State = EntityState.Added;
         //   await _customerOrderProductDbContext.SaveChangesAsync();

         //   var productCreatedDto = new ProductDto
         //   {
         //      Id = product.Id
         //   };

         //   response.Success = true;
         //   response.Data = productCreatedDto;
         //   response.Message = "Successfully created record.";

         //   return response;
         //}
         //catch (Exception e)
         //{
         //   // log error
         //   response.Success = false;
         //   response.ErrorCode = ErrorCodes.Status500InternalServerError;
         //   response.Message = e.Message;

         //   return response;
         //}

         return null;
      }


      public Task<GenericResponse<TEntity>> Update(TEntityDto entity)
      {
         throw new NotImplementedException();
      }

      public Task<GenericResponse<TEntity>> Delete(Guid id)
      {
         throw new NotImplementedException();
      }
   }
}
