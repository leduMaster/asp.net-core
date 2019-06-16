using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO;
using Application.Interfaces;
using Application.Responses;
using Application.Searches;

namespace Application.Command
{
    public interface IGetPostsCommand : ICommand<PostSearch, Pagination<PostDto>>
    {
    }
}
