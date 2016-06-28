using Schulungsportal.Data;
using Schulungsportal.Models;
using Schulungsportal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schulungsportal.Controllers
{
    public class ParticipantsController : Controller
    {

        private readonly ParticipantRepository _repository;

        public ParticipantsController()
        {
            _repository = new ParticipantRepository();
        }
        //
        // GET: /Participants/
        public ActionResult Index()
        {
            var viewmodel = new ParticipantViewModel
            {
                Participants = _repository.Query.ToList()
            };
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Participant model)
        {
            _repository.Insert(model);
            return RedirectToAction("Index");
        }
	}
}