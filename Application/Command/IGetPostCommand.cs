using Application.DTO;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Command
{
    public interface IGetPostCommand : ICommand<int, PostDto>
    {
    }
}
