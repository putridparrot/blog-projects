using System;
using GraphQL;
using GraphQL.Types;

namespace GraphQLTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var schema = Schema.For(@"
                schema {
                   query: QueryRoot
                   mutation: QueryRoot
                }

                type QueryRoot {
                   artists: [Artist]
                   artist(name: String): Artist 
                   add(name: String): Artist
                }

                type Artist {
                   name: String
                   albums: [Album]
                }

                type Album {
                   title: String
                }
            ", sb =>
            {
                sb.Types.Include<QueryRoot>();
            });


            //var query = @"{
            //        artists {
            //            name
            //        }
            //    }";

            // Adds Rush to the Artists
            //var query = @"
            //      mutation {
            //         add(name: ""Rush"") { name }
            //      }";

            //var query = "{ artist(name: \"Alice Cooper\") { name } }";

            // get album titles for artist Alice Cooper
            var query = "{ artist(name: \"Alice Cooper\") { name albums { title } } }";

            //var root = new QueryRoot();

            var json = schema.Execute(e =>
            {
                e.Query = query;
            });

            Console.WriteLine(json);
        }
    }
}
