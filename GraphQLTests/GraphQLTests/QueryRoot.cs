using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL;

namespace GraphQLTests
{
    public class QueryRoot
    {
        private readonly List<Artist> _artists;

        public QueryRoot()
        {
            _artists = new List<Artist>
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

        [GraphQLMetadata("artist")]
        public Artist GetArtist(string name)
        {
            return Artists.FirstOrDefault(a => String.Equals(a.Name, name));
        }

        public IEnumerable<Artist> Artists => _artists;

        [GraphQLMetadata]
        public Artist Add(string name)
        {
            // simple mutation method
            var newArtist = new Artist {Name = name};
            _artists.Add(newArtist);
            return newArtist;
        }
    }
}
