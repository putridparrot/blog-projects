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

public class WorldVerticle extends AbstractVerticle {

    private static final Logger LOGGER = LoggerFactory.getLogger(WorldVerticle.class);

    private final Router router;
    private ServiceDiscovery discovery;
    private Record publishedRecord;

    public WorldVerticle(Router router) {
        this.router = router;
    }

    @Override
    public void start() {

        discovery = new DiscoveryImpl(vertx,
                new ServiceDiscoveryOptions());

        router.route("/world").handler(ctx -> {

            LOGGER.debug("World called");

            vertx.eventBus()
                .publish("/svc", "World Service");

            ctx.response()
                    .putHeader("content-type", "text/plain")
                    .end("World " + ctx.queryParam("name"));
        });

        Record record = HttpEndpoint.createRecord(
                "world-service",
                "localhost",
                8080,
                "/world");

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

        LOGGER.info("HTTP \"World\" server started on port 8080");
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
    }}
