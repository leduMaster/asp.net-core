using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO;

namespace Application.Command
{
    public interface IGetUserCommand : ICommand<int, UserDTO>
    {
    }
}
