using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Messages
{
	public class GenericResponse<T>
	{
		public T? Data { get; set; }
		public bool Success { get; set; }
		public string? Message { get; set; }
		public string? ErrorCode { get; set; }
	}
}
