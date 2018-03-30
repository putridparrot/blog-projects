package com.putridparrot;

import io.vertx.core.AbstractVerticle;
import io.vertx.core.Vertx;
import io.vertx.ext.web.Router;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class MainVerticle extends AbstractVerticle {

    private static final Logger LOGGER = LoggerFactory.getLogger(MainVerticle.class);


    public static void main(String[] args) {
        Vertx vertx = Vertx.vertx();

        vertx.deployVerticle(new MainVerticle());
    }


    @Override
    public void start() {

        Router router = Router.router(vertx);

        router.route("/hello").handler(ctx -> {

            LOGGER.debug("Hello called");

            ctx.response()
                    .putHeader("content-type", "text/plain")
                    .end("Hello " + ctx.queryParam("name"));
        });

        vertx.createHttpServer()
                .requestHandler(router::accept)
                .listen(8080);

        System.out.println("HTTP server started on port 8080");
    }
}