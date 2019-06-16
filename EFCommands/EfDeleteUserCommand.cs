using Application.Command;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EfDeleteUserCommand : EfBaseCommand, IDeleteUserCommand
    {
        public EfDeleteUserCommand(BlogContext context) : base(context) { }

        public void Execute(int request)
        {
            var dUser = Context.Users.Find(request);
            if (dUser == null)
                throw new EntityNotFoundException("User not found!");
            if(dUser.IsDeleted == true)
                 throw new EntityNotFoundException("Already gone bro!");

            try
            {
                dUser.IsDeleted = true;
                Context.SaveChanges();
            }
            catch (NotImplementedException)
            {
                throw new NotImplementedException();
            }
            throw new NotImplementedException();
        }
    }
}
