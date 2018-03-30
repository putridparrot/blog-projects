package com.putridparrot;

import io.vertx.core.AbstractVerticle;
import io.vertx.ext.web.Router;
import io.vertx.servicediscovery.Record;
import io.vertx.servicediscovery.ServiceDiscovery;
import io.vertx.servicediscovery.ServiceDiscoveryOptions;
import io.vertx.servicediscovery.impl.DiscoveryImpl;
import io.vertx.servicediscovery.types.HttpEndpoint;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class HelloVerticle extends AbstractVerticle {

    private static final Logger LOGGER = LoggerFactory.getLogger(HelloVerticle.class);

    private final Router router;
    private ServiceDiscovery discovery;
    private Record publishedRecord;

    public HelloVerticle(Router router) {
        this.router = router;
    }

    @Override
    public void start() {

        discovery = new DiscoveryImpl(vertx,
                new ServiceDiscoveryOptions());

        router.route("/hello").handler(ctx -> {

            LOGGER.debug("Hello called");

            vertx.eventBus()
                .publish("/svc", "Hello Service");

            ctx.response()
                    .putHeader("content-type", "text/plain")
                    .end("Hello " + ctx.queryParam("name"));
        });

        Record record = HttpEndpoint.createRecord(
                "hello-service",
                "localhost",
                8080,
                "/hello");

        discovery.publish(record, ar ->
        {
            if (ar.succeeded()) {
                // publication success
                publishedRecord = ar.result();
            } else {
                // publication failure
            }
        });

        vertx.createHttpServer()
                .requestHandler(router::accept)
                .listen(8080);

        LOGGER.info("HTTP \"Hello\" server started on port 8080");
    }

    @Override
    public void stop() {
        if(discovery != null) {
            discovery.unpublish(publishedRecord.getRegistration(), ar ->
            {
                if (ar.succeeded()) {
                    // Success
                } else {
                    // cannot unpublish the service,
                    // may have already been removed,
                    // or the record is not published
                }
            });

            discovery.close();
        }
    }
}
