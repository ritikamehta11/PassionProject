using PassionProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PassionProject.Controllers
{
    public class GenreDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        [Route("api/GenreData/ListGenres")]
        public List<GenreDto> Listgenres()
        {

            List<Genre> genresList = db.Genres.ToList();

            List<GenreDto> genredtos = new List<GenreDto>();

            foreach (Genre genre in genresList)
            {

                GenreDto genredto = new GenreDto();
                genredto.GenreId = genre.GenreId;   
                genredto.Description = genre.Description;
                genredto.Name = genre.Name;
                
              
                genredtos.Add(genredto);

            }

            return genredtos;
        }


        // GET :api/GenreData/FindGenre/1
        [HttpGet]
        [Route("api/GenreData/FindGenre/{id}")]
        public IHttpActionResult FindGenre(int id)
        {
            Genre genre = db.Genres.Find(id);
            GenreDto genredto = new GenreDto();
            if (genredto == null)
            {
                return NotFound();
            }
            genre.GenreId = genredto.GenreId;
            genredto.Name = genre.Name;
            genredto.Description = genre.Description;


            return Ok(genredto);
        }

        [HttpGet]
        [Route("api/GenreData/DeleteGenre/{id}")]
        public IHttpActionResult DeleteGenre(int id)
        {
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return NotFound();
            }
            db.Genres.Remove(genre);
            db.SaveChanges();
            return Ok();

        }

    }
}
