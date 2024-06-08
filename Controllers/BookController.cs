using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PassionProject.Models;
//using PassionProject.Models.ViewModels;

namespace PassionProject.Controllers
{
    public class BookController : Controller
    {


        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static BookController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44344/api/");
        }

        // GET: Book/List
        public ActionResult List()
        {
            //objective: communicate with our Book data api to retrieve a list of books
            //curl https://localhost:44344/api/bookdata/listbooks


            string url = "bookdata/listbooks";
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine("The response code is ");
            //Debug.WriteLine(response.StatusCode);

            IEnumerable<BookDto> books = response.Content.ReadAsAsync<IEnumerable<BookDto>>().Result;
            
            return View(books);
        }

        public ActionResult Show(int id) {
            string url = "https://localhost:44344/api/bookdata/findbook/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            BookDto book = response.Content.ReadAsAsync<BookDto>().Result;
            return View(book);  


        }

        public ActionResult Create(Book book) {
            Debug.WriteLine("the json payload is :");
            //Debug.WriteLine(animal.AnimalName);
            //objective: add a new animal into our system using the API
            //curl -H "Content-Type:application/json" -d @animal.json https://localhost:44324/api/animaldata/addanimal 
            string url = "bookdata/addbook";


            string jsonpayload = jss.Serialize(book);
            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult New() { 
        return View();
        }
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

    }
}