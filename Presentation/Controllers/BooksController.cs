using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        //GetAllBooks
        [HttpGet]
        public IActionResult GetAllBooks()
        {
                var books = _manager.BookService.GetAllBooks(false);  // değişiklikleri izlemezsek ef core da artıs meydana gelir
                return Ok(books);          


        }

        //GetOneBook
        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {     
                var book = _manager
                    .BookService
                    .GetOneBookById(id, false);
            return Ok(book);
        }

        //CreateBook
        [HttpPost]
        public IActionResult AddBook([FromBody] BookDtoForInsertion bookDto)
        {
            if (bookDto is null)
                return BadRequest("Kitap bilgileri eksik!");


            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var book =_manager.BookService.CreateBook(bookDto);

                return StatusCode(201, book); // CreatedAtRoute() 
  
        }

        //UpdateBook
        [HttpPut("{id:int}")]

        public IActionResult UpdateBook([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
        {

            if (bookDto is null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

                _manager.BookService.UpdateOneBook(id, bookDto, false);
                return NoContent();
        }

        //DeleteBookByID
        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook([FromRoute(Name = "id")] int id)
        {         
                var entity = _manager
              .BookService
              .GetOneBookById(id, false);

                if (entity is null)
                    return NotFound();

                _manager.BookService.DeleteOneBook(id, false);

                return NoContent();           
        }

        //PatchBook
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdate([FromRoute(Name = "id")] int id, JsonPatchDocument<BookDto> bookPatch)
        {
            
                var bookDto = _manager
                    .BookService
                    .GetOneBookById(id, true);

                bookPatch.ApplyTo(bookDto,ModelState);
            _manager.BookService.UpdateOneBook(id,
                new BookDtoForUpdate()
                {
                    Id = bookDto.Id,
                    Title = bookDto.Title,
                    Price = bookDto.Price
                },
                true);
                return NoContent();

        }

    }
}
