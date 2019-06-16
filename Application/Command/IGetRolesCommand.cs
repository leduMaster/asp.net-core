using Application.DTO;
using Application.Interfaces;
using Application.Searches;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public interface IGetRolesCommand : ICommand<RoleSearch, Pagination<RoleDto>>
    {
    }
}
