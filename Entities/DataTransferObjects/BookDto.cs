namespace Entities.DataTransferObjects
{
   
    public record BookDto()
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
   
}

// Data Transfer Objects record type
// readonly olmalıdır
// immutable olmalıdır 
// Linq
// rference Type
// Ctror tanımı yapıalbilir

// 