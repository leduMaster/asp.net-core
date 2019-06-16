using System;
using System.Collections.Generic;
using System.Text;
using Application.Command;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands
{
    public class EfDeletePostCommand : EfBaseCommand, IDeletePostCommand
    {
        public EfDeletePostCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var postDto = Context.Posts.Find(request);
            
            if (postDto != null)
            {
                try
                {
                    postDto.IsDeleted = true;
                    Context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
           else throw new EntityNotFoundException(); 
        }
    }
}
