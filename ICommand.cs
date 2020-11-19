using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace sibintek.sibmobile.core
{   
    public interface ICommand
    {  
        IIdentity Identity { get; set; } 
    }

    public interface ILocalizeCommand
    {
        string Locale { get; set; }
    }
}
