using Entities.DataTransferObjects;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
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
        public async Task<IActionResult> GetAllBooksAsync([FromQuery]BookParameters bookParameters)
        {
            var pagedResult = await _manager.BookService
                .GetAllBooksAsync(bookParameters,false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        
            return Ok(pagedResult.books);          
        }

        //GetOneBook
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBookAsync([FromRoute(Name = "id")] int id)
        {     
            var book = await _manager
                    .BookService
                    .GetOneBookByIdAsync(id, false);

            return Ok(book);
        }

        //CreateBook
      
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> AddBookAsync([FromBody] BookDtoForInsertion bookDto)
        {
            var book =await _manager.BookService.CreateBookAsync(bookDto);
            return StatusCode(201, book); // CreatedAtRoute() 
        }

        //UpdateBook
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]

        public async Task<IActionResult> UpdateBookAsync([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
        {
            await _manager.BookService.UpdateOneBookAsync(id, bookDto, false);
            return NoContent();
        }

        //DeleteBookByID
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBookAsync([FromRoute(Name = "id")] int id)
        {         
            var entity = await _manager
            .BookService
            .GetOneBookByIdAsync(id, false);

            if (entity is null)
                return NotFound();

           await _manager.BookService.DeleteOneBookAsync(id, false);

            return NoContent();           
        }

     
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateAsync([FromRoute(Name = "id")] int id, JsonPatchDocument<BookDtoForUpdate> bookPatch)
        {
            if (bookPatch is null)
                return BadRequest();//400

            var result = await _manager.BookService.GetOneBookForPatchAsync(id, false);

            bookPatch.ApplyTo(result.bookDtoForUpdate, ModelState);

            TryValidateModel(result.bookDtoForUpdate);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _manager.BookService.SaveChangesForPatch(result.bookDtoForUpdate, result.book);

            return NoContent();//204

        }

    }
}
