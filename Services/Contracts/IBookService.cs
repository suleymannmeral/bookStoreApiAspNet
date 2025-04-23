using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAllBooks(bool trackChanges);
        BookDto GetOneBookById(int id, bool trackChanges);
        void UpdateOneBook(int id, BookDtoForUpdate bookDto,bool trackChanges);  
        void DeleteOneBook(int id,bool trackChanges);
        BookDto CreateBook(BookDtoForInsertion book);

        (BookDtoForUpdate bookDtoForUpdate, Book book) GetOneBookForPatch(int id, bool trachChanges);

        void SaveChangesForPatch(BookDtoForUpdate bookDtoForUpdate, Book book);


    }
}
