using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
public class EntityAllreadyExits : Exception
    {
        public EntityAllreadyExits(string entityType) : base(entityType + " already exists."){ }
    }
}