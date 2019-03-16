using System.Collections.Generic;
using GraphQL.Types;

namespace GraphQLService
{
    public class PersonQuery : ObjectGraphType
    {
        private List<Person> _people;

        public PersonQuery()
        {
            _people = new List<Person>
            {
                new Person {Name = "Scooby Doo"},
                new Person {Name = "Daphne Blake"},
                new Person {Name = "Shaggy Rogers"},
                new Person {Name = "Velma Dinkley"},
                new Person {Name = "Fred Jones"}
            };

            Field<ListGraphType<PersonType>>("people", resolve: context => _people);
            Field<PersonType>("find", 
                arguments: new QueryArguments(new QueryArgument<StringGraphType> {Name = "input"}),
                resolve: context =>
                {
                    var n = context.GetArgument<string>("input");
                    return new Person {Name = n };
                });
        }
    }
}
