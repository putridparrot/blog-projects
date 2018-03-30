package com.putridparrot;

import io.vertx.core.AbstractVerticle;
import io.vertx.core.Vertx;
import io.vertx.ext.web.Router;

public class MainVerticle extends AbstractVerticle {

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

        vertx.deployVerticle(new HelloVerticle(router));
        vertx.deployVerticle(new WorldVerticle(router));
    }
}