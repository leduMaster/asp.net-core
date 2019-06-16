using System;
using System.Collections.Generic;
using System.Text;
using Application.Command;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands
{
    public class EfEditTagCommand : EfBaseCommand, IEditTagCommand
    {
        public EfEditTagCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(TagDto request)
        {
            var tagDto = Context.Tag.Find(request);
            if (tagDto != null)
            {
                try
                {
                    tagDto.Content = request.Content;
                    tagDto.IsDeleted = request.IsDeleted;
                    tagDto.PostTags = request.PostTags;
                    Context.SaveChanges();
                }
                catch (Exception)
                {

                    throw new Exception();
                }
            }
            else { 
            throw new EntityNotFoundException("Tag not found");
            }
        }
    }
}
