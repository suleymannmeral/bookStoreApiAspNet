using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookManager : IBookService
    {
        //Dependency Injection
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;  // mapper enjekte ediliyor

        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {

            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public BookDto CreateBook(BookDtoForInsertion bookDto)
        {
            var entity = _mapper.Map<Book>(bookDto); // 1. DTO → Entity çevirimi
            _manager.BookRepository.Create(entity);   // 2. Entity veritabanına ekleniyor
            _manager.Save();                          // 3. Değişiklikler kaydediliyor
            return _mapper.Map<BookDto>(entity);      // 4. Entity → DTO çevirimi (dönüş)
        }


      
        public void DeleteOneBook(int id, bool trackChanges)
        {
            // check entity
            var entity = _manager.BookRepository.GetOneBookById(id,trackChanges);
            if (entity is null)
                throw new BookNotFoundException(id);    
            
            _manager.BookRepository.Delete(entity);
            _manager.Save();

        }

        public IEnumerable<BookDto> GetAllBooks(bool trackChanges)
        {
            var books =_manager.BookRepository.GetAllBooks(trackChanges);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public BookDto GetOneBookById(int id, bool trackChanges)
        {
            var book = _manager.BookRepository.GetOneBookById(id,trackChanges);
            if (book is null)
                throw new BookNotFoundException(id);
            return _mapper.Map<BookDto>(book);
        }

        public (BookDtoForUpdate bookDtoForUpdate, Book book) GetOneBookForPatch(int id, bool trachChanges)
        {
            var book =_manager.BookRepository.GetOneBookById(id, trachChanges);

            if (book is null)
                throw new BookNotFoundException(id);

            


        }

        public void UpdateOneBook(int id, BookDtoForUpdate bookDto, bool trackChanges)
        {
            // check entity

            var entity = _manager.BookRepository.GetOneBookById(id, trackChanges);
            if (entity is null)
                throw new BookNotFoundException(id);

            //Mapping Requestten gelen body ile eşleşme yapıyoruz. Onlarca propumuz olabilir o yüzden manuel oalrak eşlemek yerine
            // Otomatik gerçekleştireceğiz
            //entity.Title = book.Title;
            //entity.Price = book.Price;

            // Mapping otomatik oalrak gerçekelşyior
            entity = _mapper.Map<Book>(bookDto);

            _manager.BookRepository.Update(entity);
            _manager.Save();

        }

       
    }
}
