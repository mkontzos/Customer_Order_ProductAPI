namespace Generics.Messages
{
   public class GenericResponse<TEntity>
   {
      public TEntity? Data { get; set; }
      public bool Success { get; set; }
      public string? Message { get; set; }
      public int? ErrorCode { get; set; }
   }
}
