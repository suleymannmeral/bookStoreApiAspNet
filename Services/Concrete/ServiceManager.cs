﻿using AutoMapper;
using Entities.DataTransferObjects;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        public ServiceManager(IRepositoryManager repositoryManager,ILoggerService logger,IMapper mapper,IDataShaper<BookDto> shaper )
        {
            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager,logger,mapper,shaper));
        }

        public IBookService BookService => _bookService.Value;
    }
}
