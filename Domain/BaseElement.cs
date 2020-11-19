using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace sibintek.sibmobile.core.Domain
{   
    /// Сгенерировал автоматически, нужно причесать
    public partial class BaseElement
    {
        
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string ParentId { get; set; }
        public bool HasChild { get; set; }

        [JsonProperty("_type")]
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public User User { get; set; }
        public string Status { get; set; }
        
        public IEnumerable<BaseElement> Items { get; set; } = new HashSet<BaseElement>();

        public IEnumerable<Feature> Features { get; set; } = new HashSet<Feature>();
        public Links Links { get; set; }
        public IEnumerable<Generic> Generics { get; set; } = new HashSet<Generic>();
        public Icon Icon { get; set; }
        public IEnumerable<Component> Components { get; set; } = new HashSet<Component>();
        public IEnumerable<Claim> Claims { get; set; } = new HashSet<Claim>();
    }

    public class Claim
    {
        public string RoleName { get; set; }
        public string ClaimType { get; set; }
    }
    
    public partial class Feature
    {
        public long? Count { get; set; }
        public string Type { get; set; }
        public bool? State { get; set; }
        public bool? IsClickable { get; set; }
    }

    public partial class Generic
    {
        public string Description { get; set; }
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
    }

    public partial class Icon
    {
        public string Tint { get; set; }
        public Uri Src { get; set; }
    }

    public partial class Component
    {
        public List<Option> Options { get; set; }
        public string Name { get; set; }
        public bool ComponentRequired { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public object Description { get; set; }
        public Icon Icon { get; set; }
        public object Value { get; set; }
    }

    public partial class Option
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Selected { get; set; }
    }

    public partial class Links
    {
        public Uri Image { get; set; }
        public Uri Thumbnail { get; set; }
    }

    public partial class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public Links Links { get; set; }
    }

}
