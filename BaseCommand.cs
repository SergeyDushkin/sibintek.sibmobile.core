using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace sibintek.sibmobile.core
{   
    public abstract class BaseCommand : ICommand
    {  
        public IIdentity Identity { get; set; } 
    }
}
