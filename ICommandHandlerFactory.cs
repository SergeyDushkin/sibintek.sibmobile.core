using System;
using System.Collections.Generic;

namespace sibintek.sibmobile.core
{   
    public interface ICommandHandlerFactory
    {   
        IEnumerable<Type> GetHandlers(string name);
    }
}
