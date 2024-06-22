using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProject.Models.ViewModels
{
    public class DetailsAuthor
    {

            public AuthorDto SelectedAuthor { get; set; }
            public IEnumerable<BookDto> BooksWritten { get; set; }
        
    
}
}