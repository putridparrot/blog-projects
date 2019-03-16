using GraphQL.Types;

namespace GraphQLService
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(o => o.Name);
        }
    }
}