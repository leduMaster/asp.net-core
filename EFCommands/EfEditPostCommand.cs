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
    public class EfEditPostCommand : EfBaseCommand, IEditPostCommand
    {
        public EfEditPostCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(PostDto request)
        {
            var postDto = Context.Posts.Find(request);
            if(postDto != null)
                { 
            postDto.IsDeleted = request.IsDeleted;
            postDto.Name = request.Name;
            postDto.ModifidedAt = DateTime.Now;
                var tag = Context.Tag.Find(request.TagsName);
                if (tag == null)
                {
                    throw new EntityNotFoundException("Tag");
                }

                try
                {
                    Context.SaveChanges();
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            throw new EntityNotFoundException();
        }
    }
}
