import org.apache.velocity.Template;
import org.apache.velocity.VelocityContext;
import org.apache.velocity.app.VelocityEngine;
import org.apache.velocity.runtime.RuntimeServices;
import org.apache.velocity.runtime.RuntimeSingleton;
import org.apache.velocity.runtime.parser.ParseException;
import org.apache.velocity.runtime.parser.node.SimpleNode;

import java.io.StringReader;
import java.io.StringWriter;
import java.util.ArrayList;

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

        generateFromTemplate1(velocityEngine);
        generateFromTemplate2(velocityEngine);
        generateFromTemplate3(velocityEngine);
        generateFromTemplate4();
    }

    private static void generateFromTemplate1(VelocityEngine velocityEngine) {

        System.out.println("Template 1");

        VelocityContext velocityContext = new VelocityContext();
        velocityContext.put("name", "PutridParrot");
        velocityContext.put("template_name", "MyPutridParrotTemplate");

        merge(velocityEngine, velocityContext, "template1.txt.vm");
    }

    private static void generateFromTemplate2(VelocityEngine velocityEngine) {

        System.out.println("Template 2");

        ArrayList<String> list = new ArrayList<>();
        list.add("Putrid");
        list.add("Parrot");

        VelocityContext velocityContext = new VelocityContext();
        velocityContext.put("name", "PutridParrot");
        velocityContext.put("template_name", "MyPutridParrotTemplate");

        velocityContext.put("template_name", list);

        merge(velocityEngine, velocityContext, "template2.txt.vm");
    }

    private static void generateFromTemplate3(VelocityEngine velocityEngine) {

        System.out.println("Template 3");

        VelocityContext velocityContext = new VelocityContext();
        velocityContext.put("name", "PutridParrot");
        velocityContext.put("template_name", "MyPutridParrotTemplate");

        merge(velocityEngine, velocityContext, "template3.txt.vm");
    }

    private static void generateFromTemplate4()  {

        System.out.println("Template 4");

        try {
            String templateString = "Hello $name,\n\nThis is a $template_name template.";

            RuntimeServices runtimeServices = RuntimeSingleton.getRuntimeServices();
            StringReader reader = new StringReader(templateString);
            SimpleNode node = runtimeServices.parse(reader, "Velocity Template");

            VelocityContext velocityContext = new VelocityContext();
            velocityContext.put("name", "PutridParrot");
            velocityContext.put("template_name", "MyPutridParrotTemplate");

            StringWriter writer = new StringWriter();
            Template template = new Template();
            template.setRuntimeServices(runtimeServices);
            template.setData(node);
            template.initDocument();

            template.merge(velocityContext, writer);

            System.out.println(writer.toString());
        }
        catch(ParseException e) {
            System.out.println(e.getMessage());
        }
    }

    private static void merge(VelocityEngine velocityEngine, VelocityContext velocityContext, String templateFilename) {
        StringWriter writer = new StringWriter();
        Template template = velocityEngine.getTemplate(String.format("templates/%s", templateFilename));
        template.merge(velocityContext, writer);

        System.out.println(writer.toString());
    }
}
