using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProject.Models.ViewModels
{
    public class UpdateBook
    {

          //This viewmodel is a class which stores information that we need to present to /Animal/Update/{}

            //the existing animal information

            public BookDto SelectedBook { get; set; }
      

            // all species to choose from when updating this animal

            public IEnumerable<AuthorDto> AuthorOptions { get; set; }
            public IEnumerable<GenreDto> GenreOptions { get; set; }
        
    }
}