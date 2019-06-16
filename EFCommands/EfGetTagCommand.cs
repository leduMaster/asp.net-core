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
    public class EfGetTagCommand : EfBaseCommand, IGetTagCommand
    {
        public EfGetTagCommand(BlogContext context) : base(context)
        {
        }

        public TagDto Execute(int request)
        {
            var tagDto = Context.Tag.Find(request);
            if (tagDto != null)
            { 
                try
            {
               
                    return new TagDto
                    {
                        Content = tagDto.Content,
                        id = tagDto.Id,
                        IsDeleted = tagDto.IsDeleted,
                        PostTags = tagDto.PostTags,
                        CreatedAt = tagDto.CreatedAt,
                        ModifiedAt = tagDto.ModifidedAt
                        
                    };
            }
            catch (EntityNotFoundException e)
            {
                throw new EntityNotFoundException(e.Message);
            }
            }
            throw new Exception();

        }
    }
}
