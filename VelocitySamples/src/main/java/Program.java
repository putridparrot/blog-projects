import org.apache.velocity.Template;
import org.apache.velocity.VelocityContext;
import org.apache.velocity.app.VelocityEngine;

import java.io.StringWriter;

public class Program {

    public static void main(String[] args) {
        VelocityEngine velocityEngine = new VelocityEngine();
        velocityEngine.setProperty(
                "resource.loader",
                "file");
        velocityEngine.setProperty(
                "file.resource.loader.class",
                "org.apache.velocity.runtime.resource.loader.FileResourceLoader");
        velocityEngine.setProperty(
                "file.resource.loader.path",
                "src/main/resources");

        VelocityContext velocityContext = new VelocityContext();
        velocityContext.put("name", "PutridParrot");
        velocityContext.put("template_name", "MyPutridParrotTemplate");

        StringWriter writer = new StringWriter();
        Template template = velocityEngine.getTemplate("templates/template.txt.vm");
        template.merge(velocityContext, writer);

        System.out.println(writer.toString());
    }
}
