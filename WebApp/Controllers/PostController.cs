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
    public class PostController : Controller
    {

        private readonly IGetPostsCommand _getPosts;
        private readonly IGetPostCommand _getPost;
        private readonly IAddPostCommand _addPost;
        private readonly IEditPostCommand _editPost;
        private readonly IDeletePostCommand _deletePost;

        public PostController(IGetPostsCommand getPosts, IGetPostCommand getPost, IAddPostCommand addPost, IEditPostCommand editPost, IDeletePostCommand deletePost)
        {
            _getPosts = getPosts;
            _getPost = getPost;
            _addPost = addPost;
            _editPost = editPost;
            _deletePost = deletePost;
        }

        // GET: Post
        public ActionResult Index(PostSearch query)
        {
            return View(_getPosts.Execute(query)) ;
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View(_getPost.Execute(id));
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddPostDto dto)
        {
            try
            {
                // TODO: Add insert logic here
                _addPost.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_getPost.Execute(id));
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                // TODO: Add update logic here
                _editPost.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException e)
            {
                return View(TempData["error"] = e.Message);
            }
            catch (Exception e)
            {
                return View(TempData["error"] = e.Message);
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View(_getPost.Execute(id));
        }

        // POST: Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _deletePost.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}