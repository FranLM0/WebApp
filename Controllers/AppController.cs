using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarniceriaWebApp.Data;
using CarniceriaWebApp.Services;
using CarniceriaWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarniceriaWebApp.Controllers
{
    public class AppController : Controller
    {

        private readonly IMailService _mailService;
        private readonly ICarniceriaRepository _repository;

        public AppController(IMailService mailService, ICarniceriaRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send the Email
                _mailService.SendMessage("shawn@wildermuth.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent...";
                ModelState.Clear();
            }

            return View();
        }


        public IActionResult About()
        {

            ViewBag.Title = "About Us";
            return View();
        }

        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();

            return View(results);
        }
    }
}
