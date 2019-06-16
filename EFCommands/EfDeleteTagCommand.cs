using System;
using System.Collections.Generic;
using System.Text;
using Application.Command;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands
{
    public class EfDeleteTagCommand : EfBaseCommand, IDeleteTagCommand
    {
        public EfDeleteTagCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var tagDto = Context.Tag.Find(request);
            if (tagDto == null)
                throw new EntityNotFoundException("Tag not found");
            if (tagDto.IsDeleted == true)
                throw new EntityNotFoundException("Already gone bro!");
            try
            {
                tagDto.IsDeleted = true;
                Context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
