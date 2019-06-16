using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EFCommands;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfEditRoleCommand : EfBaseCommand, IEditRoleCommand
    {
        public EfEditRoleCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(AddRoleDto request)
        {
            var role = Context.Roles.Find(request.Id);

            if (role == null)
                throw new EntityNotFoundException();

            if (request.Name != role.Name && Context.Roles.Any(r => r.Name == request.Name))
                throw new EntityAllreadyExits("Vec ima");

            role.Name = request.Name;
            Context.SaveChanges();
        }
    }
}
