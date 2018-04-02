package com.putridparrot;

import sample.PurchaseOrderType;
import org.apache.cxf.jaxrs.client.JAXRSClientFactory;
import org.apache.cxf.jaxrs.client.WebClient;
import org.apache.cxf.jaxrs.provider.JAXBElementProvider;
import org.codehaus.jackson.jaxrs.JacksonJsonProvider;

import javax.ws.rs.core.MediaType;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class ClientApplication {
    public static void main(String[] args) throws IOException {

        List<Object> providers = new ArrayList<Object>();
        providers.add(new JAXBElementProvider());
        providers.add(new JacksonJsonProvider());

        SampleService service = JAXRSClientFactory.create(
                "http://localhost:9000",
                SampleService.class,
                providers);

//        WebClient.client(service)
//                .type(MediaType.APPLICATION_XML_TYPE)
//                .accept(MediaType.APPLICATION_XML_TYPE);

        WebClient.client(service)
                .type(MediaType.APPLICATION_JSON_TYPE)
                .accept(MediaType.APPLICATION_JSON_TYPE);

        PurchaseOrderType request = service.getPurchaseOrder();

        System.out.println(request.getBillTo().getName());
        System.in.read();
    }
}