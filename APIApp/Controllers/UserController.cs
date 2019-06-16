using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Command;
using Application.Searches;
using Application.DTO;
using Application.Exceptions;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IGetUserCommand _getOneUserCommand;
        private IGetUsersCommand _getUsersCommand;
        private IEditUserCommand _editUserCommand;
        private IAddUserCommand _addUserCommand;
        private IDeleteUserCommand _deleteUserCommand;

        public UserController(IGetUserCommand getOneUserCommand, IGetUsersCommand getUsersCommand, IEditUserCommand editUserCommand, IAddUserCommand addUserCommand, IDeleteUserCommand deleteUserCommand)
        {
            _getOneUserCommand = getOneUserCommand;
            _getUsersCommand = getUsersCommand;
            _editUserCommand = editUserCommand;
            _addUserCommand = addUserCommand;
            _deleteUserCommand = deleteUserCommand;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult Get([FromQuery]UserSearch query) => Ok(_getUsersCommand.Execute(query));
        

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var userDto = _getOneUserCommand.Execute(id);
                return Ok(userDto);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] AddUserDto dto)
        {
            try
            {
                _addUserCommand.Execute(dto);
                return StatusCode(202, "User added");
            }
            catch (EntityAllreadyExits)
            {

                return StatusCode(422, "Fail");
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDTO dto)
        {
            try
            {
                dto.id = id;
                _editUserCommand.Execute(dto);
                return StatusCode(201, "User edited");

            }
            catch 
            {
                return StatusCode(422, "Fail");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteUserCommand.Execute(id);
                return StatusCode(204, "User deleted");
            }
            catch 
            {
                
                return StatusCode(422, "Fail");
            }
        }
    }
}
