using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
   //public  record BookDtoForUpdate(int Id,string Title,decimal price)
   // {

   // }
   public record BookDtoForUpdate:BookDtoForManipulation
    {
        [Required]
        public int Id { get; init; }
    }
   
}


// Data Transfer Objects record type
// readonly olmalıdır
// immutable olmalıdır 
// Linq
// rference Type
// Ctror tanımı yapıalbilir

// 