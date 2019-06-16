using Application.Commands;
using Application.Exceptions;
using EFCommands;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteRoleCommand : EfBaseCommand, IDeleteRoleCommand
    {
        public EfDeleteRoleCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var role = Context.Roles.Find(request);

            if (role == null)
                throw new EntityNotFoundException();

            Context.Roles.Remove(role);
            Context.SaveChanges();
        }
    }
}
