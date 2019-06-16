using Application.Command;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EFCommands;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfAddRoleCommand : EfBaseCommand, IAddRoleCommand
    {
        public EfAddRoleCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(AddRoleDto request)
        {
            if (Context.Roles.Any(r => r.Name == request.Name))
                throw new EntityAllreadyExits("Vec postoji, begaj");

            Context.Roles.Add(new Role
            {
                Name = request.Name
            });

            Context.SaveChanges();
        }
    }
}
