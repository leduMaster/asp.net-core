using Application.Command;
using Application.DTO;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Searches;
using System.Linq;
using Application.Responses;
using Microsoft.EntityFrameworkCore;

namespace EFCommands
{
    public class EfGetPostsCommand : EfBaseCommand, IGetPostsCommand
    {
        public EfGetPostsCommand(BlogContext context) : base(context) {  }

        public Pagination<PostDto> Execute(PostSearch request)
        {
            var query = Context.Posts.AsQueryable();

            if (request.Keyword != null) 
            {
                query = query.Where(p => p.Name
                .ToLower()
                .Contains(request.Keyword.ToLower()));
            }

            if (request.IsDeleted.HasValue)
            {
                query = query.Where(p => p.IsDeleted != request.IsDeleted);
            }

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new Pagination<PostDto>
            {
                CurrentPage = request.PageNumber,
                Pages = pagesCount,
                Total = totalCount,
                Data = query.Include(p=> p.PostTags)
                .ThenInclude(pt => pt.Tag)
                .Select(p => new PostDto
                {
                    id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    TagsName = p.PostTags.Select(pt=> pt.Tag.Content)
                })
            };
        }

       
    }
}
