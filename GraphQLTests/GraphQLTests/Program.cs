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
                   root: QueryRoot
                }

                type QueryRoot {
                   artists: [Artist]
                   artist(name: String): Artist 
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


            var query = @"{
                    artists {
                        name
                    }
                }";

            //var query = "{ artist(name: \"Alice Cooper\") { name } }";

            //var root = new QueryRoot();

            var json = schema.Execute(e =>
            {
                e.Query = query;
            });

            Console.WriteLine(json);
        }
    }
}
