using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace sibintek.sibmobile.core
{   
    public interface ICommandHandlerAttribute
    {   
        string CommandTypeName { get; }
    }

    public class CommandHandlerAttribute : Attribute, ICommandHandlerAttribute
    {
        public string CommandTypeName { get; }

        public CommandHandlerAttribute(string type) 
            => CommandTypeName = type;
    }
}
