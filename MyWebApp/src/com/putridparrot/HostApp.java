package com.putridparrot;

import org.apache.catalina.LifecycleException;
import org.apache.catalina.connector.Connector;
import org.apache.catalina.startup.Tomcat;

import javax.servlet.ServletException;
import java.io.File;

public class HostApp {
    public static void main(String[] args) throws ServletException, LifecycleException {

        Tomcat tomcat = new Tomcat();
        tomcat.setBaseDir("temp");
        tomcat.setPort(8080);

        String contextPath = "";
        String webappDir = new File("web").getAbsolutePath();

        tomcat.addWebapp(contextPath, webappDir);

        Connector c = tomcat.getConnector();
        c.setProperty("compression", "force");
        c.setProperty("compressionMinSize", "1024");
        c.setProperty("noCompressionUserAgents", "gozilla, traviata");
        c.setProperty("compressableMimeType", "text/html,text/xml,text/css,application/json,application/javascript");
        tomcat.setConnector(c);

        tomcat.start();
        tomcat.getServer().await();
    }
}