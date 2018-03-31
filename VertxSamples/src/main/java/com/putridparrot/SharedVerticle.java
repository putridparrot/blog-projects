package com.putridparrot;

import io.vertx.config.ConfigRetriever;
import io.vertx.config.ConfigRetrieverOptions;
import io.vertx.config.ConfigStoreOptions;
import io.vertx.core.Future;
import io.vertx.core.Vertx;
import io.vertx.core.json.JsonObject;
import io.vertx.servicediscovery.Record;
import io.vertx.servicediscovery.ServiceDiscovery;
import io.vertx.servicediscovery.ServiceDiscoveryOptions;
import io.vertx.servicediscovery.impl.DiscoveryImpl;
import io.vertx.servicediscovery.types.HttpEndpoint;
import io.vertx.servicediscovery.zookeeper.ZookeeperServiceImporter;

public final class SharedVerticle {

    public static final String SVC_BUS = "/svc";

    public static ServiceDiscovery createServiceDiscovery(Vertx vertx) {
        // docker run --name zookeeper --restart always -d zookeeper
//        return ServiceDiscovery.create(vertx)
//                .registerServiceImporter(new ZookeeperServiceImporter(),
//                        new JsonObject()
//                            .put("connection", "172.17.0.2:2181")
//                            .put("basePath", "/services/hello-service"));

        return new DiscoveryImpl(vertx,
                new ServiceDiscoveryOptions());
    }

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

    public static Future<Record> publish(ServiceDiscovery serviceDiscovery,
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

    public static void unpublish(ServiceDiscovery serviceDiscovery, Record publishedRecord) {
        if(serviceDiscovery != null) {
            if(publishedRecord != null) {
                serviceDiscovery.unpublish(publishedRecord.getRegistration(), ar ->
                {
                    if (ar.succeeded()) {
                        // Success
                    } else {
                        // cannot unpublish the service,
                        // may have already been removed,
                        // or the record is not published
                    }
                });
            }

            serviceDiscovery.close();
        }
    }
}
