using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PassionProject.Controllers;
using PassionProject.Models;
using PassionProject.Models.ViewModels;
using System.Diagnostics;


namespace PassionProject.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        private JavaScriptSerializer jss = new JavaScriptSerializer();
        public ActionResult Index()
        {
            Debug.WriteLine("inside home index");

            ShowCount ViewModel = new ShowCount();
            string url = "https://localhost:44344/api/bookdata/countbooks";
            HttpResponseMessage response = client.GetAsync(url).Result;

            // Debug.WriteLine("The response code is ");
            Debug.WriteLine(response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                int numBooks = response.Content.ReadAsAsync<int>().Result;
                Debug.WriteLine($"{numBooks}");
                ViewModel.totalBooks = numBooks;
            }
            else
            {
                Debug.WriteLine("Failed to get the number of books.");
                ViewModel.totalBooks = 0;  // Default value in case of failure
            }


            url = "https://localhost:44344/api/authordata/countAuthors";
            response = client.GetAsync(url).Result;

            // Debug.WriteLine("The response code is ");
            Debug.WriteLine(response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                int numAuthors = response.Content.ReadAsAsync<int>().Result;
                Debug.WriteLine($"{numAuthors}");
                ViewModel.totalAuthors = numAuthors;
            }
            else
            {
                Debug.WriteLine("Failed to get the number of Authors.");
                ViewModel.totalAuthors = 0;  // Default value in case of failure
            }


            url = "https://localhost:44344/api/genredata/countGenres";
            response = client.GetAsync(url).Result;

            // Debug.WriteLine("The response code is ");
            Debug.WriteLine(response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                int numGenres = response.Content.ReadAsAsync<int>().Result;
                Debug.WriteLine($"{numGenres}");
                ViewModel.totalGenres = numGenres;
            }
            else
            {
                Debug.WriteLine("Failed to get the number of Genres.");
                ViewModel.totalGenres = 0;


                //return View();
            } return View(ViewModel);
        }

            public ActionResult About()
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }

            public ActionResult Contact()
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
     }
}