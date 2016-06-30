using Schulungsportal.Data;
using Schulungsportal.Models;
using Schulungsportal.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schulungsportal.Controllers
{
    [Authorize]
    public class ParticipantsController : Controller
    {

        private readonly Repository<Participant> _repository;

        public ParticipantsController()
        {
            _repository = new Repository<Participant>();
        }
        //
        // GET: /Participants/
        public ActionResult Index(int page = 1)
        {
            var pageSize = 2;
            var viewModel = new ParticipantViewModel
            {
                Participants = _repository.Query.OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                Pagination = new PaginationViewModel
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalCount = _repository.Query.Count(),
                    Controller = RouteData.Values["Controller"] as string,
                    Action = RouteData.Values["Action"] as string
                }
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Participant model, HttpPostedFileBase upload)
        {
            var isModelValid = ModelState.IsValid;
            if (isModelValid)
            {
                if (upload != null && upload.ContentLength != 0)
                {
                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        model.ProfilePicture = reader.ReadBytes(upload.ContentLength);
                        model.ProfilePictureContentType = upload.ContentType;
                    }
                }
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
        public ActionResult Update(Participant model, HttpPostedFileBase upload)
        {
            var isModelValid = ModelState.IsValid;
            if (isModelValid)
            {
                if (upload != null && upload.ContentLength != 0)
                {
                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        model.ProfilePicture = reader.ReadBytes(upload.ContentLength);
                        model.ProfilePictureContentType = upload.ContentType;
                    }
                }

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

        public ActionResult Gallery(int page=1)
        {
            var pageSize = 2;
            var viewModel = new ParticipantViewModel
            {
                Participants = _repository.Query.OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                Pagination = new PaginationViewModel
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalCount = _repository.Query.Count(),
                    Controller = RouteData.Values["Controller"] as string,
                    Action = RouteData.Values["Action"] as string
                }
            };


            return View(viewModel);
        }
	}
}