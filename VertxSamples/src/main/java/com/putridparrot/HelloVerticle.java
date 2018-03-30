package com.putridparrot;

import io.vertx.core.AbstractVerticle;
import io.vertx.ext.web.Router;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class HelloVerticle extends AbstractVerticle {

    private static final Logger LOGGER = LoggerFactory.getLogger(HelloVerticle.class);

    private final Router router;

    public HelloVerticle(Router router) {
        this.router = router;
    }

    @Override
    public void start() {

        router.route("/hello").handler(ctx -> {

            LOGGER.debug("Hello called");

            ctx.response()
                    .putHeader("content-type", "text/plain")
                    .end("Hello " + ctx.queryParam("name"));
        });

        vertx.createHttpServer()
                .requestHandler(router::accept)
                .listen(8080);

        LOGGER.info("HTTP \"Hello\" server started on port 8080");
    }
}
