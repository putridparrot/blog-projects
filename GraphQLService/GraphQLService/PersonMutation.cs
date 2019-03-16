using GraphQL.Types;

namespace GraphQLService
{
    public class PersonMutation : ObjectGraphType<Person>
    {
        public PersonMutation()
        {
            Field<PersonType>("addPerson",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> {Name = "input"}),
                resolve: context =>
                {
                    var n = context.GetArgument<string>("input");
                    return new Person { Name = n };
                });
        }
    }
}