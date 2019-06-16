using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EFCommands;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfGetRoleCommand : EfBaseCommand, IGetRoleCommand
    {
        public EfGetRoleCommand(BlogContext context) : base(context)
        {
        }

        public RoleDto Execute(int request)
        {
            var role = Context.Roles.Find(request);

            if (role == null)
                throw new EntityNotFoundException();

            return new RoleDto
            {
                Name = role.Name
            };
        }
    }
}
