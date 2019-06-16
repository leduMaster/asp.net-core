using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Application.Command;
using Application.Interfaces;
using EFDataAccess;
using Domain;
using Application.Exceptions;

namespace EFCommands
{
    public class EfAddPostCommand : EfBaseCommand, IAddPostCommand
    {
        public EfAddPostCommand(BlogContext context) : base(context)
        {
        }

        void ICommand<AddPostDto>.Execute(AddPostDto request)
        {
            var post = new Domain.Post
            {
                Name = request.Name,
                Description = request.Description,
                IsDeleted = false,
                CreatedAt = DateTime.Now
            };
            if (Context.Posts.Any(p => p.Name == request.Name))
            {
                throw new EntityAllreadyExits("Post");
            }
            Context.Posts.Add(post);
            try
            {
                Context.SaveChanges();
                return ;
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
