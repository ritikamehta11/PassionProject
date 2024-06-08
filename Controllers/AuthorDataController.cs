using PassionProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PassionProject.Controllers
{
    public class AuthorDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        [Route("api/AuthorData/ListAuthors")]
        public List<AuthorDto> ListAuthors()
        {

            List<Author> AuthorsList = db.Authors.ToList();

            List<AuthorDto> authordtos = new List<AuthorDto>();

            foreach (Author author in AuthorsList)
            {

                AuthorDto authorDto = new AuthorDto();
                authorDto.AuthorId = author.AuthorId;
                authorDto.Name = author.Name;
                authorDto.Bio = author.Bio;
                authordtos.Add(authorDto);

            }

            return authordtos;
        }


        // GET :api/AuthorData/FindAuthor/1
        [HttpGet]
        [Route("api/AuthorData/FindAuthor/{id}")]
        public IHttpActionResult FindAuthor(int id)
        {
            Author author = db.Authors.Find(id);
            AuthorDto authordto = new AuthorDto();
            if (authordto == null)
            {
                return NotFound();
            }
            author.AuthorId = authordto.AuthorId;
            authordto.Name = author.Name;
            authordto.Bio = author.Bio;
      

            return Ok(authordto);
        }

        [HttpGet]
        [Route("api/AuthorData/DeleteAuthor/{id}")]
        public IHttpActionResult DeleteAuthor(int id)
        {
           Author author = db.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            db.Authors.Remove(author);
            db.SaveChanges();
            return Ok();

        }

    }
}
