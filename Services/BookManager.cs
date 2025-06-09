using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Entities.Exceptions.BadRequestException;

namespace Services
{
    public class BookManager : IBookService
    {
        //Dependency Injection
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper; 
        private readonly IDataShaper<BookDto> _dataShaper;

        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, IDataShaper<BookDto> dataShaper)
        {

            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<BookDto> CreateBookAsync(BookDtoForInsertion bookDto)
        {
            var entity = _mapper.Map<Book>(bookDto); // 1. DTO → Entity çevirimi

            _manager.BookRepository.Create(entity);   // 2. Entity veritabanına ekleniyor

            await _manager.SaveAsync();                          // 3. Değişiklikler kaydediliyor

            return _mapper.Map<BookDto>(entity);      // 4. Entity → DTO çevirimi (dönüş)
        }

        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            var entity = await GetOneBookByIdAndCheckExist(id,trackChanges);
            _manager.BookRepository.Delete(entity);
            await _manager.SaveAsync();

        }

        public async Task<(IEnumerable<ExpandoObject> books, MetaData metaData)> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges)
        {
            if (!bookParameters.ValidPriceRange)
                throw new PriceOutOfRangeBadException();

            var booksWithMetaData = await _manager.BookRepository.GetAllBooksAsync(bookParameters,trackChanges);

            var booksDto=_mapper.Map<IEnumerable<BookDto>>(booksWithMetaData);

            var shapedData = _dataShaper.ShapeData(booksDto, bookParameters.Fields);
            return(books:shapedData,metaData:booksWithMetaData.MetaData);
        }

        public async  Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges)
        {
            var book = await GetOneBookByIdAndCheckExist(id, trackChanges); 

            return _mapper.Map<BookDto>(book);
        }

        public async Task<(BookDtoForUpdate bookDtoForUpdate, Book book)> GetOneBookForPatchAsync(int id, bool trachChanges)
        {
            var book = await GetOneBookByIdAndCheckExist(id, trachChanges);
            var bookDtoForUpdate = _mapper.Map<BookDtoForUpdate>(book);
            return (bookDtoForUpdate, book);

        }

        public async Task SaveChangesForPatch(BookDtoForUpdate bookDtoForUpdate, Book book)
        {
            _mapper.Map(bookDtoForUpdate, book);
            await _manager.SaveAsync();
        }

        public async Task UpdateOneBookAsync(int id, BookDtoForUpdate bookDto, bool trackChanges)
        {
            var entity = await GetOneBookByIdAndCheckExist(id, trackChanges);
            entity = _mapper.Map<Book>(bookDto);
            _manager.BookRepository.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<Book> GetOneBookByIdAndCheckExist(int id, bool trackChanges)
        {

            var entity = await _manager.BookRepository.GetOneBookByIdAsync(id, trackChanges);

            if (entity is null)
                throw new BookNotFoundException(id);

            return entity;
        }

       
    }
}

//Mapping Requestten gelen body ile eşleşme yapıyoruz. Onlarca propumuz olabilir o yüzden manuel oalrak eşlemek yerine
// Otomatik gerçekleştireceğiz
//entity.Title = book.Title;
//entity.Price = book.Price;

// Mapping otomatik oalrak gerçekelşyior