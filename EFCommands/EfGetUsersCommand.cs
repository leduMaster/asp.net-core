using Application.Command;
using Application.DTO;
using Application.Searches;
using EFDataAccess;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Application.Responses;
using System;

namespace EFCommands
{
    public class EfGetUsersCommand : EfBaseCommand, IGetUsersCommand
    {
        public EfGetUsersCommand(BlogContext context) : base(context)
        {
        }

        public Pagination<UserDTO> Execute(UserSearch request)
        {
            var query = Context.Users.AsQueryable();
            if (request.FirstName != null)
                query = query.Where(u => u.FirstName.ToLower().Contains(request.FirstName.ToLower()));
            if (request.LastName != null)
                query = query.Where(u => u.LastName.ToLower().Contains(request.LastName.ToLower()));
            if (request.UserName != null)
                query = query.Where(u => u.UserName.ToLower().Contains(request.UserName.ToLower()));
            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new Pagination<UserDTO>
            {
                CurrentPage = request.PageNumber,
                Pages = pagesCount,
                Total = totalCount,
                Data = query.Select(u => new UserDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserName = u.UserName,
                    id = u.Id,
                    IsDeleted = u.IsDeleted
                })
            };

        }
    }
}
