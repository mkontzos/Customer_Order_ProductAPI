using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using CustomerOrderProduct.Models;
using Generics.HelperClasses;
using Generics.Messages;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderProduct.Services
{
	public class TestInheritanceService : ITestInheritanceService<TestInheritance>
	{
		public Task<GenericResponse<TestInheritance>> Create(TestInheritance entity)
		{
			throw new NotImplementedException();
		}

		public Task<GenericResponse<TestInheritance>> Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<GenericResponse<ICollection<TestInheritance>>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<GenericResponse<TestInheritance>> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<GenericResponse<TestInheritance>> GetById2(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<GenericResponse<TestInheritance>> Update(TestInheritance entity)
		{
			throw new NotImplementedException();
		}
	}
}
