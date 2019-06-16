using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public abstract class EfBaseCommand
    {
        protected EfBaseCommand(BlogContext context)
        {
            Context = context;
        }

        protected BlogContext Context { get; }
    }
}
