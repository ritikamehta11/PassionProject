using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Http;


namespace PassionProject.Models
{
    public class Book
    {   // things that define the book entity
        [Key]
        public int BookId { get; set; }


        //Book details
        public string Title { get; set; }
        public int PublicationYear { get; set; }


        //FOREIGN KEYS

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        

    }


    //DTO
    public class BookDto
    {

        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }

        public AuthorDto Author { get; set; } 
        public GenreDto Genre { get; set; }




    }
}