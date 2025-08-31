package com.putridparrot;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import java.util.HashMap;
import java.util.Map;

@SpringBootApplication
public class EchoServiceApplication {
    public static void main(String[] args) {
        SpringApplication app = new SpringApplication(EchoServiceApplication.class);
        Map<String, Object> props = new HashMap<>();
        props.put("server.port", System.getenv("PORT"));
        app.setDefaultProperties(props);
        app.run(args);
    }
}