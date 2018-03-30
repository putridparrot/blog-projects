package com.putridparrot;

import io.vertx.config.ConfigRetriever;
import io.vertx.config.ConfigRetrieverOptions;
import io.vertx.config.ConfigStoreOptions;
import io.vertx.core.Future;
import io.vertx.core.Vertx;
import io.vertx.core.json.JsonObject;
import io.vertx.servicediscovery.Record;
import io.vertx.servicediscovery.ServiceDiscovery;
import io.vertx.servicediscovery.types.HttpEndpoint;

import javax.xml.ws.Service;


public final class SharedVerticle {

    public static final String SVC_BUS = "/svc";

    public static Future<JsonObject> configuration(Vertx vertx) {

        Future<JsonObject> f = Future.future();

        ConfigStoreOptions propertyFile = new ConfigStoreOptions()
                .setType("file")
                .setFormat("properties")
                .setConfig(new JsonObject().put("path", "config.properties"));

        ConfigRetrieverOptions options = new ConfigRetrieverOptions()
                .addStore(propertyFile);

        ConfigRetriever retriever = ConfigRetriever.create(vertx, options);
        retriever.getConfig(f.completer());

        return f;
    }

    public static Future<Record> expose(ServiceDiscovery serviceDiscovery,
        String name, String host, int port, String root) {

        Future<Record> f = Future.future();

        Record record = HttpEndpoint.createRecord(
                name,
                host,
                port,
                root);

        serviceDiscovery.publish(record, f.completer());

        return f;
    }
}
