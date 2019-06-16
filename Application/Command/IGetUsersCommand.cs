using System;
using System.Collections.Generic;
using System.Text;
using Application.Searches;
using Application.DTO;
using Application.Interfaces;
using Application.Responses;

namespace Application.Command
{
    public interface IGetUsersCommand : ICommand<UserSearch, Pagination<UserDTO>>
    {
    }
}
