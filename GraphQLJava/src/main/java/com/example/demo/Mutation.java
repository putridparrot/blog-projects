package com.example.demo;

import com.coxautodev.graphql.tools.GraphQLMutationResolver;
import org.springframework.stereotype.Component;

@Component
public class Mutation implements GraphQLMutationResolver {
    public Person addPerson(String input) {
        return new Person(input);
    }
}
