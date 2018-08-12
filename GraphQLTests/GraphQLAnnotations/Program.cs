using System;
using GraphQL;
using GraphQL.Annotations.Types;
using GraphQL.Http;

namespace GraphQLAnnotations
{
    class Program
    {
        static void Main(string[] args)
        {
            var executer = new DocumentExecuter();
            var writer = new DocumentWriter();

            //var query = @"{
            //        artists {
            //            name
            //        }
            //    }";

            var query = "{ artist(name: \"Alice Cooper\") { name } }";

            var root = new QueryRoot();

            var schema = new Schema<QueryRoot>();         
           
            var result = executer.ExecuteAsync(config =>
            {
                config.Schema = schema;
                config.Root = root;
                config.Query = query;
            });

            Console.WriteLine(writer.Write(result.Result));
        }
    }
}
