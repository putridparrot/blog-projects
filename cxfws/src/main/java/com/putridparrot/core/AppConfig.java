package com.putridparrot.core;

import org.apache.cxf.bus.spring.SpringBus;
import org.apache.cxf.endpoint.Server;
import org.apache.cxf.jaxws.JaxWsServerFactoryBean;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.DependsOn;

@Configuration
public class AppConfig {
    @Bean( destroyMethod = "shutdown" )
    public SpringBus cxf() {
        return new SpringBus();
    }

    @Bean @DependsOn( "cxf" )
    public Server getServer() {
        JaxWsServerFactoryBean factory = new JaxWsServerFactoryBean();
        factory.setServiceBean(getService());
        return factory.create();
    }

    @Bean
    public HelloWorldImpl getService() {
        return new HelloWorldImpl();
    }
}