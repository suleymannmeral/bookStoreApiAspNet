using Entities.DataTransferObjects;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

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

     
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdate([FromRoute(Name = "id")] int id, JsonPatchDocument<BookDtoForUpdate> bookPatch)
        {
            if (bookPatch is null)
                return BadRequest();//400

            var result = _manager.BookService.GetOneBookForPatch(id, false);

            bookPatch.ApplyTo(result.bookDtoForUpdate, ModelState);

            TryValidateModel(result.bookDtoForUpdate);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _manager.BookService.SaveChangesForPatch(result.bookDtoForUpdate, result.book);

            return NoContent();//204

        }

    }
}
