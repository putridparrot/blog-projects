using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL;

namespace GraphQLTests
{
    public class QueryRoot
    {
        [GraphQLMetadata("artist")]
        public Artist GetArtist(string name)
        {
            return Artists.FirstOrDefault(a => String.Equals(a.Name, name));
        }

        public IEnumerable<Artist> Artists
        {
            get
            {
                return new Artist[]
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
        }
    }
}
