package com.putridparrot;

import io.vertx.circuitbreaker.HystrixMetricHandler;
import io.vertx.core.AbstractVerticle;
import io.vertx.core.Future;
import io.vertx.ext.web.Router;

public class HysterixDashboardVerticle extends AbstractVerticle {

    private final Router router;

    HysterixDashboardVerticle(Router router) {
        this.router = router;
    }

    @Override
    public void start(Future<Void> future) {
        SharedVerticle
            .configuration(vertx)
            .setHandler(ar ->
            {
                router
                    .route("/hysterix-metrics")
                    .handler(HystrixMetricHandler.create(vertx));
            });
    }
}
