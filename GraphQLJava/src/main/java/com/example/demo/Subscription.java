package com.example.demo;

import com.coxautodev.graphql.tools.GraphQLSubscriptionResolver;
import org.reactivestreams.Publisher;
import org.springframework.stereotype.Component;

@Component
public class Subscription implements GraphQLSubscriptionResolver {

    private PersonPublisher publisher;

    public Subscription(PersonPublisher publisher) {
        this.publisher = publisher;
    }

    public Publisher<Person> personAdded() {
        return publisher.getPublisher();
    }
}
