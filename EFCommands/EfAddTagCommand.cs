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
    public class EfAddTagCommand : EfBaseCommand, IAddTagCommand
    {
        public EfAddTagCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(AddTagDto request)
        {
            var tag = new Domain.Tag
            {
                Content = request.Content
            };
            if (Context.Tag.Any(t => t.Content == request.Content))
            {
                throw new EntityAllreadyExits("Tag");
            }
            Context.Tag.Add(tag);
            try
            {
                Context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
    }
}
