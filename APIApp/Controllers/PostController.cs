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

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private IGetPostsCommand _getCommand;
        private IEditPostCommand _editCommand;
        private IDeletePostCommand _deleteCommand;
        private IAddPostCommand _addCommand;
        private IGetPostCommand _getOneCommand;

        public PostController(IGetPostsCommand getCommand, IEditPostCommand editCommand, IDeletePostCommand deleteCommand, IAddPostCommand addCommand, IGetPostCommand getOneCommand)
        {
            _getCommand = getCommand;
            _editCommand = editCommand;
            _deleteCommand = deleteCommand;
            _addCommand = addCommand;
            _getOneCommand = getOneCommand;
        }



        // GET: api/Post
        [HttpGet]
        public IActionResult Get([FromQuery]PostSearch query) => Ok(_getCommand.Execute(query));

        // GET: api/Post/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var postdto = _getOneCommand.Execute(id);
                return Ok(postdto);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/Post
        [HttpPost]
        
            public IActionResult Post([FromBody] AddPostDto dto)
            {

            try
            {
                 _addCommand.Execute(dto);
                return StatusCode(201, "Succesfully added a new post.");

            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Product not found.")
                    return NotFound(e.Message);
                return UnprocessableEntity(e.Message);

            }
            }
        

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PostDto dto)
        {
            try
            {
                dto.id = id;
                _editCommand.Execute(dto);
                return StatusCode(204, "Succesfully edited a post");
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Product not found.")
                    return NotFound(e.Message);

            return UnprocessableEntity(e.Message);
            }
            }
        

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteCommand.Execute(id);
                return StatusCode(200, "Sucessfully deleted!");
            }
            catch 
            {
                return StatusCode(422, "Deletion of post not sucesseded!");
            }
        }
    }
}
