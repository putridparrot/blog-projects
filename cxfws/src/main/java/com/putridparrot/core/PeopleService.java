package com.putridparrot.core;

import javax.json.JsonArray;
import javax.json.Json;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;

@Path("/people")
public class PeopleService {
    @Produces({"application/json"})
    @GET
    public JsonArray getPeople() {
        return Json.createArrayBuilder()
                .add(Json.createObjectBuilder()
                        .add("firstName", "Brian")
                        .add("lastName", "Kernighan "))
                .add(Json.createObjectBuilder()
                        .add("firstName", "Dennis")
                        .add("lastName", "Ritchie "))
                .add(Json.createObjectBuilder()
                        .add("firstName", "Bjarne")
                        .add("lastName", "Stroustrup"))
                .build();
    }
}