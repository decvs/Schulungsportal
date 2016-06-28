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
            var isModelValid = ModelState.IsValid;
            if (isModelValid)
            {
                _repository.Insert(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id.HasValue)
            {
                var part = _repository.GetById(id.Value);
                return View(part);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(Participant model)
        {
            var isModelValid = ModelState.IsValid;
            if (isModelValid)
            {
                _repository.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var part = _repository.GetById(id.Value);
                return View(part);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
	}
}