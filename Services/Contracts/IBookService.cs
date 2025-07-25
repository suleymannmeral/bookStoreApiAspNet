﻿using Entities.DataTransferObjects;
using Entities.LinkModels;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts;

public interface IBookService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetAllBooksAsync(LinkParameters linkParameters,bool trackChanges);
    Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges);
    Task UpdateOneBookAsync(int id, BookDtoForUpdate bookDto,bool trackChanges);  
    Task DeleteOneBookAsync(int id,bool trackChanges);
    Task<BookDto> CreateBookAsync(BookDtoForInsertion book);

    Task<(BookDtoForUpdate bookDtoForUpdate, Book book)> GetOneBookForPatchAsync(int id, bool trachChanges);

    Task SaveChangesForPatch(BookDtoForUpdate bookDtoForUpdate, Book book);
    Task<List<Book>> GetAllBooksAsync(bool trackChanges);
}
