using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Application.Command;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EFCommands
{
    public class EfGetPostCommand : EfBaseCommand, IGetPostCommand
    {
        public EfGetPostCommand(BlogContext context) : base(context)
        {
        }
        public PostDto Execute(int request)
        {

            var post = Context.Posts.Find(request); //mvc nece da napravi normalan action link, tj ne prosledjuje id iako je genericki...
            if (post == null)
                throw new EntityNotFoundException("Wanted post not found!");
            
            if (post.IsDeleted == true)
                throw new EntityNotFoundException("Wanted post is long time no see!");
            var ptag = Context.PostTags.Find(request);
            var tagovi = Context.Tag.Find(ptag.Tag);
            var t = tagovi.Content.AsQueryable();
            var tengovi = Context.Tag.AsQueryable();
            //tengovi = tengovi.Include(pt => pt.PostTags).ThenInclude(p => p.Post).Where(t=> t.PostTags == p=> p.Post.PosTags)
            return new PostDto
            {
                id = post.Id,
                Name = post.Name,
                Description = post.Description
                //TagsName = t
        };
        }
    }
}
