using Application.Commands;
using Application.DTO;
using Application.Searches;
using Application.Responses;
using EFCommands;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetRolesCommand : EfBaseCommand, IGetRolesCommand
    {
        public EfGetRolesCommand(BlogContext context) : base(context)
        {
        }

        public Pagination<RoleDto> Execute(RoleSearch request)
        {
            var query = Context.Roles.AsQueryable();

            if (request.Name != null)
                query = query.Where(r => r.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new Pagination<RoleDto>
            {
                CurrentPage = request.PageNumber,
                Pages = pagesCount,
                Total = totalCount,
                Data = query.Select(r => new RoleDto
                {
                    Name = r.Name
                })
            };
        }

        
    }
}
