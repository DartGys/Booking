using Booking.BLL.Interfaces;
using Booking.BLL.Models;
using Booking.WebAPI.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookModel>>> Get()
        {
            var books = await _bookService.GetAllAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookModel>> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Book id cant be empty");
            }

            var book = await _bookService.GetByIdAsync(id);

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookModel>> Create(BookModel model)
        {
            string errors = Validator.Book(model);

            if(!string.IsNullOrEmpty(errors))
            {
                return BadRequest(errors);
            }

            var book = await _bookService.AddAsync(model);

            return Ok(book);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest("Book id cant be empty");
            }

            await _bookService.DeleteAsync(id);

            return Ok();
        }

        [HttpPatch]
        public async Task<ActionResult<BookModel>> Update(BookModel model)
        {
            string errors = Validator.Book(model);

            if (!string.IsNullOrEmpty(errors))
            {
                return BadRequest(errors);
            }

            var book = await _bookService.UpdateAsync(model);

            return Ok(book);
        }
    }
}
