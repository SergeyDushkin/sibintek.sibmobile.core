using System.Collections.Generic;

namespace sibintek.sibmobile.core
{
    public interface IIdentity
    {   
        string Name { get; set; }
        IList<IRole> Roles { get; set; }
    }

    public interface IRole
    {
        string Name { get; set; }
    }
}
