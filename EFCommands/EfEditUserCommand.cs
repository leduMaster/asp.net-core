using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Application.Command;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands
{
    public class EfEditUserCommand : EfBaseCommand, IEditUserCommand
    {
        public EfEditUserCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(UserDTO request)
        {
            var userDto = Context.Users.Find(request);
            if (userDto != null)
            {
                try
                {
                    userDto.FirstName = request.FirstName;
                    userDto.LastName = request.LastName;
                    userDto.ModifidedAt = DateTime.Now;
                    userDto.IsDeleted = request.IsDeleted;
                    userDto.UserName = request.UserName;
                    Context.SaveChanges();
                }
                catch (Exception)
                {

                    throw new Exception("Server 500 error!");
                }
            }
            throw new EntityNotFoundException("User not found!");
        }
    }
}
