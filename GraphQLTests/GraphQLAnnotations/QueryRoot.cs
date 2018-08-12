using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Annotations.Attributes;
using GraphQL.Types;

namespace GraphQLAnnotations
{
    [GraphQLObject]
    public class QueryRoot
    {
        private readonly Artist[] _artists;

        public QueryRoot()
        {
            _artists = new []
            {
                new Artist
                {
                    Name = "Alice Cooper",
                    Albums = new List<Album>
                    {
                        new Album
                        {
                            Title = "Welcome to my nightmare"
                        },
                        new Album
                        {
                            Title = "Killer"
                        }
                    }
                },
                new Artist
                {
                    Name = "Black Sabbath",
                    Albums = new List<Album>
                    {
                        new Album
                        {
                            Title = "Paranoid"
                        },
                        new Album
                        {
                            Title = "Heaven and Hell"
                        }
                    }
                }
            };
        }

        [GraphQLFunc(Name = "artist")]
        public Artist GetArtist([GraphQLArgument] string name)
        {
            return _artists.FirstOrDefault(a => String.Equals(a.Name, name));
        }

        [GraphQLFunc]
        public IEnumerable<Artist> Artists(ResolveFieldContext context)
        {
            // simulate access to a datasource
            return _artists;
        }
    }
}
