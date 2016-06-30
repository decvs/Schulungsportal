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
    [Authorize]
    public class LinkController : Controller
    {

        private readonly Repository<Post> _repository;

        public LinkController()
        {
            _repository = new Repository<Post>();
        }
        //
        // GET: /Link/
        public ActionResult Index(int page = 1)
        {
            var pageSize = 10;
            var viewModel = new LinkViewModel
            {
                Posts = _repository.Query.OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
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


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Post model)
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
        public ActionResult Update(Post model)
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