using System;
using System.Collections.Generic;
using System.Text;
using Application.Command;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands
{
    public class EfGetUserCommand : EfBaseCommand, IGetUserCommand
    {
        public EfGetUserCommand(BlogContext context) : base(context)
        {
        }

        public UserDTO Execute(int request)
        {
            try
            {
                var userDto = Context.Users.Find(request);
                if (userDto != null)
                    return new UserDTO {
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                         IsDeleted = userDto.IsDeleted,
                         UserName = userDto.UserName,
                         id = userDto.Id
                        };
                }
            catch (EntityNotFoundException e)
            {

                throw new EntityNotFoundException(e.Message);
            }
            throw new EntityNotFoundException("User not found");
        }
    }
}
