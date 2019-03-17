package com.example.demo;

import io.reactivex.BackpressureStrategy;
import io.reactivex.Flowable;
import io.reactivex.Observable;
import io.reactivex.observables.ConnectableObservable;
import org.springframework.stereotype.Component;

import java.util.concurrent.TimeUnit;

@Component
public class PersonPublisher {

    private final Flowable<Person> publisher;

    public PersonPublisher() {
        Observable<Person> o = Observable.interval(1, 1, TimeUnit.SECONDS)
                .map(l -> new Person("Echo " + l.toString()));
        ConnectableObservable<Person> co = o.share().publish();

        publisher = co.toFlowable(BackpressureStrategy.BUFFER);
    }

    public Flowable<Person> getPublisher() {
        return publisher;
    }
}
