using Application.DTO;
using Application.Interfaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Responses;

namespace Application.Command
{
    public interface IGetTagsCommand : ICommand<TagSearch, Pagination<TagDto>>
    {
    }
}
