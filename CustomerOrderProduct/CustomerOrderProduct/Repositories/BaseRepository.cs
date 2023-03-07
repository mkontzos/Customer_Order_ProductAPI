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

        public async Task<GenericResponse<TEntity>> Create(TEntityDto entityDto)
        {
            var response = new GenericResponse<TEntity>();

            try
            {
                var entity = _mapper.Map<TEntity>(entityDto);

                await _table.AddAsync(entity);
                await _context.SaveChangesAsync();

                var createdEntity = await _table.FindAsync(entity);

                response.Data = createdEntity;
                response.ErrorCode = ErrorCodes.Status200Ok;
                response.Message = "Successfully created record.";

                return response;
            }
            catch (Exception e)
            {
                // log ex
                response.ErrorCode = ErrorCodes.Status500InternalServerError;
                response.Message = e.Message;

                return response;
            }
        }


        public async Task<GenericResponse<TEntity>> Update(TEntityDto entityDto)
        {
            var response = new GenericResponse<TEntity>();

            try
            {
                var entity = _mapper.Map<TEntity>(entityDto);

                await _table.UpdateAsync(entity);
                await _context.SaveChangesAsync();

                response.Data = entity;
                response.ErrorCode = ErrorCodes.Status200Ok;
                response.Message = "Successfully updated record.";

                return response;
            }
            catch (Exception e)
            {
                // log ex
                response.ErrorCode = ErrorCodes.Status500InternalServerError;
                response.Message = e.Message;

                return response;
            }
        }

        public async Task<GenericResponse<TEntity>> Delete(Guid id)
        {
            var response = new GenericResponse<TEntity>();

            try
            {
                response.ErrorCode = ErrorCodes.Status500InternalServerError;
                response.Message = "Failed to delete record, not found in database.";

                var entityInDb = await _table.FindAsync(id);

                if (entityInDb != null)
                {
                    _table.Remove(entityInDb);
                    _context.SaveChanges();

                    response.Data = entityInDb;
                    response.ErrorCode = ErrorCodes.Status200Ok;
                    response.Message = "Successfully deleted record.";
                }

                return response;
            }
            catch (Exception e)
            {
                // log ex
                response.ErrorCode = ErrorCodes.Status500InternalServerError;
                response.Message = e.Message;

                return response;
            }
        }
    }
}
