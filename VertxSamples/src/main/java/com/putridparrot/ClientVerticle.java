package com.putridparrot;

import io.vertx.core.AbstractVerticle;
import io.vertx.core.http.HttpClient;
import io.vertx.core.json.JsonObject;
import io.vertx.servicediscovery.Record;
import io.vertx.servicediscovery.ServiceDiscovery;
import io.vertx.servicediscovery.ServiceReference;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class ClientVerticle extends AbstractVerticle {

    private static final Logger LOGGER = LoggerFactory.getLogger(ClientVerticle.class);

    @Override
    public void start() {

        vertx.eventBus()
            .consumer("vertx.discovery.announce", e ->
            {
                LOGGER.info("vertx.discovery.announce received");

                ServiceDiscovery discovery = ServiceDiscovery.create(vertx);

                discovery.getRecord(
                    new JsonObject().put("name", "hello-service"), found -> {
                        if(found.succeeded()) {
                            Record match = found.result();
                            ServiceReference reference = discovery.getReference(match);
                            HttpClient client = reference.get();

                            client.getNow("/hello?name=Scooby", response ->
                                response.bodyHandler(
                                    body ->
                                        LOGGER.info("Client respone: " + body.toString())));
                            }
                        });
            });
    }
}
