using System.Collections.Generic;
using GraphQL.Annotations.Attributes;

namespace GraphQLAnnotations
{
    [GraphQLObject]
    public class Artist
    {
        [GraphQLField]
        public string Name { get; set; }

        [GraphQLField]
        public IList<Album> Albums { get; set; }
    }

    [GraphQLObject]
    public class Album
    {
        [GraphQLField]
        public string Title { get; set; }
    }
}
