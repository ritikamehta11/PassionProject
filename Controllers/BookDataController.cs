using Microsoft.Ajax.Utilities;
using PassionProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Routing;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace PassionProject.Controllers
{
    public class BookDataController : ApiController
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        /// <summary>
        /// To list all the books in the library system
        /// </summary>
        /// <returns>A list of books</returns>
        // GET : api/BookData/ListBooks ->
        // {"Title" : "Harry Potter and the Philosopher's Stone" , "Publication Year": 1997 , "Author":"J. K. Rowling" , "Genre" : "Fantasy"}
        // {"Title" : "1984" , "Publication Year": 1948 , "Author":"George Orwell" , "Genre" : "Dystopian"}
        // {"Title" : "Pride and Prejudice" , "Publication Year": 1813 , "Author":"Jane Austen" , "Genre" : "Romance"}

        [HttpGet]
        [Route("api/BookData/ListBooks")]
        public List<BookDto> ListBooks()
        {

            List<Book> booksList = db.Books.ToList();

            List<BookDto> bookdtos = new List<BookDto>();

            foreach (Book Book in booksList) {
            
                BookDto bookDto = new BookDto();
                bookDto.BookId = Book.BookId;
                bookDto.Title = Book.Title;
                bookDto.PublicationYear = Book.PublicationYear;
                bookDto.Author = Book.Author.Name;
                bookDto.Genre = Book.Genre.Name;
                bookdtos.Add(bookDto);
               
            }

            return bookdtos;
        }

        // GET :api/BookData/FindBook/1
        [HttpGet]
        [Route("api/BookData/FindBook/{id}")]
        public IHttpActionResult FindBook( int id) {
            Book book = db.Books.Find(id);
            BookDto bookdto = new BookDto();    
            if (bookdto == null)
            {
                return NotFound();
            }
            bookdto.BookId = book.BookId;   
            bookdto.Title = book.Title;
            bookdto.Author = book.Author.Name;
            bookdto.PublicationYear= book.PublicationYear;
            bookdto.Genre = book.Genre.Name;

            return Ok(bookdto);
        }

        // POST: api/BookData/AddBook
        [ResponseType(typeof(Book))]
        [HttpPost]
        //[Route("api/BookData/AddBook")]
        public IHttpActionResult AddBook(Book book) {
            if (!ModelState.IsValid) {
            return BadRequest(ModelState);
            }

            db.Books.Add(book);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = book.BookId }, book);
            //return Ok(); 
        }

        // POST : api/BookData/DeleteBook/{id}
        
        [HttpGet]
        [Route("api/BookData/DeleteBook/{id}")]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            db.Books.Remove(book);
            db.SaveChanges();
            return Ok();

        }


        //POST : api/BookData/UpdateBook
        [ResponseType(typeof(void))]
        [HttpPost]

        public IHttpActionResult UpdateBook(int id, Book book) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != book.BookId)
            {

                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }




    } 
}
