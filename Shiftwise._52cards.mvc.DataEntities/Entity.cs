﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shiftwise._52cards.mvc.DataEntities
{
    public interface IEntity
    {
        EntityState EntityState { get; set; }
    }

    public enum EntityState
    {
        Unchanged,
        Added,
        Modified,
        Deleted
    }

}
