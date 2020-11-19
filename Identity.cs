using System.Collections.Generic;

namespace sibintek.sibmobile.core
{
    public class Identity : IIdentity
    {
        public string Name { get; set; }
        public IList<IRole> Roles { get; set; }

        public Identity(string name) => Name = name;
    }

    public class Role : IRole
    {
        public string Name { get; set; }
    }
}
