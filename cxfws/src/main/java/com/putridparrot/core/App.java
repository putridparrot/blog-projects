package com.putridparrot.core;

import org.apache.cxf.transport.servlet.CXFServlet;
import org.eclipse.jetty.server.Server;
import org.eclipse.jetty.servlet.ServletContextHandler;
import org.eclipse.jetty.servlet.ServletHolder;
import org.springframework.web.context.ContextLoaderListener;
import org.springframework.web.context.support.AnnotationConfigWebApplicationContext;

public class App {
    public static void main( String[] args ) throws Exception {

        Server server = new Server( 9000 );

        ServletHolder servletHolder = new ServletHolder( new CXFServlet() );
        ServletContextHandler context = new ServletContextHandler();
        context.setContextPath( "/" );
        context.addServlet( servletHolder, "/*" );
        context.addEventListener( new ContextLoaderListener() );

        context.setInitParameter( "contextClass", AnnotationConfigWebApplicationContext.class.getName() );
        context.setInitParameter( "contextConfigLocation", AppConfig.class.getName() );

        server.setHandler( context );
        server.start();
        server.join();

        System.in.read();

        System.exit(0);
    }
}