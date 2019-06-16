using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IGetRoleCommand _getRoleCommand;
        private readonly IGetRolesCommand _getRolesCommand;
        private readonly IAddRoleCommand _addRoleCommand;
        private readonly IEditRoleCommand _editRoleCommand;
        private readonly IDeleteRoleCommand _deleteRoleCommand;

        public RoleController(IGetRoleCommand getRoleCommand, IGetRolesCommand getRolesCommand, IAddRoleCommand addRoleCommand, IEditRoleCommand editRoleCommand, IDeleteRoleCommand deleteRoleCommand)
        {
            _getRoleCommand = getRoleCommand;
            _getRolesCommand = getRolesCommand;
            _addRoleCommand = addRoleCommand;
            _editRoleCommand = editRoleCommand;
            _deleteRoleCommand = deleteRoleCommand;
        }

        // GET: api/Roles
        [HttpGet]
        public IActionResult Get([FromQuery]RoleSearch query)
        {
            try
            {
                return Ok(_getRolesCommand.Execute(query)); //200
            }
            catch (EntityNotFoundException)
            {
                return NotFound();//404
            }
        }
        // GET: api/Roles/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_getRoleCommand.Execute(id));//200
            }
            catch (EntityNotFoundException)
            {
                return NotFound();//404
            }
        }
        // POST: api/Roles
        [HttpPost]
        public IActionResult Post([FromBody] AddRoleDto dto)
        {
            try
            {
                _addRoleCommand.Execute(dto);
                return StatusCode(201, "Successfully added a new role."); //201
            }
            catch
            {
                return StatusCode(422, "Error while trying to add a new role."); //422
            }
        }
        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AddRoleDto dto)
        {
            try
            {
                dto.Id = id;
                _editRoleCommand.Execute(dto);
                return StatusCode(204, "Successfully updated user.");
            }
            catch
            {
                return StatusCode(422, "Error while trying to update user.");
            }
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteRoleCommand.Execute(id);
                return StatusCode(204, "Deleted!");
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
