/*
 * This is for Webdsite
 * Anyone can see website
*/

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NagarHawlaGovtPrimarySchool.Models;

namespace NagarHawlaGovtPrimarySchool.Controllers
{
    public class HomeController : Controller
    {
        // Prodhan Pata
        public IActionResult Index()
        {
            return View();
        }

        // Amader Somporke
        public IActionResult About()
        {           
            return View();
        }

        // Vorti Pata
        public IActionResult Admission()
        {
            return View();
        }

        // Jogajog Pata
        public IActionResult Contact()
        {
            return View();
        }

        // Folafol Pata
        public IActionResult Result()
        {
            return View();
        }

        // Vorti Pata -> Vorti Form
        public IActionResult AdmissionForm()
        {
            return View();
        }

        // Vorti Pata -> Vorti Prokriya
        public IActionResult AdmissionProcess()
        {
            return View();
        }

        // Amader Somporke -> Photo Gallery
        public IActionResult Gallery()
        {
             return View();
        }

        // Error / Invalid Search
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
