package com.example.demo;

import com.coxautodev.graphql.tools.GraphQLQueryResolver;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class Query implements GraphQLQueryResolver {
    List<Person> people = new ArrayList<>();

    public Query() {
        people.add(new Person("Scooby"));
        people.add(new Person("Shaggy"));
        people.add(new Person("Daphne"));
        people.add(new Person("Thelma"));
        people.add(new Person("Fred"));
    }

    public List<Person> people() {
        return people;
    }

    public Person find(String input) {
        return people.stream()
                .filter(p -> p.getName().equalsIgnoreCase(input))
                .findFirst()
                .orElse(null);
    }
}
