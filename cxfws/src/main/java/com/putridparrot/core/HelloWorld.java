package com.putridparrot.core;

import javax.jws.WebParam;
import javax.jws.WebService;

@WebService
public interface HelloWorld {
    String reply(@WebParam(name="text") String text);
}