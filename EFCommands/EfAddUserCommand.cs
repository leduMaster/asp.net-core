using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Application.Command;
using Application.DTO;
using EFDataAccess;
using Application.Exceptions;

namespace EFCommands
{
    public class EfAddUserCommand : EfBaseCommand, IAddUserCommand
    {
        public EfAddUserCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(AddUserDto request)
        {
            var userDto = new Domain.User {
                IsDeleted = false,
                FirstName = request.FirstName,
                LastName = request.LastName,
                CreatedAt = DateTime.Now,
                ModifidedAt = null,
                UserName = request.UserName
            };
            if(Context.Users.Any(u => u.UserName == userDto.UserName))
                throw new EntityAllreadyExits("User");

            try
            {
                Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
