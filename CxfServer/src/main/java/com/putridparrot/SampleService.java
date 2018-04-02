package com.putridparrot;

import sample.PurchaseOrderType;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

@Path("service")
@Produces({MediaType.APPLICATION_JSON, MediaType.APPLICATION_XML})
public interface SampleService {
    @GET
    @Path("purchaseOrder")
    PurchaseOrderType getPurchaseOrder();
}