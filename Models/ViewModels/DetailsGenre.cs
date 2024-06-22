using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProject.Models.ViewModels
{
    public class DetailsGenre
    {



        public GenreDto SelectedGenre { get; set; }
        public IEnumerable<BookDto> BooksInGenre { get; set; }


    }
}