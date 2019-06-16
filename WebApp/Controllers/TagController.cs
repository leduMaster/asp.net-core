using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Command;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class TagController : Controller
    {

        private readonly IGetTagsCommand _getTags;
        private readonly IGetTagCommand _getTag;
        private readonly IAddTagCommand _addTag;
        private readonly IEditTagCommand _editTag;
        private readonly IDeleteTagCommand _deleteTag;

        public TagController(IGetTagsCommand getTags, IGetTagCommand getTag, IAddTagCommand addTag, IEditTagCommand editTag, IDeleteTagCommand deleteTag)
        {
            _getTags = getTags;
            _getTag = getTag;
            _addTag = addTag;
            _editTag = editTag;
            _deleteTag = deleteTag;
        }

        // GET: Tag
        public ActionResult Index(TagSearch query)
        {
            return View(_getTags.Execute(query));
        }

        // GET: Tag/Details/5
        public ActionResult Details(int id)
        {
            return View(_getTag.Execute(id));
        }

        // GET: Tag/Create
        public ActionResult Create()
        {
            return View();
            //treba da vrati view sa formom za unos
        }

        // POST: Tag/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddTagDto dto)
        {
            try
            {
                // TODO: Add insert logic here
                _addTag.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return View(TempData["Error"]="500");
        } 
        
        // GET: Tag/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_getTag.Execute(id));
        }

        // POST: Tag/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TagDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                // TODO: Add update logic here
                _editTag.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException e)
            {
                return View(TempData["error"]=e.Message);
            }
            catch (Exception e)
            {
                return View(TempData["error"] = e.Message);
            }
        }

        // GET: Tag/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_getTag.Execute(id));
            //ne koristi se u ovom slucaju
        }

        // POST: Tag/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _deleteTag.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}