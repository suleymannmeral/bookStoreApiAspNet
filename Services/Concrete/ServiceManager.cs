﻿using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concrete;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IBookService> _bookService;
    private readonly Lazy<IAuthenticationService> _authenticationService;
    public ServiceManager(IRepositoryManager repositoryManager,ILoggerService logger,IMapper mapper,IBookLinks bookLinks,UserManager<User> userManager,IConfiguration configuration)
    {
        _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager, logger, mapper,bookLinks));
        _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationManager(logger, mapper, userManager,configuration));
    }

    public IBookService BookService => _bookService.Value;

    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}
