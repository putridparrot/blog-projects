using GraphQL.Types;

namespace GraphQLService
{
    public class PersonSchema : Schema
    {
        public PersonSchema()
        {
            Query = new PersonQuery();
            Mutation = new PersonMutation();
            Subscription = new PersonSubscription();
        }
    }
}
