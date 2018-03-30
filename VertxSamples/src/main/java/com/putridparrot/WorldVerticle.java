package com.putridparrot;

import io.vertx.core.AbstractVerticle;
import io.vertx.ext.web.Router;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class WorldVerticle extends AbstractVerticle {

    private static final Logger LOGGER = LoggerFactory.getLogger(WorldVerticle.class);

    private final Router router;

    public WorldVerticle(Router router) {
        this.router = router;
    }

    @Override
    public void start() {

        router.route("/world").handler(ctx -> {

            LOGGER.debug("World called");

            vertx.eventBus()
                .publish("/svc", "World Service");

            ctx.response()
                    .putHeader("content-type", "text/plain")
                    .end("World " + ctx.queryParam("name"));
        });

        vertx.createHttpServer()
                .requestHandler(router::accept)
                .listen(8080);

        LOGGER.info("HTTP \"World\" server started on port 8080");
    }
}
