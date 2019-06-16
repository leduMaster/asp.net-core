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
    public class TagController : ControllerBase
    {
        private IGetTagCommand _getOneCommand;
        private IGetTagsCommand _getTagCommand;
        private IAddTagCommand _addTagCommand;
        private IEditTagCommand _editTagCommand;
        private IDeleteTagCommand _deleteTagCommand;

        public TagController(IGetTagCommand getOneCommand, IGetTagsCommand getTagCommand, IAddTagCommand addTagCommand, IEditTagCommand editTagCommand, IDeleteTagCommand deleteTagCommand)
        {
            _getOneCommand = getOneCommand;
            _getTagCommand = getTagCommand;
            _addTagCommand = addTagCommand;
            _editTagCommand = editTagCommand;
            _deleteTagCommand = deleteTagCommand;
        }

        // GET: api/Tag
        [HttpGet]
        public IActionResult Get([FromQuery]TagSearch query) =>
            Ok(_getTagCommand.Execute(query));

        // GET: api/Tag/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var tagDto = _getOneCommand.Execute(id);
                return Ok(tagDto);
            }
            catch (EntityNotFoundException)
            {

                return NotFound();
            }
        }

        // POST: api/Tag
        [HttpPost]
        public IActionResult Post([FromBody] AddTagDto dto)
        {
            try
            {
                _addTagCommand.Execute(dto);
                return StatusCode(202, "Sucessfully added new tag.");
            }
            catch 
            {

                return StatusCode(422, "Error has been acured!");
            }
        }

        // PUT: api/Tag/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TagDto dto)
        {
            try
            {
                dto.id = id;
                _editTagCommand.Execute(dto);
                return StatusCode(204, "Sucess in editing!");

            }
            catch 
            {
                return StatusCode(422, "Fail!");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteTagCommand.Execute(id);
                return StatusCode(204, "uspeh");
            }
            catch
            {
                return StatusCode(422, "Fail!");
            }
        }
    }
}
