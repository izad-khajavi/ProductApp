using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;
using ProductApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _BookService;

    public BooksController(IBookService BookService)
    {
        _BookService = BookService;
    }

    // GET: api/Books
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        var Books = await _BookService.GetBooksAsync();
        return Ok(Books);
    }

    // GET: api/Books/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var Book = await _BookService.GetBookByIdAsync(id);

        if (Book == null)
        {
            return NotFound();
        }

        return Ok(Book);
    }

    // POST: api/Books
    [HttpPost]
    public async Task<ActionResult<Book>> PostBook(Book Book)
    {
        var createdBook = await _BookService.CreateBookAsync(Book);
        return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
    }

    // PUT: api/Books/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBook(int id, Book Book)
    {
        var result = await _BookService.UpdateBookAsync(id, Book);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/Books/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var result = await _BookService.DeleteBookAsync(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
