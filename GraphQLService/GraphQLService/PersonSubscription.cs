using System;
using System.Reactive.Linq;
using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;

namespace GraphQLService
{
    public class PersonSubscription : ObjectGraphType
    {
        public PersonSubscription()
        {
            AddField(new EventStreamFieldType
            {
                Name = "personAdded",
                Type = typeof(PersonType),
                Resolver = new FuncFieldResolver<Person>(ResolvePerson),
                Subscriber = new EventStreamResolver<Person>(SubscribePerson)
            });
        }

        private Person ResolvePerson(ResolveFieldContext context)
        {
            return context.Source as Person;
        }

        private IObservable<Person> SubscribePerson(ResolveEventStreamContext context)
        {
            return Observable.Interval(TimeSpan.FromSeconds(1)).Select(s => new Person {Name = s.ToString()});
        }
    }
}