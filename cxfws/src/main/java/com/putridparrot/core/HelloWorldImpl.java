package com.putridparrot.core;

import javax.jws.WebParam;
import javax.jws.WebService;

@WebService(endpointInterface = "com.putridparrot.core.HelloWorld", serviceName="HelloWorld")
public class HelloWorldImpl implements HelloWorld {
    public String reply(@WebParam(name = "text") String text) {
        return "Hello " + text;
    }
}