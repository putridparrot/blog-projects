package com.putridparrot;

import io.vertx.core.AbstractVerticle;
import io.vertx.core.Vertx;
import io.vertx.core.eventbus.EventBus;
import io.vertx.ext.web.Router;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class MainVerticle extends AbstractVerticle {

    private static final Logger LOGGER = LoggerFactory.getLogger(MainVerticle.class);


    public static void main(String[] args) {
        Vertx vertx = Vertx.vertx();

        initialize(vertx);
    }

    @Override
    public void start() {
        initialize(vertx);
    }

    private static void initialize(Vertx vertx) {
        Router router = Router.router(vertx);

        vertx.deployVerticle(new ClientVerticle(), e ->
            {
                vertx.deployVerticle(new HelloVerticle(router));
                vertx.deployVerticle(new WorldVerticle(router));
            });

        EventBus eventBus = vertx.eventBus();
        eventBus.consumer("/svc", handler ->
        {
            LOGGER.info("Event: " + handler.body().toString());
        });
    }
}